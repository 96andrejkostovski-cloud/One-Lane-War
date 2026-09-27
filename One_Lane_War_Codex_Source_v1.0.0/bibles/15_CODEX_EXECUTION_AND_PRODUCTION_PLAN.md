# Bible 15 — Codex Execution and Production Plan

**Authority:** WF002. This replaces all older G0–G10 sequences that placed final asset proof before a playable game. `data/build_gates.json` uses PH IDs so old gate names cannot silently regain authority.

## 15.1 Migration and roles

The user imports this source into a new Codex workspace. Codex reads `START_HERE.md`, `SOURCE_AUTHORITY.json`, `AGENTS.md`, the assigned task and its required Bibles/registries. It runs the supplied validation before creating game code. A migration acknowledgement names source version/hash, latest workflow, local-only single-player scope, first task, missing environment tools and forbidden actions.

The owner approves visual targets, external spending, legal/publisher identity, credentials/deployments and publication. The director owns gameplay/balance/toolchain choices and source amendments. Codex implements the scoped source, detects contradictions, runs tests, supplies reproducible evidence and stops at the task boundary. This document does not create a GitHub repository, purchase software, register an app or deploy a service.

An issued task prompt authorizes its bounded local implementation. Merely placing files in a workspace is not a command to perform every task automatically. Do not request final art, cloud keys or a commercial logo before an offline placeholder task that does not need them. External missing inputs are stage-specific blockers; source/game issues should be repaired through source decisions rather than handed to the owner as unexplained programming questions.

## 15.2 Phase order

| Phase | Outcome |
|---|---|
| PH01 | clean core Unity/Android toolchain and placeholder combat foundation |
| PH02 | full placeholder game: six units, 24 upgrades, 36 encounters, all screens/progression |
| PH03 | actual-model balance simulation and exact-head gameplay correction |
| PH04 | responsive flow, input, placeholder feedback, saves/recovery and accessibility |
| PH05 | approved real test services, purchases, ads, privacy and analytics while placeholders remain |
| PH06 | whole placeholder game content-complete and accepted; no final provider assets required |
| PH07 | real screenshot/recording pack, faithful paintover targets, owner presentation selection |
| PH08 | final asset/audio generation and three-unit production animation proof, then catalogue |
| PH09 | final presentation integration, mix, animation/VFX and regression |
| PH10 | release-candidate/device/closed-player validation and store readiness |
| PH11 | owner-approved production publication, operations and evidence-based continuation |

PH05 may proceed after stable PH02/PH04 interfaces without waiting for every balance iteration. An unavailable external service can be recorded as a separate integration blocker; it does not justify pretending a fake passed. Final production generation never moves earlier than accepted placeholder completion and target approval. Existing V001 references remain only the style destination throughout PH01–PH06.

## 15.3 First bounded task

`OLW-CORE-001` combines toolchain proof and placeholder combat foundation. Implement all six troop mechanics and all 24 upgrade operators in the model, but not the full Draft/Shop/campaign/service integration yet. Provide a developer-only combat harness selecting loadout, encounter, up to four eligible upgrades, seed, speed 1×/2×/4×/10×, pause and single step. Use actual encounter records, not undocumented dummy battles only.

The harness shows both bases, Supply, troop controls, Rally, tick/time, alive counts, damage/counters and optional formation/debug overlays. A clean no-debug capture route also exists. The full game later exposes only its six intended main views; this harness is not a new launch feature. No Firebase, AdMob, Billing imports, provider-generated assets, real purchases or cloud deployment in CORE-001.

Acceptance includes source importer/reference tests, movement/frontline, damage/timing, projectiles/splash, all upgrades, overtime/cutoff/draw, pause/background and reproducible Android build/native load evidence where the host supports it. If ABI/environment is blocked, preserve successful pure tests and report the exact blocked device task rather than false completion.

## 15.4 Remaining task packets

Every task file under `tasks/` identifies dependencies, source inputs, scope, exclusions, required tests/artifacts and stop conditions. CORE-002 delivers the full expedition/campaign/UI/save game with placeholders. CORE-003 supplies the shared-model balance runner and correction evidence. CORE-004 closes functional UX/failure/accessibility behavior. INT-001 handles the approved service layer and analytics. CAP-001 seals placeholder completion and exports real capture fixtures.

PRES-001 processes screenshot-derived targets after owner approval. ART-001 is explicitly gated external production, not automatically issued now. PRES-002 integrates final presentation. REL-001 produces a release candidate and real test evidence. REL-002 is owner-controlled publication. OPS-001 concerns maintenance and incident/accounting documentation; it is not an unattended automation.

There is no arbitrary maximum number of C# files. Respect the bounded product and simple architecture, not a twenty-script rule that forces an untestable monolith. No feature expansion is a substitute for fixing clarity or incorrect behavior.

## 15.5 One-shot experiment record

The experiment concerns a large initial implementation attempt, not a claim that every external dependency can be completed in one response. Record task prompt, model setting selected by owner, initial repository state, source manifest, start/end commit, environment, checks run, resulting build and known deviations. Scaffolding alone does not count as a playable core. Follow-up repairs remain follow-up repairs in the log.

CORE-001 is the first bounded technical attempt; CORE-002 completes the full placeholder application rather than pretending a single combat scene is the whole game. This task split preserves the user's original rapid-development intent while retaining honest boundaries. Do not inflate the result by renaming several corrections as the same perfect one-shot.

## 15.6 Branches, review and evidence

Use a dedicated local branch per task. Preserve user work and inspect current status before editing. Where an authorized remote repository exists, use a PR and protected main with a fresh independent review on the exact final head. The task package itself does not create or merge that PR. Record source amendments distinctly from implementation fixes.

Each evidence packet includes task ID, source hash, base/head, changed paths, commands with exit codes, exact test counts, logs, environment/version graph, screenshots/recordings, artifact hashes, unresolved findings and next allowed task. Do not cite a stale passing commit after a new edit. `git diff --check` is a useful formatting check, not proof of correct game behavior.

No secrets, provider keys, upload-key passwords, service-account files, personal banking details or font binaries in source. Production assets enter the repository only according to the authorized storage/licence policy, with content hashes; large source media may use approved external storage/LFS, but the release must be reproducibly recoverable. Do not leave essential production files untracked on one workstation.

## 15.7 Stop rules and handoff

Stop the scoped task on an unreconciled source contradiction, missing executable/tool/licence needed to test its core claim, missing production identity required for a service action, unsafe overwrite of user work, or a new paid/public action outside authorization. Report what succeeded and what exact action is blocked. Do not stop because final lighting has not been chosen during placeholder work.

The source package's read-only validation can run without Unity. A future source amendment changes manifest/version and traceability, not merely a paragraph in chat. At task completion leave a clean reproduction path and explicit state so a fresh Codex session can continue without reconstructing the entire conversation.
