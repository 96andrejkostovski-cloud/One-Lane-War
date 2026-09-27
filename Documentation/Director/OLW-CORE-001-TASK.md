# OLW-CORE-001 — Toolchain and placeholder combat foundation

**TASK ID:** OLW-CORE-001
**PURPOSE:** Prove the selected Unity/Android toolchain and deliver a
testable, deterministic placeholder combat foundation for all six troops,
all 24 upgrade operators, and authored encounters.
**WORKSPACE / REPOSITORY / UNITY PROJECT ROOT:**
`C:\Users\Andrej\Downloads\One Lane War`
**SOURCE PACKAGE:**
`C:\Users\Andrej\Downloads\One Lane War\One_Lane_War_Codex_Source_v1.0.0`
**ACTIVE SOURCE VERSION:** OLW-SOURCE-1.0.0 with OLW-AMEND-001 through
OLW-AMEND-004; B001, T001, WF002, ARC001, QA001.
**SOURCE MANIFEST SHA-256:**
`6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90`
**CURRENT PHASE:** PH01, NOT_RUN.
**STARTING COMMIT:** NONE; this root is not yet a Git repository. Record
the actual baseline commit after local initialization.
**BRANCH:** Create a scoped local branch such as
`task/OLW-CORE-001-toolchain-combat` from the recorded baseline.
**DESIGNATED REMOTE:**
`https://github.com/96andrejkostovski-cloud/One-Lane-War.git` (owner supplied;
verify identity, visibility, refs and access before writing).

## Authority and prerequisites

Read the root `AGENTS.md`, all four root amendments, and the imported
`START_HERE.md`, `SOURCE_AUTHORITY.json`, `AGENTS.md`,
`tasks/OLW-CORE-001.md`, Bibles 00, 01, 02, 03, 07, 08, 14, and 15.
Read canonical `data/game_rules.json`, `units.json`, `upgrades.json`,
`encounters.json`, `boss_variants.json`, `toolchain_lock.json`,
`test_matrix.json`, and applicable `contracts/` and QA fixtures. Read
`records/DECISIONS.jsonl` and `records/SUPERSESSIONS.json`; historical
archives and generated visual references are not gameplay authority.

First inspect the root, Git state, host, Unity installation/licence,
Android modules, SDK, NDK, JDK, devices, emulator images, ABI support,
and available disk space. Run the supplied source/reference checks from
the source-package directory. Preserve the Windows verifier failure as
described in OLW-AMEND-002; produce a reviewed root-level normalized
manifest validation helper without editing sealed source files. Record
the source and amendment hashes before coding.

**Director preflight snapshot (2026-09-27, path checks only):** The root
has no Git repository or Unity project. Unity Hub lists `6000.3.25f1`,
while selected `6000.3.21f1` was not present at the standard Hub path.
The installed editor has AndroidPlayer, SDK platform 36, build tools
36.0.0, and NDK `27.2.12479018`; its expected `AndroidPlayer/OpenJDK`
path was absent. The separate Android SDK has build tools 36.0.0 and
an emulator, but its platform 36 and selected NDK were not at their
usual paths. This is an inventory snapshot, not toolchain proof. Check
actual executable locations, Unity licence, resolved dependencies,
build output, and ABI before changing any pin. If exact T001 components
can be installed under the task's local permissions without spending,
use and prove them. Otherwise preserve the failure and propose the
smallest T002 change for Director review; do not silently use `.25f1`.

## In scope and required implementation

1. Initialize **local** Git at the main root if absent. Add an appropriate
   Unity `.gitignore` and an initial source/amendment baseline. Keep the
   sealed imported package intact. Create Unity's `Assets/`, `Packages/`,
   and `ProjectSettings/` **directly in the main root**. Do not create
   `Game/` or `UnityProject/`.
   Verify the owner-supplied GitHub repository read-only before adding
   `origin`. If it is genuinely blank and the exact identity, visibility,
   write access and branch rules are confirmed, push the reviewed
   baseline and the scoped task branch normally. Record remote refs and
   pushed SHAs. Do not force-push, overwrite history or merge.
2. Prove the exact T001 core selection: Unity 6000.3.21f1
   (`c02631ffc030`), Android support, bundled OpenJDK 17, NDK
   27.2.12479018, API 28/36/36, IL2CPP ARM64, OpenGLES3, built-in 2D,
   landscape left/right, Input System 1.20.0, Newtonsoft JSON 3.2.2,
   and editor-bound uGUI/Test Framework. Capture actual resolved
   versions and package lock. If any selected combination fails, record
   the minimal reproduction and propose T002; do not silently substitute.
