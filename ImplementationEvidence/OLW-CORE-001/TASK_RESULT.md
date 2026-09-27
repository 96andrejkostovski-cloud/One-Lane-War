# OLW-CORE-001 / PH01 result

**Status: PASS for the scoped PH01 implementation/build/native-load gates;
ready for Director review. Director acceptance and phase advancement remain
PENDING. No prerequisite blocker remains.**

OLW-AMEND-005 resolves the previous spawn-pressure conflict. Its canonical
reinforcement fixture and focused contact fixtures now pass. The earlier
report is preserved in [PRE_AMEND005_TASK_RESULT.md](PRE_AMEND005_TASK_RESULT.md);
[DIRECTOR_BLOCKER.md](DIRECTOR_BLOCKER.md) is historical and superseded.

## Commit and scope

- Main baseline: `c8130bfb304b40047c703b44ff3db19bc5cae89d`.
- Resume baseline / Director amendment: `5fe736af31765bb7e31f2bfb02517e9f17336bfb`.
- **Tested implementation commit: `f41126d87e77a534da977715224cf9d8ce7999ce`.**
- Branch: `codex/olw-core-001-toolchain-combat`.
- Sole repository and Unity root: `C:\Users\Andrej\Downloads\One Lane War`.
- Authority: OLW-SOURCE-1.0.0, B001 / T001 / WF002 / ARC001 / QA001,
  root amendments 001–005, Director task and issued Goal 01. The user's
  existing-Git baseline supersedes saved NONE/initialize-Git wording.
- Source manifest SHA-256:
  `6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90`.
- Amendment 005 SHA-256:
  `1ca4183a26daccc3e2a08b714e65f4fba87ada1ccde1cdfbcaa11be6a0e8ccfd`.
  Amendments 001–004 hashes remain in the historical report.

The implementation commits add the root Unity project, typed canonical
Resources projection, plain-C# deterministic combat, developer Canvas/Input
System harness, Bootstrap/Battle scenes, model/EditMode/PlayMode tests and
build/evidence tools. All six troops, both authored boss replacements and all
24 operators have fixtures; seven additional interaction fixtures measure
actual movement, paid spending and delivered damage, including mirrored
collision. The harness selects four troops, an authored encounter, up to four
eligible upgrades and seed, with 1/2/4/10x scheduling, pause/single-step,
Supply/bases, Rally, actor/damage/time diagnostics and clean capture mode.

Spawn creation alone registers hostile contact pairs. Fixed-position paid,
enemy and owed Conscription spawns succeed after the existing checks. Contact
holds both X positions, gives overlapping opponents distance/ID priority
before normal forward/base targeting, retains normal melee slots and attack
rules, and shields the base at committed impact. No B001 value was changed.

No second checkout/project, CORE-002, campaign/progression/save work,
commercial SDK initialization, spending, final media, publication, PR or merge
is included. This remains a developer placeholder foundation, not the game.

## Exact T001 investigation

The selected editor was installed and actually executed at:
`C:\Program Files\Unity\Hub\Editor\6000.3.21f1\Editor\Unity.exe`, changeset
`c02631ffc030`. Unity Personal entitlement worked for import, tests and builds.
No `.18f1` or `.25f1` editor was used as a substitute in this resumed work.

Hub registered the editor but rejected module installation because it regarded
it as a manual installation; its complete-install retry reported the existing
editor. The signed official exact-changeset Android installer was downloaded,
its metadata MD5 and Authenticode signature verified, then installed with
Windows elevation approved by the user. Matching JDK/SDK/NDK archives came
from the exact release metadata; their identities and hashes are recorded in
[installed-components.json](resume005/installed-components.json). Installation
initially hit Program Files access denial; the elevated extraction succeeded.

