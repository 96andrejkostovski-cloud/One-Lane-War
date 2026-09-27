#if UNITY_EDITOR || DEVELOPMENT_BUILD
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace OneLaneWar.Presentation
{
    public sealed class BattleHarness : MonoBehaviour
    {
        public CombatModel Model { get; private set; }
        public Content Content { get; private set; }
        public int Speed { get; private set; } = 1;
        public bool CleanCapture { get; private set; }
        public int RenderedFrames { get; private set; }
        TickScheduler scheduler;
        long sequence;
        readonly List<string> army = new List<string> { "militia", "shieldguard", "crossbowman", "grenadier" };
        readonly List<string> upgrades = new List<string>();
        readonly List<GameObject> debug = new List<GameObject>();
        readonly Dictionary<int, RectTransform> actors = new Dictionary<int, RectTransform>();
        readonly Stack<RectTransform> actorPool = new Stack<RectTransform>();
        readonly List<RectTransform> bolts = new List<RectTransform>();
        Canvas canvas; RectTransform root, setup, lane; Font font;
        Text hud, diagnostic, status, encounterLabel, selectionLabel;
        Button[] deploy = new Button[4];
        InputField seedInput;
        int encounterIndex;
        bool automatic;
        static readonly Color Blue = new Color(0.18f, 0.52f, 0.85f), Red = new Color(0.83f, 0.29f, 0.27f);

        void Awake()
        {
            Content = ContentResources.Load(); font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            Application.targetFrameRate = 60;
            BuildUi(); StartBattle(Content.EncounterIds[0], army.ToArray(), new string[0], 17);
            gameObject.AddComponent<NativeProof>();
        }
        public void StartBattle(string encounter, string[] loadout, string[] chosen, uint seed)
        {
            Model = new CombatModel(Content, encounter, loadout, chosen, seed); scheduler = new TickScheduler(Model);
            army.Clear(); army.AddRange(loadout); upgrades.Clear(); upgrades.AddRange(chosen); sequence = 0;
            foreach (var actor in actors.Values) { actor.gameObject.SetActive(false); actorPool.Push(actor); } actors.Clear();
            setup.gameObject.SetActive(false); automatic = false;
            for (int i = 0; i < 4; i++) deploy[i].GetComponentInChildren<Text>().text = Content.UnitName(army[i]) + "\n" + Model.Cost(army[i]) + " Supply";
            Paint();
        }
        public void QueueReplay()
        {
            if (Model.Tick != -1) throw new InvalidOperationException("Replay must start before tick zero");
            for (int t = 0; t < 3600; t += 25) Model.Enqueue(new CombatCommand(t, sequence++, CommandKind.Deploy, army[(t / 25) % 4]));
            for (int t = 240; t < 4000; t += 600) Model.Enqueue(new CombatCommand(t, sequence++, CommandKind.Rally));
            automatic = true;
        }
        public void AdvanceFrame(decimal seconds) { scheduler.Advance(seconds, Speed); Paint(); RenderedFrames++; }
        void Update() { AdvanceFrame((decimal)Time.unscaledDeltaTime); }
        public void SetSpeed(int speed) { if (speed != 1 && speed != 2 && speed != 4 && speed != 10) throw new ArgumentException(); Speed = speed; }
        public void Pause(bool value) { Model.SetPause("PLAYER", value); scheduler.ResetElapsed(); }
        public void StepOnce()
        {
            if (Model.PauseReasons.Any(p => p != "PLAYER")) return;
            Model.SetPause("PLAYER", false); Model.Step(); Model.SetPause("PLAYER", true); scheduler.ResetElapsed(); Paint();
        }
        public void SetCleanCapture(bool value) { CleanCapture = value; foreach (var item in debug) item.SetActive(!value); if (value) Debug.developerConsoleVisible = false; }
        public void Suspend(bool background)
        {
            Model.SetPause("BACKGROUND", background); scheduler.ResetElapsed();
            // Foreground always requires explicit resume, even when focus and pause notifications overlap.
            if (background) Model.SetPause("PLAYER", true);
        }
        void OnApplicationPause(bool pause) { if (Model != null) Suspend(pause); }
        void OnApplicationFocus(bool focus) { if (Model != null) { Model.SetPause("SYSTEM_FOCUS", !focus); scheduler.ResetElapsed(); if (!focus) Model.SetPause("PLAYER", true); } }
        public void Deploy(int index)
        {
            if (Model.Paused || Model.Result != Outcome.Active || automatic) return;
            Model.Enqueue(new CombatCommand(Model.Tick + 1, sequence++, CommandKind.Deploy, army[index]));
        }
        public void Rally()
        {
            if (!Model.Paused && Model.Result == Outcome.Active && !automatic) Model.Enqueue(new CombatCommand(Model.Tick + 1, sequence++, CommandKind.Rally));
        }
        public void ShowSetup()
        {
            Pause(true); setup.gameObject.SetActive(true); RefreshSelection();
        }
        void RefreshSelection()
        {
            encounterLabel.text = Content.EncounterIds[encounterIndex];
            selectionLabel.text = "Army (4): " + string.Join(", ", army) + "\nUpgrades (0–4): " + string.Join(", ", upgrades);
        }
        void BeginSelected(bool replay)
        {
            if (army.Count != 4 || !uint.TryParse(seedInput.text, out uint seed) || seed == 0) { selectionLabel.text = "Choose exactly four troops and enter a nonzero uint seed."; return; }
            StartBattle(Content.EncounterIds[encounterIndex], army.ToArray(), upgrades.ToArray(), seed);
            if (replay) QueueReplay();
        }
        RectTransform Box(Transform parent, string name, float x, float y, float width, float height, Color color)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image)); var rect = go.GetComponent<RectTransform>();
            rect.SetParent(parent, false); rect.anchorMin = rect.anchorMax = new Vector2(0, 1); rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(x, -y); rect.sizeDelta = new Vector2(width, height); go.GetComponent<Image>().color = color; return rect;
        }
        Text Label(Transform parent, string name, string text, float x, float y, float width, float height, int size = 28)
        {
            var go = new GameObject(name, typeof(RectTransform), typeof(CanvasRenderer), typeof(Text)); var r = go.GetComponent<RectTransform>(); r.SetParent(parent, false);
            r.anchorMin = r.anchorMax = new Vector2(0, 1); r.pivot = new Vector2(0, 1); r.anchoredPosition = new Vector2(x, -y); r.sizeDelta = new Vector2(width, height);
            var label = go.GetComponent<Text>(); label.font = font; label.fontSize = size; label.text = text; label.color = Color.white; label.raycastTarget = false; label.alignment = TextAnchor.MiddleCenter; return label;
        }
        Button Control(Transform parent, string text, float x, float y, float w, float h, Action action, bool diagnosticOnly = false)
        {
            var r = Box(parent, text, x, y, w, h, new Color(0.15f, 0.23f, 0.30f)); var b = r.gameObject.AddComponent<Button>();
            b.onClick.AddListener(() => action()); Label(r, "Label", text, 5, 0, w - 10, h, h > 65 ? 28 : 23);
            if (diagnosticOnly) debug.Add(r.gameObject); return b;
        }
        void BuildUi()
        {
            var cg = new GameObject("HarnessCanvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster)); cg.transform.SetParent(transform);
            canvas = cg.GetComponent<Canvas>(); canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = cg.GetComponent<CanvasScaler>(); scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize; scaler.referenceResolution = new Vector2(1920, 1080); scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            root = Box(cg.transform, "Background", 0, 0, 1920, 1080, new Color(0.055f, 0.095f, 0.13f));
            root.anchorMin = root.anchorMax = root.pivot = new Vector2(0.5f, 0.5f); root.anchoredPosition = Vector2.zero;
            var es = new GameObject("HarnessInput", typeof(EventSystem), typeof(InputSystemUIInputModule)); es.transform.SetParent(transform); es.GetComponent<InputSystemUIInputModule>().AssignDefaultActions();
            debug.Add(Label(root, "Title", "ONE LANE WAR  /  PH01 PLACEHOLDER", 30, 10, 1860, 55, 32).gameObject);
            hud = Label(root, "HUD", "", 30, 70, 1860, 100, 30);
            lane = Box(root, "Lane", 70, 280, 1780, 380, new Color(0.11f, 0.18f, 0.16f));
            Box(lane, "Player fortress", 0, 60, 80, 220, Blue); Box(lane, "Enemy fortress", 1700, 60, 80, 220, Red);
            Label(lane, "P", "P", 0, 125, 80, 70, 42); Label(lane, "E", "E", 1700, 125, 80, 70, 42);
            status = Label(root, "BattleStatus", "", 30, 680, 1860, 55, 30);
            for (int i = 0; i < 4; i++) { int index = i; deploy[i] = Control(root, "Deploy", 40 + i * 350, 765, 325, 110, () => Deploy(index)); }
            Control(root, "RALLY", 1450, 765, 420, 110, Rally);
            Control(root, "Pause / Resume", 40, 910, 250, 65, () => Pause(!Model.PauseReasons.Contains("PLAYER")), true);
            Control(root, "Single tick", 310, 910, 200, 65, StepOnce, true);
            for (int i = 0; i < 4; i++) { int speed = new[] { 1, 2, 4, 10 }[i]; Control(root, speed + "x", 530 + i * 125, 910, 110, 65, () => SetSpeed(speed), true); }
            Control(root, "Configure", 1060, 910, 230, 65, ShowSetup, true);
            Control(root, "Clean capture", 1310, 910, 260, 65, () => SetCleanCapture(true), true);
            diagnostic = Label(root, "Diagnostics", "", 30, 995, 1860, 70, 22); debug.Add(diagnostic.gameObject);
            setup = Box(root, "Setup", 120, 100, 1680, 850, new Color(0.06f, 0.09f, 0.14f));
            encounterLabel = Label(setup, "Encounter", "", 360, 20, 960, 60, 32);
            Control(setup, "Previous", 30, 25, 300, 55, () => { encounterIndex = (encounterIndex + Content.EncounterIds.Length - 1) % Content.EncounterIds.Length; RefreshSelection(); });
            Control(setup, "Next", 1350, 25, 300, 55, () => { encounterIndex = (encounterIndex + 1) % Content.EncounterIds.Length; RefreshSelection(); });
            int n = 0;
            foreach (var id in Content.UnitIds)
            {
                string unit = id; Control(setup, Content.UnitName(id), 30 + n++ * 272, 100, 255, 60, () => {
                    if (army.Contains(unit)) army.Remove(unit); else if (army.Count < 4) army.Add(unit);
                    upgrades.RemoveAll(u => !Content.UpgradesForUnits(army.ToArray()).Contains(u)); RefreshSelection();
                });
            }
            n = 0;
            foreach (var id in Content.UpgradeIds)
            {
                string upgrade = id; int col = n % 4, row = n++ / 4;
                Control(setup, id + " " + Content.UpgradeName(id), 30 + col * 410, 190 + row * 67, 395, 57, () => {
                    if (upgrades.Contains(upgrade)) upgrades.Remove(upgrade);
                    else if (upgrades.Count < 4 && Content.UpgradesForUnits(army.ToArray()).Contains(upgrade)) upgrades.Add(upgrade);
                    RefreshSelection();
                });
            }
            selectionLabel = Label(setup, "Selection", "", 30, 610, 1620, 85, 25);
            Label(setup, "Seed label", "Seed", 30, 730, 120, 65, 26);
            var input = Box(setup, "Seed", 155, 730, 240, 65, new Color(0.18f, 0.23f, 0.30f)); seedInput = input.gameObject.AddComponent<InputField>();
            seedInput.textComponent = Label(input, "Value", "17", 8, 0, 224, 65, 28); seedInput.contentType = InputField.ContentType.IntegerNumber; seedInput.text = "17";
            Control(setup, "Start battle", 430, 730, 360, 65, () => BeginSelected(false));
            Control(setup, "Replay fixture", 820, 730, 390, 65, () => BeginSelected(true));
            Control(setup, "Cancel", 1240, 730, 360, 65, () => { setup.gameObject.SetActive(false); });
        }
        void Paint()
        {
            if (Model == null) return;
            hud.text = "PLAYER  " + Model.BaseHp(Side.Player) + "/" + Model.BaseMax(Side.Player) + " HP          Supply " + (Model.Supply(Side.Player) / Fixed.Scale) + "/" + (Model.SupplyCap(Side.Player) / Fixed.Scale)
                + "          ENEMY  " + Model.BaseHp(Side.Enemy) + "/" + Model.BaseMax(Side.Enemy) + " HP";
            status.text = Model.Result != Outcome.Active ? Model.Result.ToString() : Model.Paused ? "PAUSED — resume to continue" : "Rally " + (Model.RallyActive ? "ACTIVE" : Math.Max(0, Model.RallyReadyTick - Model.Tick) / 20m + "s") + (Model.BossRevealed ? "   BOSS APPROACHING" : "");
            diagnostic.text = Model.EncounterId + "  tick " + Model.Tick + "  " + Speed + "x  actors " + Model.Alive(Side.Player) + "/" + Model.Alive(Side.Enemy) + "  queue " + Model.EnemyQueueIndex + "  HP damage " + Model.Counters.HpDamage + "  barrier " + Model.Counters.BarrierDamage + "  base " + Model.Counters.BaseDamage + "\nB001 · T001 · AMEND-005 · " + Content.SourceHash.Substring(0, 12);
            var views = Model.ActorViews(); var ids = new HashSet<int>(views.Select(v => v.Id));
            foreach (int id in actors.Keys.Where(id => !ids.Contains(id)).ToArray()) { var r = actors[id]; r.gameObject.SetActive(false); actorPool.Push(r); actors.Remove(id); }
            foreach (var a in views)
            {
                if (!actors.TryGetValue(a.Id, out var r))
                {
                    r = actorPool.Count > 0 ? actorPool.Pop() : Box(lane, "Actor", 0, 0, 120, 80, Blue);
                    if (r.childCount == 0) Label(r, "Label", "", 0, 0, 120, 80, 19);
                    r.gameObject.SetActive(true); actors[a.Id] = r;
                }
                r.anchoredPosition = new Vector2(70 + (float)a.X / Fixed.Scale / 28 * 1640 - 60, -(80 + (a.Id % 3) * 75));
                r.GetComponent<Image>().color = a.Side == Side.Player ? Blue : Red;
                string role = a.Unit == "crossbowman" ? "XBOW" : a.Unit == "shieldguard" ? "SHLD" : a.Unit == "grenadier" ? "GREN" : a.Unit == "militia" ? "MIL" : a.Unit.ToUpperInvariant();
                r.GetComponentInChildren<Text>().text = (a.Side == Side.Player ? "P " : "E ") + role + (a.Boss != null ? " B" : "") + "\n" + a.Hp + (a.Barrier > 0 ? " +" + a.Barrier : "");
                var size = r.sizeDelta; size.y = a.Unit == "ram" ? 60 : a.Unit == "brute" ? 95 : a.Unit == "shieldguard" ? 85 : 70; r.sizeDelta = size;
            }
            var ps = Model.ProjectileViews(); while (bolts.Count < ps.Length) bolts.Add(Box(lane, "Projectile", 0, 0, 14, 14, Color.yellow));
            for (int i = 0; i < bolts.Count; i++) { bolts[i].gameObject.SetActive(i < ps.Length); if (i < ps.Length) bolts[i].anchoredPosition = new Vector2(70 + (float)ps[i].X / Fixed.Scale / 28 * 1640, ps[i].Lob ? -30 : -180); }
        }
    }
}
#endif
