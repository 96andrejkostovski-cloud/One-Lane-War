# One Lane War — sequential Astra build plan

**Status:** PH01 accepted by Director on 2026-09-28. Goal 02 remains an
explicit next assignment, not an automatic continuation. **Plan date:**
2026-09-27. See `OLW-CORE-001-DIRECTOR-REVIEW.md` for exact commit and limits.

## 1. Fixed authority and present state

- **Workspace, Git and Unity root:** `C:\Users\Andrej\Downloads\One Lane War`.
  Unity `Assets/`, `Packages/` and `ProjectSettings/` go directly here.
  There is no `Game/`, `UnityProject/` or second authoritative checkout.
- **Imported source:** `One_Lane_War_Codex_Source_v1.0.0/` remains intact.
  Its `SOURCE_MANIFEST.json` SHA-256 is
  `6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90`.
  OLW-AMEND-001 through 005 correct location, source navigation,
  designated remote, prompt batching and fortress-pressure spawning.
  B001 numbers, T001 pins, WF002, V001, A001 and S1 retain their source meanings.
- **GitHub destination:**
  `https://github.com/96andrejkostovski-cloud/One-Lane-War.git`.
  The baseline and scoped PH01 branch were pushed normally and verified;
  `main` remains at the baseline. Verify refs again before each future push.
  Never clone it as a second project or overwrite remote history.
- **Runtime status:** PH01's root Unity project, exact T001 Android build
  and compatible native replay evidence are accepted at the implementation
  commit in the Director review. PH02 and later gates remain NOT_RUN. Live
  emulator rotation and physical-device performance remain unproven.
- **Source checks already done:** 147/147 sealed-file hashes and sizes
  match; 35 reference tests, 837 non-manifest semantic checks and the
  arithmetic audit pass. The original full verifier fails one Windows
  separator comparison; OLW-AMEND-002 preserves that failure and
  requires normalized coverage proof. None of these are game tests.

The imported task packets are the complete coverage list. This plan
changes how many times Astra is prompted, not what the game must prove.
Read the relevant Bible and canonical JSON when that area is being
built. Historical ZIPs, generated catalogues and V001 reference images
do not override active rules.

## 2. Why six Astra Goals

Use **one Astra High implementation chat** anchored to the main root.
Create one persistent Goal for each numbered assignment below, finish
and verify it, then start the next Goal in the same chat after Director
review. A Goal should continue through implementation, tests, build,
inspection and repair within its scope. Do not send a new prompt just
because a test failed or Unity returned an ordinary fixable error.

Six Goal kickoffs cover ten build/release task packets. PH07's
OLW-PRES-001 is a Director and owner visual-decision gate using real game captures; it is
not another coding kickoff. OLW-OPS-001 follows launch as separately
authorized operating work. Corrective messages, owner approvals and
external waits cannot honestly be guaranteed to fit a fixed count.