| Component | Actual selection |
|---|---|
| Unity | 6000.3.21f1 / c02631ffc030 |
| Bundled JDK | Temurin OpenJDK 17.0.18+8; editor-selected archive |
| java.exe SHA-256 | `5369cf92fc590944793e47cc9c9fef7955ce1a68de22ba22023cdd3513e87c2b` |
| NDK | 27.2.12479018 / r27c |
| API min / target / compile | 28 / 36 / 36 |
| SDK build tools / platform tools / command-line tools | 36.0.0 / 36.0.0 / 16.0 |
| SDK Android 36 platform | revision 2 |
| Gradle / Android Gradle Plugin | 9.1.0 / 9.0.0 |
| Player | IL2CPP, ARM64 only, OpenGLES3, built-in pipeline, landscape left/right |
| Input System / Newtonsoft | 1.20.0 / 3.2.2 |
| Editor-bound uGUI / Test Framework | 2.0.0 / 1.6.0; actual package lock committed |
| Emulator | 37.1.11.0 / build 15917651; dedicated OLW_PH01_API36 on port 5556 |
| Image | API36 Google Play x86_64 revision 7; ARM64 translation exposed |
| Native bridge / page size | libndk_translation.so / 4096 bytes |

The first exploratory APK (`resume005/android-r1.log`) built with a shared
external JDK preference (17.0.20.101), so it is **rejected as T001 evidence**.
The build entry point now temporarily selects the exact editor's bundled JDK
and restores the prior preference. `android-r2.log` confirms the corrected
executable. Final acceptance uses the separate clean build below.

