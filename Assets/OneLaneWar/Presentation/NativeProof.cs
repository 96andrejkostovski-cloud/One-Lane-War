#if UNITY_EDITOR || DEVELOPMENT_BUILD
using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace OneLaneWar.Presentation
{
    // Explicit opt-in, development builds only. Runs the real player/render loop.
    public sealed class NativeProof : MonoBehaviour
    {
        static void Capture(string name)
        {
            // Android's ScreenCapture API resolves names beneath persistentDataPath.
#if UNITY_ANDROID && !UNITY_EDITOR
            ScreenCapture.CaptureScreenshot("PH01/" + name);
#else
            ScreenCapture.CaptureScreenshot(Path.Combine(Application.persistentDataPath, "PH01", name));
#endif
        }
        static readonly string[] Army = { "militia", "shieldguard", "crossbowman", "grenadier" };
        static readonly string[] Upgrades = { "u01", "u04", "u07", "u19" };
        IEnumerator Start()
        {
            bool requested = Array.IndexOf(Environment.GetCommandLineArgs(), "--olw-proof") >= 0;
#if UNITY_ANDROID && !UNITY_EDITOR
            using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var activity = player.GetStatic<AndroidJavaObject>("currentActivity"))
            using (var intent = activity.Call<AndroidJavaObject>("getIntent"))
                requested = intent.Call<bool>("getBooleanExtra", "olwProof", false);
#endif
            if (!requested) yield break;
            var harness = GetComponent<BattleHarness>();
            string output = Path.Combine(Application.persistentDataPath, "PH01"); Directory.CreateDirectory(output);
            Debug.Log("OLW_NATIVE_START unity=" + Application.unityVersion + " graphics=" + SystemInfo.graphicsDeviceVersion + " output=" + output);
            harness.ShowSetup(); yield return new WaitForSecondsRealtime(0.5f);
            Capture("configuration.png"); yield return new WaitForSecondsRealtime(0.5f);
            var model = new CombatModel(harness.Content, "c01_e01_b01", Army, Upgrades, 17);
            long sequence = 0;
            for (int t = 0; t < 3600; t += 25) model.Enqueue(new CombatCommand(t, sequence++, CommandKind.Deploy, Army[(t / 25) % 4]));
            for (int t = 240; t < 4000; t += 600) model.Enqueue(new CombatCommand(t, sequence++, CommandKind.Rally));
            while (model.Result == Outcome.Active) model.Step();
            string expected = model.StateHash(); int runs = 0;
            foreach (int fps in new[] { 30, 60 }) foreach (int speed in new[] { 1, 2, 4, 10 })
            {
                Application.targetFrameRate = fps; QualitySettings.vSyncCount = 0;
                harness.StartBattle("c01_e01_b01", Army, Upgrades, 17); harness.QueueReplay(); harness.SetSpeed(speed);
                harness.SetCleanCapture(false); double start = Time.realtimeSinceStartupAsDouble; int frames = 0; bool captured = false;
                while (harness.Model.Result == Outcome.Active)
                {
                    yield return null; frames++;
                    if (Time.realtimeSinceStartupAsDouble - start > 180) { Debug.LogError("OLW_NATIVE_PROOF_TIMEOUT"); yield break; }
                    if (!captured && harness.Model.Tick >= 240)
                    {
                        captured = true; Capture("battle-" + fps + "-" + speed + ".png");
                    }
                }
                double elapsed = Time.realtimeSinceStartupAsDouble - start;
                string hash = harness.Model.StateHash();
                string record = "OLW_NATIVE_REPLAY target_fps=" + fps + " speed=" + speed + " frames=" + frames + " elapsed_s=" + elapsed.ToString("F3", System.Globalization.CultureInfo.InvariantCulture)
                    + " measured_fps=" + (frames / elapsed).ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + " tick=" + harness.Model.Tick + " result=" + harness.Model.Result + " hash=" + hash + " expected=" + expected;
                Debug.Log(record); File.AppendAllText(Path.Combine(output, "replay.txt"), record + Environment.NewLine);
                if (hash != expected) { Debug.LogError("OLW_NATIVE_PROOF_HASH_MISMATCH"); yield break; }
                runs++; harness.SetCleanCapture(true);
                Capture("clean-" + fps + "-" + speed + ".png"); yield return new WaitForSecondsRealtime(0.25f);
            }
            harness.SetCleanCapture(false);
            Debug.Log("OLW_NATIVE_PROOF_ALL_PASS runs=" + runs + " source=" + harness.Content.SourceHash);
        }
    }
}
#endif
