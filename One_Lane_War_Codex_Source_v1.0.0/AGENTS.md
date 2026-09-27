# One Lane War — repository agent instructions

Read `START_HERE.md`, `SOURCE_AUTHORITY.json`, the current task, and its Bibles before editing. Active source is OLW-SOURCE-1.0.0, B001, T001, WF002. JSON content is exact numerical/ID authority; Bibles/contracts define behavior. Historical ZIPs and generated style images never override active source. A real conflict requires a documented numbered amendment, not guessing.

## Product/workflow

Strictly single-player, deterministic local combat, local-only saves, no accounts/PvP/cloud progression. Unity Android landscape. Six troops, four equipped, four battles/expedition, 24 upgrades, nine expeditions/36 encounters. Organic-only acquisition. No extra feature systems.

Build the entire placeholder game before final visual/music/SFX production. V001 images are style only and contain wrong numbers/extra motifs. Real build screenshots → owner-approved paintovers → final art/audio/presentation. Do not request generated character production sheets before CORE001/CORE002.

## First task and architecture

First task is OLW-CORE-001 only when explicitly issued. Build under `Game/`; preserve the imported source files. Use plain C# 20Hz authoritative combat; Unity presentation/physics/animation never award damage or currency. CORE001 has all six troop mechanics and 24 operators plus debug harness, not the full campaign UI. No Firebase/AdMob/IAP imports or cloud deployment in CORE001; real integrations belong to PH05.

T001 pins are selected, NOT jointly built. Inspect the actual host/editor/Android/ABI. Do not claim an ARM64 APK ran on an incompatible x86 AVD. Do not substitute latest packages silently. Report blocked tests precisely, preserve successful evidence, and propose T002 only on demonstrated conflict.

## Scope/security

Only implement the issued task; no automatic advancement. No modification of other games, unapproved remote repo creation/push/merge, paid generation, deployment, purchases or publishing. No secrets/private keys/customer data/font binaries in source. Final identity is supplied later; `com.example.onelanewar.dev` is development-only and release-blocked.

## Evidence

Run `python tools/verify_source.py` and `python -m unittest discover -s tests -v`; run actual Unity/device/service tests required by the task. Source checks are not game tests. Keep actual command/exit/log/count/commit/artifact evidence under `ImplementationEvidence/<task>/` using the template. All supplied runtime QA starts NOT_RUN. Do not mark fake adapters live, generated images runtime, arithmetic audits combat simulations, or friends' feedback commercial retention.

Inspect git status before edits; preserve user work. Work on a scoped local branch. Review the exact final head; tests/review on an older head do not approve new changes. Stop when the task acceptance packet is ready for review or a reproducible blocker is documented. Never call scaffolding the finished game.