Official investigation references: [Unity exact release](https://unity.com/releases/editor/whats-new/6000.3.21f1),
[release metadata](https://services.api.unity.com/unity/editor/release/v1/releases?version=6000.3.21f1),
[Google SDK metadata](https://dl.google.com/android/repository/repository2-3.xml),
[Unity JDK selection API](https://docs.unity.com/en-us/engine/6000.3/script-reference/unityeditor/android/androidexternaltoolssettings/jdkrootpath).

## Final commands and results

All commands run from the sole root unless stated otherwise. Unity commands
are recorded with UTC, actual HEAD, working status, executable, arguments,
PID and exit in each `final/*-command.txt`. Source commands run inside the
sealed source directory with `PYTHONUTF8=1`.

| Check / actual command | Result | Evidence |
|---|---|---|
| `python tools/verify_source.py` | FAIL 1135/1136, exit 1: retained known Windows separator coverage defect (AMEND-002) | [log](final/source-verifier.txt) |
| `python tools/verify_source.py --no-manifest` | PASS 837/837, exit 0; source semantics only | [log](final/source-semantic.txt) |
| `python -m unittest discover -s tests -v` | PASS 35, exit 0; reference tests only | [log](final/source-reference-tests.txt) |
| `python tools/audit_balance.py` | PASS 45,900 configurations / 367,200 unit-Rally states; zero violations; arithmetic, not battles | [log](final/arithmetic-audit.txt) |
| `python Tools/verify_sealed_source.py` | PASS 147 manifest files + 2 excluded baseline files; exact bytes | [JSON](final/sealed-source.json) |
| `git show HEAD:Assets/.../Canonical/*.json` byte comparison | PASS all six committed projection blobs equal their sealed originals | [result](final/committed-projection.txt) |
| `Tools/run-pure-tests.ps1` | PASS 80/80 at tested commit; standalone C# runtime | [log](final/pure-model.txt) |
| `Tools/run-unity.ps1 -Mode EditMode -Evidence ImplementationEvidence/OLW-CORE-001/final -Label editmode` | PASS 81/81, exit 0, zero failed/skipped | [XML](final/editmode.xml), [log](final/editmode.log) |
| `Tools/run-unity.ps1 -Mode PlayMode -Evidence ImplementationEvidence/OLW-CORE-001/final -Label playmode` | PASS 7/7, exit 0, zero failed/skipped | [XML](final/playmode.xml), [log](final/playmode.log) |
| `Tools/run-unity.ps1 -Mode Android -Evidence ImplementationEvidence/OLW-CORE-001/final -Label android-clean` | PASS Succeeded, zero errors, exit 0 | [build log](final/android-clean.log) |
| Final APK install, launch and eight native replay cases | PASS install/launch exit 0; eight matching terminal hashes | [commands](final/native-commands.txt), [logcat](final/native-logcat.txt), [validation](final/native-validation.json) |
| Actual Android touch / lifecycle / visual inspection | PASS deployment, Rally and explicit foreground resume; orientation limitation below | [inspection](final/native-inspection.md) |
| `gradle :launcher:dependencies --configuration debugRuntimeClasspath` with bundled Java/Gradle | PASS exit 0; no Firebase, AdMob or Billing dependencies | [graph](final/gradle-dependencies.txt) |
| `aapt dump badging`, `aapt dump xmltree`, `zipalign -c -P 16 -v 4`, `apksigner verify --verbose --print-certs`, NDK `llvm-readelf -l` | PASS all exits 0; ARM64 only; six native libraries; all LOAD alignment >= 16384 | [exits](final/apk-check-exits.txt), [ELF](final/elf-alignment.json), [signing](final/apk-signing.txt) |

The clean-build preparation restored committed Assets/Packages/ProjectSettings/
Tools in place after proving they had no changes, with no Unity process using
this root. Previous Library and APK were isolated inside ignored Builds; Temp
was absent. The separate generated `.utmp` GameActivity cache was discovered
and isolated before Gradle started, after checking it was not in use. This is
the single-root clean reconstruction required by the owner's no-second-project
constraint. [Exact preparation receipt](final/clean-root-preparation.txt).

## Replay, native and visual evidence

Expected terminal replay: tick **1152**, **PlayerWin**, SHA-256
`7aa8d88bcf7f4ad6759c53d377e0754e9032aeca7468d0885e66dab68f37f533`.
The pure runner and PlayMode harness use the same tick-stamped deployment/Rally
stream. PlayMode paints real Unity frames while feeding scheduled 30/60-FPS
intervals, and compares directly with a plain-C# stepped run. It does not
claim those injected intervals are measured hardware frame rates.

The final APK completed all eight requested frame-rate/speed runs with that
same hash in native process **8485**, with `OLW_NATIVE_PROOF_ALL_PASS runs=8`.
Actual measured rates were **24.33–32.77 FPS**, below requested 30/60; this is
determinism/load evidence, not a target-frame-rate or physical-phone PASS.
The log and `/proc/8485/maps` prove Unity 6000.3.21f1, ARM64 IL2CPP/Unity and
OpenGLES3 through `libndk_translation.so` loaded. The API36 image fingerprint
is `google/sdk_gphone64_x86_64/emu64xa:16/BE2A.250530.026.D1/13818094:user/release-keys`;
`ro.product.cpu.abilist=x86_64,arm64-v8a`. This is actual compatible ARM64
translation, not an inference from an x86 emulator screenshot.

All **17 final runtime PNG captures** were pulled successfully. Inspected
[configuration](final/native-captures/configuration.png),
[battle](final/native-captures/battle-30-1.png) and
[clean](final/native-captures/clean-30-1.png) show the real Canvas and actor HP,
with no development error console. Clean capture removes harness diagnostics;
Unity's Development Build watermark remains. Friendly actor labels can overlap
when many actors crowd the terminal scene; this is a placeholder, not final UX.
Actual taps deployed a paid Militia and activated Rally after its cooldown.
Background/foreground returned PAUSED at tick 91; screenshots three seconds
apart are byte-identical, and explicit resume advanced combat. Both landscape
orientations were observed on separate cold launches; live emulator sensor
changes did not rotate this running player. That supplementary check is
**NOT PROVEN**, not a live-rotation PASS. See the exact inspection record.

The preliminary run encountered Android's first-run full-screen hint and a
System UI ANR; choosing Wait recovered it. Those failed/stalled captures are
retained as history and are not the final native-load evidence.

Actual visual inspection then found Android ScreenCapture incorrectly
receiving an absolute filename (Unity prefixed persistentDataPath again),
opening the development error console. It also found long actor labels
hiding HP. Both ordinary defects were fixed before the tested commit: Android
uses relative capture names and compact role labels. Final recapture passed;
preliminary screenshots are retained only as failure/repair history.

## Failure and repair history

- Known canonical spawn rejection/overlap conflict: resolved strictly by
  AMEND-005; replaced failing fixture and added contact regressions.
- Hub module-registration rejection and Program Files permissions: exact
  official component installation, no editor/version substitution.
- PlayMode r1: six original cases passed. Added synthetic input case then
  exposed fixture ordering/isolation errors in r2–r12. r5 additionally found
  the missing built-in ScreenCapture module; repaired in the manifest.
  r12's incorrect setup order destroyed scene references; retained as FAIL.
  Explicit InputTestFixture setup before scene/action creation fixed this;
  r13 passed all seven, including input press/release and duplicate cooldown.
- New Ram interaction expected HP was initially wrong (560); the sealed
  420 × (1 + .25 + .10) gives 567. Corrected test, no balance change;
  final pure suite passed 80/80.
- First APK used a host JDK override; rejected for T001, corrected and rebuilt.
- New emulator refused to share the existing running AVD and rejected a 2048-MB
  partition option. Created a dedicated AVD and used its supported option.
  The original emulator on port 5554 was never closed or modified.
- Native first-run System UI stall and screenshot-path/label issues are
  described above, with raw failed runs retained under `resume005/`.

## QA mapping and review gate

| QA ID | Scope / evidence | Final status |
|---|---|---|
| QA-082 | Single-root clean reconstruction and exact T001 Android build | PASS; clean-build receipt and final Android log |
| MIG-QA-001 | Manifest, 147+2 byte checks and committed projection | PASS |
| MIG-QA-003 | Core-only manifest/source and resolved Android dependencies; no real commercial initialization | PASS; package lock, manifest and resolved Gradle graph reviewed |
| MIG-QA-004 | Three slots, reserve turnover, contact reserve exclusion | PASS model fixtures |
| MIG-QA-005 | Opposing proportional clamp, unequal-speed mirror, no movement-created contact | PASS model fixtures |
| MIG-QA-006 | No projectile travel on release tick; release/death/sweep cases | PASS model fixtures |
| MIG-QA-007 | Due impacts before tick4200 finish, exact tick3600 cutoff | PASS model fixtures |
| MIG-QA-009 | Atomic same-tick cost/cooldown and native/Unity input | PASS model/PlayMode fixtures plus final native deployment and Rally taps |
| MIG-QA-041 | ABI/bridge inventory plus actual IL2CPP load and gameplay | PASS final ARM64 APK on compatible translated API36 image |

[Review record](final/implementation-review.txt): primary-agent source/diff
review, not an independent audit. No native standalone general code-review
tool was available, and no subagent was authorized. Director acceptance is
separate and pending. Source checks and arithmetic are not runtime approval.

No claim is made for physical-phone performance, every AVD row, API28 native
execution, 16-KB runtime execution, release signing, store distribution, full
campaign balance or later-phase UX. Live landscape switching on this emulator
remains unproven; both allowed orientations are selected in the project and
load on cold launch. The scoped PH01 packet is ready for Director review;
CORE-002 remains unissued.

## Git handoff and artifact identity

The designated origin was reverified as public
`96andrejkostovski-cloud/One-Lane-War`, with authenticated push access,
default/main at the requested baseline, no rulesets, and the scoped remote
branch at `5fe736a…`. [Read-only verification](final/remote-before-push.txt).
Normal push of tested `f41126d87e77a534da977715224cf9d8ce7999ce` succeeded
(exit 0), and remote readback matches; main remains `c8130bfb…`.
[Push receipt](final/tested-commit-push.txt),
[remote readback](final/remote-after-tested-push.txt).

Final local APK: `Builds/Android/OneLaneWar-PH01.apk`, **40,654,258 bytes**,
SHA-256 `18d8c724a21b30fc8dcd6e1d636331edb62f08e7d21581c1058eb2df42feee30`.
[Artifact and native-library hashes](final/artifact.json). The APK/installers,
SDK caches and unredacted logs stay in ignored local Builds, not public Git.
All six ARM64 ELF libraries and the APK ZIP passed 16-KB alignment inspection;
the actual runtime image uses 4-KB pages, so this is not 16-KB runtime proof.

Before public handoff, 21 new logs had Unity licence/account identifier lines
redacted. Original bytes remain locally in `Builds/RawEvidence`; their hashes
and published hashes are in [redactions.json](final/redactions.json). Test
outcomes, failures, commands and tool versions remain intact. The evidence
manifest hashes the published bytes and excludes itself and the local receipt.

The evidence follow-up must leave Assets/Packages/ProjectSettings/Tools
identical to tested `f41126d…`. Its only non-evidence adjustment is ignoring
Unity's generated `.utmp` directory. The final receipt records the evidence
commit and verified remote ref without pretending this report contains its
own self-referential commit SHA.