3. Import canonical JSON through a typed, validated content path with
   stable IDs and source hash. Invalid IDs/references fail clearly. Do
   not hand-maintain a second set of balance numbers.
4. Implement plain-C# 20 Hz authoritative combat separated from Unity
   views. Include deterministic command/tick ordering, integer/fixed
   numerical rules, Supply and deployment, three melee engagement slots,
   frontline collision and blocking, melee/ranged/projectile/splash
   attacks, damage/barriers, all six troops, both boss variants where
   authored, Rally, overtime, enemy queue cutoff, hard finish and draw.
   Animation, physics, audio and VFX never award gameplay state.
5. Implement each of the 24 B001 upgrade operators, including behavior
   operators and their interactions, using actual model fixtures.
6. Build a developer-only placeholder battle harness: four-unit loadout,
   real encounter selection, up to four eligible upgrades, seed,
   1×/2×/4×/10× scheduling, pause/single-step, bases, Supply, unit
   controls, Rally, tick/time, actor counts, damage diagnostics, and
   optional formation overlays. Provide a clean no-debug capture path.
7. Produce pure-model, Unity EditMode and PlayMode tests, an Android
   build, and actual native install/load/capture evidence when the host
   supports a compatible ABI. Preserve exact blockers otherwise.

## Out of scope and forbidden changes

No full campaign, production Draft/Shop, progression or final save system
in this task; those belong to later packets. Do not alter B001 numbers,
T001 pins, WF002 order, core UX, monetization, or gameplay scope without
a numbered amendment. Do not edit or flatten the imported source package.
Do not create a second project or repository, change other games, push
to any remote except the verified URL above, force-push, merge, deploy
services, spend money, generate final
Higgsfield/Suno/ElevenLabs media, integrate real Firebase/AdMob/Billing,
register products, or publish. Use fake/unavailable service interfaces
only where needed to keep the offline core testable.

## Acceptance criteria and required tests

- The main root is both Git and Unity root; source package remains
  byte-identical. No nested `Game/` or `UnityProject/` exists.
- All six troop mechanics, both authored boss variants and all 24
  operators pass actual C# model fixtures. Encounter selection loads
  actual canonical queues and declared values.
- Identical tick-stamped command streams produce identical state and
  outcome hashes at 1×/2×/4×/10× and differing render rates.
- Cover empty field, deployment cost/cap/cooldown, three-slot turnover,
  opposing movement, blocking, projectile release/target death/sweep,
  ground splash, barrier first hit/expiry, Rally boundaries, same-tick
  deaths, overtime, 180-second queue cutoff, and 210-second finish/draw.
- Run source verifier with its actual exit, semantic/reference tests,
  arithmetic audit, normalized full-manifest check, C# pure-model tests,
  EditMode/PlayMode tests, clean-checkout build, and mapped QA IDs
  QA-082, MIG-QA-001, -003, -004, -005, -006, -007, -009, -041.
- Build Android with selected native ABI; install, launch, and capture
  from a compatible emulator/device. Record image revision, fingerprint,
  `ro.product.cpu.abilist`, native load and logs. An incompatible x86
  image is BLOCKED for ARM64 proof, never PASS. Do not use an emulator
  screenshot as physical-device evidence.

## Required build evidence and documentation

Write `ImplementationEvidence/OLW-CORE-001/TASK_RESULT.md` using the
source template. Include baseline/final exact commits, branch, source
manifest and amendment hashes, changed paths, host/editor/SDK/NDK/JDK
identity, package lock, commands and exit codes, test counts and logs,
QA case outcomes, state/replay hashes, screenshots or recordings, build
artifact SHA-256, ABI proof, verified remote identity/visibility/refs,
push results or exact remote blocker, unresolved findings, and a clear PASS/FAIL/
BLOCKED/NOT_RUN status for each claim. Keep actual results separate from
source validation and arithmetic checks. Review the final exact HEAD;
if a native review is unavailable, label the alternative review plainly.

## Stop condition

Stop when the scoped acceptance packet is ready for Director review, or
when a reproducible prerequisite blocks completion. Preserve successful
evidence and report the exact blocked action. Do not start OLW-CORE-002,
integrate commercial services, generate final media, or advance a phase
automatically.
