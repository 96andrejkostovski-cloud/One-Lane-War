# OLW-CORE-001 / PH01 result

**Status: BLOCKED — Director source decision required. PH01 is NOT PASS.**

The actual canonical first encounter reproduces conflicting spawn and
collision requirements. At tick 582, a legal paid Militia deployment at
x=0.800000 overlaps an enemy Militia attacking the fortress at x=0.825000.
Their required body separation is 0.500000. The failed test is retained;
no spawn-rule exception, numerical change, or numbered amendment was
silently applied. See [DIRECTOR_BLOCKER.md](DIRECTOR_BLOCKER.md) for source
fields, reproduction, and two unapproved resolution options.

## Identity and authorization

- Source: OLW-SOURCE-1.0.0; B001 / T001 / WF002 / ARC001 / QA001, plus
  OLW-AMEND-001 through 004.
- Sealed manifest SHA-256:
  `6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90`.
- Actual starting baseline: `c8130bfb304b40047c703b44ff3db19bc5cae89d`.
  The issued user Goal supersedes the saved task/prompt's stale NONE text.
- **Final tested implementation commit:**
  `53051512a99774f974ae335c3ffff77cb3462646`.
  [Exact-head test log](logs/pure-tests-exact-head.txt) records that SHA.
- Branch: `codex/olw-core-001-toolchain-combat`.
- Sole workspace/repository: `C:\Users\Andrej\Downloads\One Lane War`.
  Implementation files are under root `Assets/`; no `Game/`,
  `UnityProject/`, secondary checkout, or competing source was created.
  Full Unity project initialization is **incomplete**: no fabricated
  `Packages/packages-lock.json`, ProjectSettings, scene or build is supplied.
- This report and logs are an evidence-only follow-up to the tested
  implementation commit. They do not change its C# or Tools files. The
  final handoff commit is identified by Git and the final delivery message;
  this file does not pretend to contain its own self-referential SHA.
- Owner requested Astra Goal 01 only. Model selection/reasoning UI was
  not independently inspected. No independent reviewer or subagent ran.

Amendment SHA-256 values, recorded before coding:

| Amendment | SHA-256 |
|---|---|
| 001 | `aed8a3cd8394f55d71e4a4b5e008e9a130ce67cede3501c3efebb288bad24deb` |
| 002 | `33444cd4cc77af87883cd0a9930cbd587274aa6822850048e2c8813ec404f5ee` |
| 003 | `b3c2a8c226f7e96778be8f74ba93a6fa91fffe46965d65f76d229f1830cf2ef5` |
| 004 | `69f02358f49cffc429d9f87fcc6ecc2a461c4d08b766f96ecc5533c814f69859` |

## Scope completed and incomplete

Implemented a **partial, unaccepted** Unity-independent C# content/model
foundation: byte-hash validated typed import of the five combat registries,
stable content IDs, fixed-point arithmetic, tick commands, Supply, finite
enemy queues and authored boss replacements, formations/movement,
melee/bolt/ground-lob damage, barriers, the 24 upgrade definitions, Rally,
overtime/cutoff/finish, pause reasons, scheduling and ordered state hashes.
The 65-fixture runner uses that same source, not a Python combat simulator.
Its failed collision requirement prevents calling this a completed model.

The following are **NOT_RUN / incomplete**, not delivered capabilities:
the developer Unity harness and no-debug capture path, Unity EditMode and
PlayMode runners, real render-rate checks, Input System controls, Unity
scene lifecycle/background tests, Android build, clean-checkout rebuild,
native installation/load, screenshots and recordings. Scheduling fixtures
use simulated frame intervals; they are not rendered Unity sessions.
Several upgrade cases assert resolved model statistics; this is not a
claim that every required interaction has been demonstrated in-game.

Changed implementation paths at the tested commit:

- `Assets/OneLaneWar/Core/{Content.cs,CombatModel.cs,AssemblyInfo.cs,OneLaneWar.Core.asmdef}`
- `Assets/OneLaneWar/Tests/Fixtures/{ModelFixtures.cs,OneLaneWar.ModelFixtures.asmdef}`
- `Tools/{verify_sealed_source.py,run-pure-tests.ps1,PureTestRunner.cs,collect-core001-environment.ps1}`

The remaining changes are this evidence directory. The existing root
`.gitignore`, source package, source amendments, main branch and other
games were preserved. Commercial SDKs, services, provider generation,
spending, publication and CORE-002 were not started.

## Commands and actual evidence

Unless noted, working directory is the workspace root. Source commands
ran from `One_Lane_War_Codex_Source_v1.0.0` with `PYTHONUTF8=1`.

| Command | Exit | Result | Evidence |
|---|---:|---|---|
| `git status --short --branch`; `git rev-parse HEAD`; `git remote -v` | 0 | Clean main at requested baseline; designated origin | Initial session output; identities above |
| `git switch -c codex/olw-core-001-toolchain-combat` | failed, then 0 with filesystem escalation | Initial sandbox could not create ref directory; authorized retry created scoped branch | Session output; actual branch |
| `python tools/verify_source.py` | 1 | **FAIL**, 1135/1136; known Windows separator coverage defect | [source-verifier.txt](logs/source-verifier.txt) |
| `python tools/verify_source.py --no-manifest` | 0 | **PASS**, 837/837 semantic checks only | [source-semantic.txt](logs/source-semantic.txt) |
| `python -m unittest discover -s tests -v` | 0 | **PASS**, 35 reference tests; not runtime | [source-reference-tests.txt](logs/source-reference-tests.txt) |
| `python tools/audit_balance.py` | 0 | **PASS**, 45,900 arithmetic configurations, 367,200 unit/Rally states, zero violations; not battles | [arithmetic-audit.txt](logs/arithmetic-audit.txt) |
| `python Tools/verify_sealed_source.py` | 0 | **PASS**, 147 manifest files plus 2 excluded files compared byte-for-byte with baseline | [sealed-source-exact-head.txt](logs/sealed-source-exact-head.txt) |
| `Tools/run-pure-tests.ps1` initial run | 1 | Compiler missing netstandard facade reference; ordinary tooling defect repaired | [pure-tests-initial.txt](logs/pure-tests-initial.txt) |
| `Tools/run-pure-tests.ps1` after compiler repair | 1 | 64 PASS / 1 FAIL; initial synthetic spawn-pressure fixture | [pure-tests-r2.txt](logs/pure-tests-r2.txt) |
| `Tools/run-pure-tests.ps1` canonical reproduction | 1 | 64 PASS / 1 FAIL; unchanged authored encounter confirms conflict | [pure-tests-canonical-repro.txt](logs/pure-tests-canonical-repro.txt) |
| `Tools/run-pure-tests.ps1` at `5305151…` | 1 | **64 PASS / 1 FAIL / 65 total** at exact recorded implementation commit | [pure-tests-exact-head.txt](logs/pure-tests-exact-head.txt) |
| `git diff --check`; `git diff --cached --check` | 0 | Formatting only, not gameplay evidence | Session output |
| `git diff --exit-code 5305151… -- Assets Tools` | 0 | Working code/tools equal tested commit | Session output; Git history |
| `git diff --exit-code c8130bf… -- One_Lane_War_Codex_Source_v1.0.0` | 0 | No tracked source changes; normalized checker also verifies full coverage | Session output; sealed checker |

The source/reference checks preceded the implementation commit and their
scope remained byte-identical; the normalized full-byte check and C# suite
were rerun at the exact implementation commit. None is promoted to Unity
or native evidence. Inspect each log's inner `EXIT`: an outer PowerShell
command that prints a log can return 0 while the tested command failed.

## Toolchain and native inventory

See [environment.txt](logs/environment.txt). Host: Windows 10.0.26200,
x64. Initial disk free was 66,141,188,096 bytes; later inventory recorded
53,717,381,120. Initial WMI OS query was denied by the sandbox; the runtime
OS/architecture query succeeded. No license file contents were read.

