# OLW-CORE-003 — Shared-model balance proof and corrections

**Source:** OLW-SOURCE-1.0.0 · B001 · T001 · WF002. **Phase:** PH03. **Status:** NOT_STARTED.

## Authorization and dependency

Execute only when the owner issues this task. The issued instruction authorizes its bounded local implementation, not unapproved spending, remote repository mutation, deployment, paid generation, real purchases or publication. Dependencies: OLW-CORE-002.

## Required reading

- START_HERE.md
- SOURCE_AUTHORITY.json
- AGENTS.md
- bibles/02_COMBAT_SIMULATION.md
- bibles/03_CONTENT_AND_ENEMY_DESIGN.md
- bibles/04_CAMPAIGN_ECONOMY_MONETIZATION_DESIGN.md
- bibles/14_QA_BALANCE_AND_EVIDENCE.md
- bibles/15_CODEX_EXECUTION_AND_PRODUCTION_PLAN.md

Use the canonical data and applicable contracts directly. Bible20 is generated from those records; it is not another independently editable balance source.

## Work to deliver

- Use the exact C# CombatModel assembly in the headless batch runner.
- Exercise all 15 loadouts and 36 encounters under documented player policies and upgrade paths.
- Run normal campaign-unlock routes and establish no-ad/no-purchase campaign viability.
- Inspect congestion, idle time, dominant policies, effective damage, duration and timeout-fraction victories.
- Propose a B002 amendment only with exact changed fields, before/after evidence and required review.

## Explicit exclusions

- Do not substitute nominal-DPS arithmetic for the actual combat model.
- No balance changes outside a documented source amendment.
- No new gameplay feature systems or unreviewed B001/T001 substitutions.
- No external action beyond this issued task’s explicit permissions.
- No final Higgsfield artwork, Suno music or ElevenLabs SFX production.

## Acceptance

- Export actual-model battle outcomes as CSV/JSON with seeds, loadouts, upgrade paths and exact player-policy definitions.
- Prove state-hash agreement between the live game and headless runner for identical command streams.
- Demonstrate a no-ad/no-purchase campaign route and record separate human gameplay-review observations.
- Label bot performance separately from human enjoyment, retention and commercial evidence.

Demonstrate every scoped item through the actual model, build, device or service evidence required by its Bible. Apply the relevant QA fixtures and state-machine tests. Initial mapped QA IDs: QA-001, QA-002, QA-003, QA-004, QA-005, QA-006, QA-007, QA-008, QA-009, QA-010, QA-011, QA-012, QA-013, QA-014, QA-015, QA-016, QA-017, QA-018, QA-019, QA-020, QA-021, QA-022, QA-023, QA-024, QA-025, QA-026, QA-027, QA-028, QA-029, QA-030, QA-031, QA-032, QA-033, QA-034, QA-035, QA-036, QA-037, QA-038, QA-039, QA-040, QA-041, QA-042, QA-073, QA-074, QA-090, LOCK-QA-01, LOCK-QA-02, LOCK-QA-03, LOCK-QA-04, LOCK-QA-05, LOCK-QA-06, LOCK-QA-07, LOCK-QA-08, LOCK-QA-09, LOCK-QA-10, LOCK-QA-11, LOCK-QA-12, MIG-QA-008, MIG-QA-010, MIG-QA-030.

The source verifier and reference tests must pass, but neither substitutes for Unity/runtime tests. No known critical save, payment or security failure can be hidden by average pass rates. A fake adapter, generated image, arithmetic oracle and live integration are different evidence classes. A missing host/ABI/credential prerequisite is BLOCKED, never a guessed pass.

## Evidence packet and stop

Write `ImplementationEvidence/OLW-CORE-003/TASK_RESULT.md` using the supplied template. Include source-manifest hash, initial/final commit, changed paths, commands/exit codes, actual counts, environments, screenshots/recordings, build hashes and unresolved findings. Use the exact final head for review. Preserve user work and do not make silent source changes.

Stop when the scoped acceptance packet is ready for review or a reproducible blocker is documented. Do not execute the next task automatically. Future final-media and production identity inputs are not blockers for earlier offline placeholder work that does not use them.
