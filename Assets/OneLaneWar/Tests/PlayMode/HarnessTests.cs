using System.Collections;
using System.Linq;
using NUnit.Framework;
using OneLaneWar.Presentation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

namespace OneLaneWar.Tests
{
    public sealed class HarnessTests
    {
        static readonly string[] Army = { "militia", "shieldguard", "crossbowman", "grenadier" };
        BattleHarness harness;
        [UnitySetUp] public IEnumerator LoadScene()
        {
            SceneManager.LoadScene("Battle"); yield return null;
            harness = Object.FindFirstObjectByType<BattleHarness>(); Assert.NotNull(harness); harness.Pause(true);
        }
        [UnityTest] public IEnumerator SceneReloadDoesNotDuplicateHarnessOrInput()
        {
            for (int i = 0; i < 3; i++) { SceneManager.LoadScene("Battle"); yield return null; }
            Assert.AreEqual(1, Object.FindObjectsByType<BattleHarness>(FindObjectsSortMode.None).Length);
            Assert.AreEqual(1, Object.FindObjectsByType<UnityEngine.EventSystems.EventSystem>(FindObjectsSortMode.None).Length);
        }
        [UnityTest] public IEnumerator CommandSubmissionDoesNotBypassDeploymentCooldown()
        {
            harness.StartBattle("c01_e01_b01", Army, new string[0], 17); harness.Deploy(0); harness.Deploy(0); harness.AdvanceFrame(0.05m);
            Assert.AreEqual(1, harness.Model.Alive(Side.Player)); Assert.AreEqual(80000000L, harness.Model.Supply(Side.Player)); yield return null;
        }
        [UnityTest] public IEnumerator InputSystemRequiresReleaseAndCannotBypassCooldown()
        {
            // Explicitly order runtime isolation before scene-owned actions. NUnit
            // SetUp and UnitySetUp otherwise create the actions in different runtimes.
            Object.DestroyImmediate(harness.gameObject);
            var inputFixture = new InputTestFixture(); inputFixture.Setup();
            try
            {
            SceneManager.LoadScene("Battle"); yield return null;
            harness = Object.FindFirstObjectByType<BattleHarness>();
            harness.StartBattle("c01_e01_b01", Army, new string[0], 17); harness.enabled = false;
            yield return null; Canvas.ForceUpdateCanvases();
            // The headless editor reports focus loss on the first yielded frame.
            // Establish a foreground model for this pointer-path test explicitly.
            harness.Model.SetPause("SYSTEM_FOCUS", false); harness.Suspend(false); harness.Pause(false);
            var button = harness.GetComponentsInChildren<Button>().First(b => b.name == "Deploy");
            var rect = (RectTransform)button.transform;
            Vector2 point = RectTransformUtility.WorldToScreenPoint(null, rect.TransformPoint(rect.rect.center));
            var hits = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
            UnityEngine.EventSystems.EventSystem.current.RaycastAll(new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current) { position = point }, hits);
            Assert.IsTrue(hits.Count > 0 && hits[0].gameObject == button.gameObject, "Button must be top raycast at " + point + "; hit=" + (hits.Count > 0 ? hits[0].gameObject.name : "none"));
            var mouse = InputSystem.AddDevice<Mouse>();
            // BatchMode has no focused Game view. Keep this synthetic test device
            // processing; the separate lifecycle test covers production focus gates.
            var backgroundBehavior = InputSystem.settings.backgroundBehavior;
            var editorBehavior = InputSystem.settings.editorInputBehaviorInPlayMode;
            InputSystem.settings.backgroundBehavior = InputSettings.BackgroundBehavior.IgnoreFocus;
            InputSystem.settings.editorInputBehaviorInPlayMode = InputSettings.EditorInputBehaviorInPlayMode.AllDeviceInputAlwaysGoesToGameView;
            var module = harness.GetComponentInChildren<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            int clicks = 0, actions = 0;
            button.onClick.AddListener(() => clicks++);
            module.leftClick.action.performed += _ => actions++;
            System.Action<MouseState> send = state => { InputSystem.QueueStateEvent(mouse, state); InputSystem.Update(); };
            try
            {
                send(new MouseState { position = point }); yield return null;
                send(new MouseState { position = point }.WithButton(MouseButton.Left)); yield return null;
                Assert.IsTrue(mouse.leftButton.isPressed, "Synthetic press must reach Input System");
                harness.AdvanceFrame(0.05m); Assert.AreEqual(0, harness.Model.Alive(Side.Player), "Pointer down must not deploy");
                send(new MouseState { position = point }); yield return null;
                harness.AdvanceFrame(0.05m); Assert.AreEqual(1, harness.Model.Alive(Side.Player), "Completed click must deploy once; pauses=" + string.Join(",", harness.Model.PauseReasons) + "; action=" + module.leftClick.action.enabled + "; callbacks=" + actions + "; clicks=" + clicks + "; raycast=" + module.GetLastRaycastResult(mouse.deviceId).gameObject);
                send(new MouseState { position = point }.WithButton(MouseButton.Left)); yield return null;
                send(new MouseState { position = point }); yield return null;
                harness.AdvanceFrame(0.05m); Assert.AreEqual(1, harness.Model.Alive(Side.Player));
            }
            finally { InputSystem.settings.backgroundBehavior = backgroundBehavior; InputSystem.settings.editorInputBehaviorInPlayMode = editorBehavior; InputSystem.RemoveDevice(mouse); }
            }
            finally { if (harness != null) Object.DestroyImmediate(harness.gameObject); inputFixture.TearDown(); }
        }
        [UnityTest] public IEnumerator BackgroundRequiresExplicitResumeWithoutElapsedCredit()
        {
            harness.StartBattle("c01_e01_b01", Army, new string[0], 17); harness.Suspend(true); harness.AdvanceFrame(60);
            Assert.AreEqual(-1, harness.Model.Tick); harness.Suspend(false); harness.AdvanceFrame(60); Assert.IsTrue(harness.Model.Paused);
            harness.Pause(false); harness.AdvanceFrame(0.05m); Assert.AreEqual(0, harness.Model.Tick); Assert.AreEqual(100000000L, harness.Model.Supply(Side.Player)); yield return null;
        }
        [UnityTest] public IEnumerator SingleStepAndCleanCaptureDoNotAdvancePausedModel()
        {
            harness.StartBattle("c01_e01_b01", Army, new string[0], 17); harness.Pause(true); harness.StepOnce(); Assert.AreEqual(0, harness.Model.Tick);
            string hash = harness.Model.StateHash(); harness.SetCleanCapture(true); harness.AdvanceFrame(10); Assert.AreEqual(hash, harness.Model.StateHash()); yield return null;
        }
        [UnityTest] public IEnumerator EveryEncounterAndEligibleUpgradeCanConfigure()
        {
            foreach (string encounter in harness.Content.EncounterIds)
            { harness.StartBattle(encounter, Army, harness.Content.Eligible(Army).Take(4).ToArray(), 17); Assert.AreEqual(encounter, harness.Model.EncounterId); }
            yield return null;
        }
        [UnityTest] public IEnumerator RenderedHarnessMatchesHeadlessAcrossScheduledRates()
        {
            var headless = new CombatModel(harness.Content, "c01_e01_b01", Army, new[] { "u01", "u04", "u07", "u19" }, 17);
            long sequence = 0;
            for (int t = 0; t < 3600; t += 25) headless.Enqueue(new CombatCommand(t, sequence++, CommandKind.Deploy, Army[(t / 25) % 4]));
            for (int t = 240; t < 4000; t += 600) headless.Enqueue(new CombatCommand(t, sequence++, CommandKind.Rally));
            while (headless.Result == Outcome.Active) headless.Step();
            string expected = headless.StateHash();
            foreach (int fps in new[] { 30, 60 }) foreach (int speed in new[] { 1, 2, 4, 10 })
            {
                harness.StartBattle("c01_e01_b01", Army, new[] { "u01", "u04", "u07", "u19" }, 17); harness.QueueReplay(); harness.SetSpeed(speed);
                // Disable automatic wall-time stepping. Feed exactly sampled presentation
                // intervals while yielding real Unity frames to paint/submit the Canvas.
                harness.enabled = false; int frames = 0;
                while (harness.Model.Result == Outcome.Active && frames++ < 20000)
                {
                    harness.AdvanceFrame(1m / fps);
                    if (frames % 20 == 0) yield return null;
                }
                Assert.AreNotEqual(Outcome.Active, harness.Model.Result);
                string actual = harness.Model.StateHash(); Assert.AreEqual(expected, actual);
                Debug.Log("OLW_PLAYMODE_REPLAY scheduled_fps=" + fps + " speed=" + speed + " frames=" + frames + " hash=" + actual);
            }
        }
    }
}
