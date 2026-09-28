# OLW-CORE-001 / PH01 Director review

**Decision:** PH01 ACCEPTED for the scoped toolchain and placeholder combat
foundation. Goal 02 (OLW-CORE-002 -> 003 -> 004, PH02 -> PH04) may be issued
from this accepted branch after its own scope is stated. This is not an
approval to merge, start services or produce final media.

**Review date:** 2026-09-28.
**Tested implementation:** `f41126d87e77a534da977715224cf9d8ce7999ce`.
**Pushed evidence handoff:** `63252570b095e92daea5c85990ea48fe98619514`.
**Branch:** `codex/olw-core-001-toolchain-combat`; `main` remains at
`c8130bfb304b40047c703b44ff3db19bc5cae89d`.

## Evidence checked

- Reviewed the scoped task, B001 combat rules, AMEND-005 and the code paths
  for source import, contact, movement, targeting, attacks, harness, build
  configuration and PlayMode/native proof. The evidence commit changes no
  `Assets/`, `Packages/`, `ProjectSettings/` or `Tools/` path relative to the
  tested implementation commit.
- Parsed final Unity XML: EditMode **81/81**, PlayMode **7/7**, with zero
  failures or skips. The final pure-model log records **80/80** at the tested
  commit; a Director rerun at the evidence HEAD also passed **80/80**.
- The clean Android log reports exact Unity **6000.3.21f1**, editor-bundled
  JDK selection, `Succeeded`, and zero build errors. The local APK SHA-256
  matched the report: `18d8c724a21b30fc8dcd6e1d636331edb62f08e7d21581c1058eb2df42feee30`.
- Eight final native replay lines in PID 8485's log each ended at tick 1152,
  PlayerWin, with hash `7aa8d88bcf7f4ad6759c53d377e0754e9032aeca7468d0885e66dab68f37f533`.
  The process maps include ARM64 `libil2cpp.so` and `libunity.so` through
  `libndk_translation.so` on the named API36 x86_64/ARM64-translation AVD.
  The APK checks and six ELF records show ARM64 libraries and >=16-KB LOAD
  alignment. The runtime image itself uses 4-KB pages.
- Inspected actual native configuration, battle and clean PNGs. The controls,
  bases, Supply, actors and result are present. The native inspection receipt
  documents completed deployment, Rally, background pause and explicit
  resume. Placeholder crowding is visible near the final battle frame.
- Director reran the sealed-source checker: 147 manifest files and two
  excluded baseline files matched. All **194** entries in the published
  evidence hash manifest matched their current bytes and SHA-256 values.
  The original source verifier's **1135/1136** Windows separator defect is
  retained as FAIL; its separate semantic/reference and normalized byte
  checks are not mislabeled as a clean original verifier pass.

## Limits carried forward

- Live landscape switching during one running emulator session is **NOT
  PROVEN**. Left and right gameplay loaded on separate cold launches. Retest
  the live orientation behavior with the functional UI/device work in PH04;
  do not call it PASS from the current screenshots.
- Native measured frame rates were **24.33-32.77 FPS** on the translated AVD.
  This proves rendering and deterministic 20-Hz combat under those runs, not
  the 60-FPS target, physical-phone performance or all Android devices.
  Measure and optimize on the later crowded build and physical-device gate.
- This is a developer placeholder combat harness. Full campaign flow,
  balance play, S1 saves, final UX, commercial integrations, visual approval
  and release evidence remain at their issued later phases.

No implementation was changed by this Director review. The evidence supports
PH01 acceptance at the tested implementation commit, with the above claims
kept separate from later phase gates. Goal 02 must retain the exact source,
amendment and commit lineage and produce its own packet-level evidence.
