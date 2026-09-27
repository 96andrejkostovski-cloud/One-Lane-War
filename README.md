# One Lane War

One Lane War is a single-player, landscape Android strategy game being
built in Unity. The player equips four troops, drafts temporary upgrades
across a four-battle expedition, and fights scripted enemy armies on one
horizontal battlefield.

## Project state

The repository root is the Unity project root. Unity's `Assets/`,
`Packages/`, and `ProjectSettings/` will be created here during the first
implementation task. The game has not been built yet. All runtime QA
and production gates remain unexecuted until their evidence is recorded.

`One_Lane_War_Codex_Source_v1.0.0/` is the imported, sealed design and
content authority. Keep it intact. Read its `START_HERE.md` and
`SOURCE_AUTHORITY.json`, then the applicable task packet, Bibles,
contracts, and canonical JSON. Root-level `AGENTS.md` and
`Documentation/SourceAmendments/` record later owner and Director
instructions, including that Unity belongs directly in this root.

The sequential build route and Astra assignments are in
`Documentation/Director/ASTRA_BUILD_PLAN.md` and
`Documentation/Director/ASTRA_GOAL_PROMPTS.md`. Development is
placeholder-first; final artwork, music, SFX, commercial integration,
and publication have later evidence and approval gates.

## Source checks

From `One_Lane_War_Codex_Source_v1.0.0/`, run the source verifier,
reference tests, and arithmetic audit described in `START_HERE.md`.
Source checks do not prove Unity, Android, combat, services, or release
readiness. `Documentation/SourceAmendments/OLW-AMEND-002.md` records a
Windows path-separator defect in the original full verifier and the
required independent manifest check.

## Repository practice

Use the task and Goal boundaries in the Director plan. Record tested
commits, commands, builds, captures, and findings under
`ImplementationEvidence/<task>/`. Keep credentials, signing keys, and
local Unity-generated files out of Git. Do not add gameplay systems or
change B001 balance or T001 tooling without a numbered amendment.
