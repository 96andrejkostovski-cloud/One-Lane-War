# OLW-AMEND-001 — Permanent workspace and Unity root

**Status:** ACTIVE OWNER DIRECTION, 2026-09-27
**Base source:** OLW-SOURCE-1.0.0; `SOURCE_MANIFEST.json` SHA-256
`6c5ab38839a42dfe9a8c0085860d13bf05899441b2a389f3b6d243b552a16d90`
**Authority:** Owner's current One Lane War director brief, section 0.
**Scope:** Project placement and paths only. B001, T001, WF002, gameplay,
content, monetization, and task acceptance remain as defined in the imported
source package.

## Decision

`C:\Users\Andrej\Downloads\One Lane War` is the single permanent
workspace, Git repository root, and Unity project root. Create Unity's
`Assets/`, `Packages/`, and `ProjectSettings/` directly beneath that root.
Keep `One_Lane_War_Codex_Source_v1.0.0/` intact as the imported source
authority beside those Unity directories. Development documentation,
evidence, scripts, placeholder assets, and later production assets stay
within this same root.

The owner's explicit placement supersedes the `Game/` project path and
source-copy migration instructions in the imported `AGENTS.md`,
`START_HERE.md`, `START_CODEX.md`, `tasks/OLW-CORE-001.md`,
`data/tasks.json`, Bible 00 section “Migration procedure”, Bible 07
section 7.1, and decision D022. It does not move, edit, or supersede the
canonical JSON values in the sealed package. Relative source-tool commands
are run with the source-package directory as their working directory, or
with paths explicitly prefixed from the main root.

Do not create `Game/`, `UnityProject/`, a second repository, or a duplicate
One Lane War project elsewhere. OS and vendor caches may use their normal
locations but cannot become the authoritative project. If another copy is
found, report it without merging or replacing it.

## Implementation effect

`OLW-CORE-001` must initialize local Git at the main root if absent and
create the Unity project at that root. Its evidence belongs under
`ImplementationEvidence/OLW-CORE-001/` at the main root. Later task
packets inherit this same path correction. Any future consolidated source
release should incorporate this amendment while preserving the imported
v1.0.0 package for provenance.

## Gate naming

The owner's G0–G13 narrative describes the intended production outcomes.
The imported WF002 `PH01`–`PH11` IDs remain the operational task and
evidence IDs, with PH01 covering toolchain proof and combat foundation.
No extra approval or skipped phase is inferred from the different labels.

| Owner milestone | Operational evidence phase |
|---|---|
| G0 source/design lock | Source intake before PH01 |
| G1 toolchain proof and G2 combat foundation | PH01 |
| G3 full placeholder game | PH02 |
| G4 balance correction | PH03 |
| G5 functional placeholder readiness | PH04, then PH06 acceptance |
| G6 service integration | PH05 |
| G7 placeholder release-complete build | PH06 |
| Screenshot-derived target approval before G8 | PH07 |
| G8 final asset/audio production | PH08 |
| G9 final presentation integration | PH09 |
| G10 release QA and G11 closed human validation | PH10 |
| G12 Google Play production and G13 operation | PH11 and OPS001 |
