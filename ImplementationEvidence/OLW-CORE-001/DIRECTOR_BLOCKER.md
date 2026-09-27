> HISTORICAL — resolved by active OLW-AMEND-005. The original report below is preserved for context; its proposed options are superseded. The amended canonical reinforcement and focused contact fixtures pass in the 80-case suite at `f41126d87e77a534da977715224cf9d8ce7999ce`. Current PH01 evidence is in TASK_RESULT.md.

# OLW-CORE-001: spawn-pressure source decision required

Status: **BLOCKED — proposed clarification only, no source amendment enacted.**

The unmodified canonical first encounter `c01_e01_b01`, starter loadout,
seed 17 and no upgrades reaches the following state in the partial C# model:

1. Allow its actual enemy queue to run without player deployments.
2. The leading enemy Militia reaches the player fortress and begins attacking.
3. At tick 582, request one paid player Militia. The battle is active; Supply,
   loadout, cooldown and population checks pass.
4. The accepted spawn is at 800000 coordinate subunits. The enemy is at
   825000. Each Militia has half-width 250000. Separation is 25000 rather
   than the required 500000, an overlap of 475000 subunits (0.475 m).

Reproduction: `Tools/run-pure-tests.ps1`, fixture
`formation.fortress_spawn_pressure_no_hostile_overlap`. It intentionally
remains failing. This is an executable model reproduction, not a Unity or
native Android observation. The fixture now uses the original encounter,
not an injected enemy position or changed queue.

## Controlling requirements

- `data/game_rules.json`: `spawn_positions_m=[0.8,27.2]`, three engagement
  slots, 24 living actors per side, and the listed deployment validation.
- `data/units.json`: Militia collision half-width 0.25 m and attack range
  0.6 m. Its legal fortress-attack centre is at most 0.85 m from the front.
- Bible 02, **World, formations and collision**: opposing bodies cannot
  pass through each other; hostile overlap is not allowed; new spawns
  remain at their own deployment point until allowed to advance; spawning
  must not teleport an attacker away, push a hostile through a base, or
  place a new reserve on the enemy side.
- Bible 02, **Supply, deploy and population**: successful validation
  spends and creates the actor atomically; no paid queue is defined.

The geometry is independent of this model's exact stopping subunit:
an attacking Militia at x=0.25..0.85 overlaps a fresh x=0.8 Militia for
most of that interval; a fresh actor also risks appearing past the enemy
centre. Proportional movement clamps cannot solve an overlap that already
exists at creation without changing spawn semantics or displacing actors.

## Minimal Director decision

Issue a numbered behavior amendment specifying **spawn legality under
fortress pressure**, including target selection and how overlap clears.
No new troop, upgrade, commercial system or numerical rebalance is needed
merely to make that decision explicit.

Two concrete options for Director assessment:

1. Add a no-spend/no-queue `SPAWN_BLOCKED` rejection while the fixed spawn
   footprint intersects a hostile. This preserves fixed geometry and
   non-overlap, but may prevent all reinforcement once a melee attacker
   reaches the base; assess that gameplay consequence before approval.
2. Define a narrow spawn-only hostile-overlap exception, keeping both
   bodies stationary/targetable until separation or death, and define
   targeting for overlapping or slightly reversed centres. This preserves
   immediate defensive deployment but explicitly changes the blanket
   non-overlap rule and needs dedicated regressions.

Neither option is implemented or represented as approved. Teleporting
units, pushing an attacker backward, changing spawn positions, or silently
adding a paid queue would also change the source and is not a repair
authorized by the present packet.

## Consequence and retained work

The importer, partial model and reproducible fixture suite are retained
on the scoped branch. Do not call this a completed combat foundation or
PH01 PASS. The failing acceptance property blocks Director acceptance;
the developer harness, Unity tests, Android build and native-load capture
have not been completed. Finish them after the source decision and
resumption of this same Goal. CORE-002 remains unauthorized.

The exact T001 download was attempted through Unity Hub. Its download
process was stopped after confirming this source stop condition; the
download cache was preserved. A child editor installer may finish an
installation already started. The final inventory records actual state;
installation progress or mere files on disk are not licensed editor,
package resolution, build, or native-load proof. No T002 substitution is
proposed from this source conflict.