T001 `6000.3.21f1 / c02631ffc030` was absent at both checked editor roots.
[Unity's official release page](https://unity.com/releases/editor/whats-new/6000.3.21f1)
provides that exact release. After inspecting Hub's CLI, attempted:

```powershell
& 'C:\Program Files\Unity Hub\Unity Hub.exe' -- --headless install --version 6000.3.21f1 --changeset c02631ffc030 --module android --childModules
```

The sandbox-only CLI help initially failed writing Hub preferences; the
approved retry succeeded. [Hub help](logs/hub-help.txt) and
[actual install progress](logs/hub-install-t001.txt) are retained.
After the source blocker was confirmed, stopped the exact task-owned
headless Hub process PID 49024; its recorded exit is -1 (cancelled, not
installed/PASS). Vendor download cache was preserved. The already-started
child `UnitySetup64-6000.3.21f1.exe`, PID 50920, remained present.
`Stop-Process -Id 50920` failed with **Windows Access is denied**, even
outside the sandbox. This was an OS permission failure, not an automatic
approval-review rejection. No other Unity/editor process was stopped.
The final process receipt records whether it is still pending. The
installer may require local user dismissal/completion; no license, editor
launch or installed state is inferred from its process or folder.

Existing `.25f1` and `.18f1` editors were inventoried but **not launched
as replacement Unity editors**. For independent pure C# fixtures only,
the runner uses existing `.18f1` Mono 6.13.0, `csc.exe`, and its managed
Newtonsoft DLL, with binary hashes recorded in the exact-head log.
This is **not T001 package/editor/runtime compatibility proof**.
The `.25f1` Android installation reports NDK 27.2.12479018, API 36 and
build tools 36.0.0; its bundled JDK path is absent. No `.21f1` resolved
package lock, JDK hash/patch, Gradle graph or Android artifact exists.

Running AVD `Pixel_8` / serial `emulator-5554` was inspected read-only:

- API 36; system image `android-36/google_apis_playstore/x86_64`, revision 7.
- Fingerprint `google/sdk_gphone64_x86_64/emu64xa:16/BE2A.250530.026.D1/13818094:user/release-keys`.
- `ro.product.cpu.abilist=x86_64,arm64-v8a`;
  native bridge `libndk_translation.so`; page size 4096.
- Emulator version output: **36.6.11.0**, build 15507667, versus T001
  selected 37.1.11. The version-query collector did not terminate after
  printing the version; it was interrupted (exit 1). The prior property
  commands each returned 0. Do not call the whole collector PASS.
- ARM64 is advertised, so this is a **possible compatible route**, not
  an established ABI mismatch and not a successful IL2CPP native load.
  No APK was installed, launched or captured by this task. A36 native
  coverage is NOT_RUN; A28/A30/A33/A36_16KB and physical coverage are
  NOT_RUN. This existing AVD is 4 KB and cannot stand in for the 16 KB row.

Exact editor/module installation, selected Emulator revision, package
resolution and build proof remain prerequisites after the source decision.
No T002 change is justified merely by this unfinished install. Investigate
and install exact components on resume; only demonstrated incompatibility
should lead to a narrow proposed T002.

## Build and capture artifacts

| Artifact | Path | SHA-256 / state | Evidence class |
|---|---|---|---|
| C# fixture executable | `Temp/PureTests/OneLaneWar.PureTests.exe` | `dab45209a3776a94c7cee673e07b71ae6c9183433eb876d1600194fb2e08ffa9` | Local ignored, reproducible test binary; not an Android app |
| Canonical spawn reproduction | `logs/pure-tests-exact-head.txt` | Manifested in evidence hashes | Actual C# fixture FAIL |
| APK / AAB / native libs | NONE | NOT_BUILT | No Android claim |
| Screenshot / recording | NONE | NOT_CAPTURED | No presentation claim |
| Unity package lock | NONE | NOT_RESOLVED | No package-pin claim |

Replay fixture: all eight combinations of synthetic 30/60 FPS and
1x/2x/4x/10x scheduling ended at tick 1152, PlayerWin, hash
`38147fa12dbec4e67eef33bd39e22d77d25aade260e10ec10e00080561cbc0f9`.
This is one deterministic model scenario, not full balance validation,
rendered-game equivalence, or proof that the known collision defect is absent.

## QA execution

| QA ID | Status and measured scope |
|---|---|
| QA-082 | **BLOCKED**: no pinned Unity Android build or clean-checkout rebuild |
| MIG-QA-001 | **PASS**: normalized 147-file manifest coverage and both excluded baseline files byte-identical |
| MIG-QA-003 | **NOT_RUN** for built-app acceptance; static review finds no commercial SDK/code/deployment or spending |
| MIG-QA-004 | **BLOCKED** for complete acceptance: focused three-slot/reserve/ranged-target model fixtures pass, spawn-pressure fixture fails |
| MIG-QA-005 | **NOT_RUN** for full mapped acceptance: focused opposing equal-speed proportional clamp passes; exhaustive mirrored/native cases not supplied |
| MIG-QA-006 | **PASS, pure model only**: no travel on release tick, travel next tick; Unity/render/native repetition NOT_RUN |
| MIG-QA-007 | **PASS, pure model only**: exact queue cutoff and due impact before tick-4200 fraction comparison; native repetition NOT_RUN |
| MIG-QA-009 | **PASS, pure model only**: same-tick deployment rejects second command without spend |
| MIG-QA-041 | **NOT_RUN**: actual library install/load absent; advertised ARM64 support alone proves neither success nor mismatch |

No fake adapters or commercial SDK flows were exercised; none were needed
for these isolated fixtures. The original QA registry remains unchanged.

## Review and remote handoff

**Alternative same-agent source/diff review**, not a native Codex or
independent review, of implementation commit
`53051512a99774f974ae335c3ffff77cb3462646`. Checked module boundaries,
canonical content provenance, fixture scope, forbidden changes, source
preservation, command/test results and the failing geometry against Bible
02. Disposition: **BLOCKED / partial implementation; do not merge or
advance PH01**. The core assembler has no Unity references; views and a
completed Unity build do not yet exist. No general all-code-correct claim
is made. The failing acceptance test remains enabled.

Verified designated remote:
`https://github.com/96andrejkostovski-cloud/One-Lane-War.git`.
Read-only GitHub API showed exact repository identity, **public** visibility,
authenticated `push=true`, default `main`, `protected=false`, and empty
rulesets. `git ls-remote` matched baseline main before the push. Its
nonempty state is the explicitly user-confirmed baseline, not an unknown
history to overwrite. Initial sandbox network calls failed against proxy
127.0.0.1:9; approved network retries succeeded. See
[remote-verification.txt](logs/remote-verification.txt).

Normal implementation push command and actual result:
`git push --set-upstream origin codex/olw-core-001-toolchain-combat`,
[push-implementation.txt](logs/push-implementation.txt).
Only the scoped branch is pushed. The report/logs follow in an evidence-only
commit. No force push, main change, PR creation or merge is performed.
Post-handoff remote refs and final exact-head review are recorded in the
local final receipt linked below and summarized in the delivery message.

## Next allowed action

**Stop for Director review of this blocker.** Director must issue an
explicit numbered spawn-pressure rule, then resume OLW-CORE-001 on this
branch. Repair the failing property to that decision, finish the developer
harness, resolve/prove exact T001, and complete required Unity, Android,
clean-build and compatible native evidence. Do not start OLW-CORE-002.

See `DIRECTOR_BLOCKER.md`, `logs/operational-notes.txt`,
`evidence-hashes.json`, and the local `FINAL_RECEIPT.md` for supporting
handoff details. The final receipt is intentionally outside its own commit
to record the exact pushed/reviewed SHA without a self-reference cycle.