This grouping follows official OpenAI guidance: Astra can handle long,
multi-step coding work, while a durable, scoped Goal keeps a verifiable
finish line across turns. A repository plan and evidence files carry
state across a long build. Repeated giant prompts and instructions to
read the full repository before every edit add context cost and can
make Astra stop early. Sources:
[Astra prompting](https://developers.openai.com/blog/rethinking-skills-and-prompts-for-gpt-6-astra),
[Goals in Codex](https://developers.openai.com/cookbook/examples/codex/using_goals_in_codex),
[long-horizon Codex work](https://developers.openai.com/blog/run-long-horizon-tasks-with-codex).

The six Goal texts are in `ASTRA_GOAL_PROMPTS.md`. Each names the exact
packets it issues. OLW-AMEND-004 permits internal continuation only
between packets listed in the *currently issued* Goal. It grants no
automatic progression into the next Goal.

## 3. Execution method for every Goal

1. **Read the current state.** Inspect Git status, exact HEAD, source
   manifest/amendments, prior evidence, relevant packet and its Bibles.
   Preserve existing work. Keep the root as the sole project checkout.
2. **Make a short internal checklist.** Work through the listed packets
   in dependency order. A packet gets its own commit(s), test/build
   evidence and `ImplementationEvidence/<TASK-ID>/TASK_RESULT.md`.
   A grouped Goal may use one scoped branch, with distinct packet
   commits and exact-head evidence at each boundary.
3. **Build → run → inspect → repair.** Astra should continue through
   ordinary compilation and test failures within the issued scope.
   Repeat affected tests after a fix. Avoid broad reruns that have no
   remaining risk to resolve.
4. **Check real behavior.** Source validation, pure model tests, Unity
   tests, Android native load, screenshots, real SDK test traffic,
   physical-device use and human play are separate evidence classes.
   Mark every claim PASS, FAIL, BLOCKED or NOT_RUN against its own proof.
5. **Review exact code.** At each packet boundary, record the tested
   commit and review that HEAD. Final Director review checks the full
   Goal diff, source compliance, logs, game output and unresolved issues.
   New commits invalidate the affected earlier review/test evidence.
6. **Push safely.** Only the designated remote may be used. Verify refs,
   visibility and authentication first; push normal branches without
   force. A PR, if used after the local result is reviewable, remains
   open for independent review. No automatic merge.
7. **Stop on a real gate.** A T001 incompatibility needs a documented
   T002 decision; numerical correction needs B002; service activation,
   paid provider generation, final visual selection, signing and public
   release need their applicable owner decision. Keep completed work and
   report the exact missing input. Continue unrelated work inside the
   issued Goal where the dependency graph allows it.

No model can guarantee zero defects. The quality target is that a phase
cannot pass on a plausible-looking build or a test claim alone. It
passes on reproducible exact-head evidence and Director review.

## 4. Sequential build route

| Step | Astra Goal / source packets | What exists at exit | Advance only when |
|---|---|---|---|
| 0 | Director intake, before Goal 01 | Source and amendment hashes, local/remote state and T001 preflight recorded | Root/source identity confirmed; no duplicate project |
| 1 | **Goal 01:** PH01, OLW-CORE-001 | Git/Unity at main root; typed content import; deterministic 20 Hz model, six troops, 24 operators, encounter harness; Android build evidence | Pure C#/EditMode/PlayMode, replay determinism and compatible native load pass, or exact blocker is resolved |
| 2 | **Goal 02:** PH02→PH03→PH04, OLW-CORE-002 → OLW-CORE-003 → OLW-CORE-004 | All nine expeditions/36 encounters, six main views, S1 saves and economy; actual-model balance evidence; functional UX and recovery | Full no-ad/no-purchase route, model-vs-game hashes, 15-loadout/36-encounter policy evidence, save/input/accessibility cases and human play observations pass |
| 3 | **Goal 03:** PH05→PH06, OLW-INT-001 → OLW-CAP-001 | Approved real test services and analytics; accepted content-complete placeholder build; 28 raw captures | Actual test ads/purchases/consent, network and manifest audit, 35-event transport, full playthrough, raw capture sidecars and placeholder acceptance pass |
| 4 | **Director/owner PH07:** OLW-PRES-001 | Real-capture-based target comparisons and owner-selected P001 | Owner approves exact visual targets; changed HUD, role or mechanics are rejected |
| 5 | **Goal 04:** PH08→PH09, OLW-ART-001 → OLW-PRES-002 | Rights-logged final visual/audio catalogue integrated into working game | Three-unit animation proof precedes catalogue; asset/audio approvals, matched captures, unchanged model hashes, crowded performance and regression pass |
| 6 | **Goal 05:** PH10, OLW-REL-001 | Release-candidate AAB, symbols, Play test evidence, documents, store materials, closed-player findings | Exact AAB/HEAD and physical Play-installed test pass; mandatory inputs and blocking defects closed; owner has a complete publication packet |
| 7 | **Goal 06:** PH11, OLW-REL-002 | Owner-approved production release in the six source countries | Owner approves exact AAB, countries, products, identity and public documents before submission; actual store state and installed build verified |
| 8 | After launch, OLW-OPS-001 | Specific health, support, accounting, update and recovery work | Each operating action is separately authorized and measured from real data |

### Goal 01: toolchain and combat foundation

Use `Documentation/Director/OLW-CORE-001-TASK.md` as the detailed first
packet, corrected by OLW-AMEND-001 through 004. Confirm the GitHub
remote again. If T001's exact Unity editor or native test route is
unavailable, investigate the exact failure and compatible resolution;
do not silently build with 6000.3.25f1. Keep any pure-model work that
does not depend on the missing editor, but do not mark PH01 PASS from
source tests or an incompatible x86 emulator.

### Goal 02: full placeholder game, balance and resilience

Sequence CORE-002 before CORE-003 and CORE-004. Preserve B001 during
first implementation. Use the *same* C# CombatModel for headless policy
runs; audit all 15 loadouts and 36 encounters and distinguish normal
campaign routes from analysis-only unlocked routes. A balance change
requires an exact B002 amendment, before/after outcomes and regressions;
the Director decides that amendment. Finish real S1 recovery, four
drafts/run, Medals, unlocks, rerolls, all functional screens, pause,
background, touch, safe area and accessibility cases. No final media or
real SDK integration here. Human play observations must come from actual
players; Astra prepares the build and records their results, and labels
that acceptance item BLOCKED if no player session has occurred.

### Goal 03: test services and accepted placeholder captures

Start only after approved service identities, credentials, test accounts,
cost limits and deployment permission exist. Implement genuine test
purchase verification/refund/restore and rewarded ads, UMP, analytics
transport, redacted diagnostics and the merged-manifest/network audit.
Only then close PH06 against the whole placeholder game. Capture the 28
specified real states with native files, hashes and sidecars; do not
label a generated reference as runtime output. External inputs missing
for PH05 keep that phase and PH06 BLOCKED, while completed local
evidence remains available.

### PH07: visual target decision

Use the actual CAP-001 screen geometry and V001 style. Create only the
authorized target variations. Compare raw game screen → target →
planned modular implementation, including numbers, troop roles and
controls. The owner chooses the final visual target. Freeze P001 with
the exact approval scope before provider production.

### Goal 04: final assets and presentation

Start after PH06 acceptance, P001 approval and explicit generation
budget/rights approval. Make Militia, Crossbowman and Ram segmented
art and six-state in-game animation proof first. Expand to the 148
planned asset families and specified music/SFX only if the proof works.
Track provider, licence, prompt, source, revisions, runtime export,
hash and approval for every final asset. Integrate modular sprites,
cutout animation, UI, VFX and audio into the tested game. Compare
matched captures and repeat model hashes, safe-area, 24v24, memory,
performance and audio-focus checks. No flattened screen image replaces
live UI.

### Goal 05: release candidate and closed validation

Recheck current Google Play, Android and SDK requirements from official
sources **at this phase**. Resolve actual title, production package ID,
publisher identity, rights, support/privacy pages, consent inventory,
Data Safety, IARC, products and signing through the owner-controlled
inputs. Produce the exact AAB, symbols/mapping and build manifest.
Test a Play-installed build on a physical ARM64 phone, native ABI/16 KB
cases, offline campaign, services, purchases/restores and accessibility.
Observe unfamiliar closed players; separate their usability feedback
from mature retention metrics. Prepare truthful store captures and an
exact publication packet. Do not submit to production in this Goal.

### Goal 06: first Google Play production

This Goal is issued only after the owner approves the exact Goal 05
AAB hash, countries, prices/products, public text, signing action and
publication. Submit the approved artifact to United States, United
Kingdom, Canada, Australia, New Zealand and Ireland only. Verify the
actual published state, store-installed version and live support and
commercial-service readiness. Preserve release evidence and hand off
the operating runbook. No paid acquisition is included.

## 5. Gate discipline and plan change rules

- A Goal may contain several task packets; every packet still has its
  own measured evidence and immutable tested commit. The next Goal
  requires Director review of the current exact HEAD and open findings.
- Ordinary bug fixes within a Goal do not need another user prompt.
  New features, B002/T002/A002/S2 changes, production spend and owner
  approvals remain explicit numbered decisions.
- A BLOCKED row retains its exact attempted command, error, environment
  and impact. A blocked Android row does not erase passing pure-model
  tests; passing pure-model tests do not close Android proof.
- Every final game, visual, service and release assertion is checked on
  the actual built artifact. When a build changes, rerun only affected
  evidence and review the new exact head.
- The plan may need more than six Goal kickoffs if a genuine source
  contradiction, provider limit, Play review outcome or hardware
  blocker requires a new scope. Prompt count is an efficiency target,
  never a reason to waive the gate.

## 6. Next action

PH01 has passed Director review. Issue **Goal 02 only** to the existing
Astra High implementation chat, using `ASTRA_GOAL_PROMPTS.md` and the
PH01 Director review. The Director reviews Goal 02's packet evidence
before Goal 03. No work in Goal 03–06 is authorized by this plan alone.
