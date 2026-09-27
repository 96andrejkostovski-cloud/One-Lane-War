# 02 — Deterministic combat and simulation Bible

## Authority and numerical representation

`data/game_rules.json`, `units.json`, `upgrades.json`, `boss_variants.json` and `encounters.json` are the B001 configuration. This Bible closes their execution semantics. No gameplay number is left for the owner to guess. B001 is selected, not yet validated by a full combat simulator or human playtest.

Use a pure C# model with no Unity physics dependency. Simulation frequency is 20 Hz: one tick is 50 ms. Coordinates and Supply use 1,000,000 integer subunits per metre/unit. Percentages use basis points. HP and damage are integers. Intermediate multiplication uses checked 64-bit arithmetic. Configuration decimals are converted through an exact decimal representation; avoid binary-floating-point boundary decisions.

An integer attack period is `max(7, ceil(basePeriodTicks * 10000 / (10000 + rateBonusBp)))`. Windup is `min(periodTicks - 1, max(1, ceil(baseWindupTicks * 10000 / (10000 + rateBonusBp))))`. Recovery is the remaining interval. “20% faster” means +20% rate, not subtracting 20% from the period. Damage/HP round positive halves up once after the applicable additive group. Cost rounds up. Effective speed clamps to 0.25–2.5 m/s.

Income and movement carry division remainders between ticks. There is no income at tick 0; the first interval accrues at tick 1. Time-of-day changes do not grant Supply, shorten cooldowns, advance queues or change rewards. Animation, render FPS, physics callbacks and particles never award damage.

## Tick transaction and ordering

For tick t, expire effects whose expiry equals t; accrue the elapsed interval; settle an owed bonus when capacity allows; validate queued player commands in input order; process the enemy's next eligible deployment; assign/retain formations; compute simultaneous movement; advance/start attacks and projectiles; collect all due damage; resolve barrier/HP loss; remove deaths; evaluate destroyed bases; then apply the hard-timeout fraction rule if still unresolved. Emit immutable presentation and analytics summaries afterward.

Actor IDs are deterministic, monotonically assigned within a battle, and never reused. Command records include intended simulation tick and a monotonically increasing sequence. Render callbacks enqueue commands once; double pointer callbacks do not create a second command. Development simulation speed processes more unchanged 50-ms ticks, never a larger delta.

Collect damage before removing deaths. An attacker whose committed impact is due on its death tick still deals that impact. It cannot start a new attack on a later tick. Stable ordering resolves barrier consumption and attribution, not an advantage from updating blue before red. Model hash/replay evidence uses an explicitly ordered serialization, not Dictionary iteration order or a process-randomized hash code.

## World, formations and collision

The logical lane is 28 m. Fortress fronts are x=0 and x=28; deployment positions are x=0.8 and x=27.2. World Y offsets are cosmetic. Both sides fight along the same X interval; there are no selectable sublanes.

Up to three melee actors per side hold engagement positions. Retain living eligible incumbents. Fill vacancies with the nearest eligible melee reserve, ties by stable spawn ID. A position grants permission to engage, not teleportation, additional reach or paired-duel protection. Reserve melee cannot attack until assigned. Several active attackers can choose the same opposing target.

Friendly melee form small groups with 0.65 m longitudinal separation. Ranged queue spacing is 0.45 m. Melee may advance through their own ranged formation. Ranged troops never occupy a magic invulnerable rank: without a protecting body ahead they become normal frontline targets and retain their ordinary ranged attack when possible. No automatic kiting or backward fleeing exists.

Opposing bodies cannot pass through one another. Compute both sides' movement proposals from the same start-of-tick state. When the combined approach exceeds the free gap, reduce the advances proportionally to their proposed distances; residual fixed-point rounding uses the stable tie rule. Clamp against opposing body extents. No collision solver is allowed to create damage, launch actors or repeatedly move actors backward to “repair” a bad update order.

Friendly overlap within a three-person visual group is an intentional formation abstraction; hostile overlap is not. New spawns remain at their own deployment point until allowed to advance. They are immediately targetable where appropriate. Spawning must not teleport an attacker away, push a hostile through a base or place a newly created reserve on the enemy side. Tests cover spawn pressure near a fortress.

Range is the edge-to-edge horizontal gap: `max(0, abs(xA-xB)-halfWidthA-halfWidthB)`. A fortress front is a zero-width target. Tolerance is one coordinate subunit (0.000001 m). Do not use large visual sprite width, particle bounds or a rotated weapon to decide range.

Target the nearest reachable opposing body in the forward direction, tie by actor ID. A defending body between an attacker and fortress blocks targeting that fortress even when it is a reserve or ranged actor. A Ram cannot damage the fortress through a troop. Do not implement invisible flanking, a cavalry counter or an armor class not in source.

## Supply, deploy and population

Player starts with 100 Supply, earns 6 per second and caps at 200. Unit costs are 20/45/50/65/110/100 for Militia/Shieldguard/Crossbowman/Grenadier/Brute/Ram. No kill income, manual pickup, purchase refill or offline income exists.

One completed tap validates active battle, pause state, equipped unit, funds, 0.30-second global deployment cooldown and 24-actor living cap. Failure spends nothing and creates no paid queue. Success spends and creates the actor atomically. Units dying in the current damage phase release their capacity for the next tick; they are not preemptively removed while earlier commands are validated.

Each side has its own cap. Bonuses and bosses count. Conscription has at most one owed bonus at cap; it settles at the next spawn phase before a paid deployment. The bonus counter counts only paid successful Militia. No recursion, no reserve inventory and no paid click consumed on failure.

## Attacks

At attack start, snapshot target ID, appropriate troop/base damage, attack-rate modifiers, period and windup. Ongoing attacks do not accelerate when Rally starts or slow when it expires. The next attack uses then-current modifiers. An attack freezes movement until the attack period finishes; idle/movement can resume afterward when no valid attack starts. Hit feedback is not a stun.

Melee: recheck the same target at impact. A dead or out-of-range target causes a miss and still consumes recovery. Do not retarget an already-started melee impact. Shields reduce damage through the fixed reduction statistic, not by a new randomized block roll.

Crossbow: release a model projectile after the snapshotted windup. Projectile speed is 12 m/s. Store launch position, direction, intended path extent and damage. It ignores friendlies and hits the first intersected enemy using swept movement, preventing tunneling at higher playback speeds. Its already-released existence does not depend on the shooter's survival. If the original target dies, another eligible body on the existing path may be hit. A nonpiercing shot does not track a moving target beyond its committed extent.

Grenadier: release toward a ground X position committed at release. Travel is 8 m/s to that point, quantized to ticks. The final position does not follow a moving enemy. The base radius is 1 m using enemy centres. No friendly fire. Only a throw directly targeting a legally reachable fortress may damage that fortress; splash is not a bypass. Presentation uses an arc while simulation uses arrival tick and ground point.

Projectiles released on the current tick start their travel after release; they do not receive an extra pre-release interval. A zero/very short travel distance still resolves no earlier than the next tick. Actor death removes future actions, not projectiles already released. On battle resolution, stop subsequent model damage and clean up presentation without granting extra outcomes.

## Damage, barriers and effects

Calculate the appropriate modified troop/base amount; apply secondary-hit factor if applicable; round; apply overtime multiplier to base damage; subtract target flat reduction with minimum one for an eligible damage event; absorb barrier; subtract remaining HP. Do not subtract armor twice. Zero-eligible events, expired projectiles and invalid misses deal zero rather than the minimum-one floor.

Shieldguard's ordinary reduction is 3. Ram's is 2. Barriers are not baseline player Shieldguard equipment: the player needs First Into Battle, while Bulwark has its defined barrier. Its size is 30% of modified max HP. It is armed at spawn; the first positive post-mitigation event activates it, absorbs that same event, and starts its eight-second timer. Active range is `[activationTick, activationTick+160)`. It never refreshes, even when several hits arrive together. Multiple same-tick attacks consume the same barrier budget.

All ordinary percentage damage additions sum; a base-only Ram addition sums with the ordinary damage group for its base hit. HP additions sum separately. Rate additions sum, including Rally. Range is unchanged unless explicitly specified; the existing upgrades do not create hidden range growth. No critical hit, dodge, lifesteal, resist table, healing, armor penetration or poison system exists.

Piercing Bolts uses 60% of the original pre-mitigation bolt damage for one additional enemy within 1.5 m behind the first. Mitigate independently. Each target can be hit once. The additional hit cannot be a fortress. Sweeping Club hits at most two other enemies within 0.8 m of the primary unit, ordered by distance then ID, at 40% each; it never recursively procs or sweeps from a fortress.

Splintering Head counts each Ram's landed direct fortress hits; every third produces an additional nonrecursive amount equal to that direct hit. One attack cannot count its additional effect as another direct hit. Base death is settled once even when the direct and extra event both arrive.

## Rally and timers

Rally first becomes available after 12 seconds. It adds 30% attack rate to new attacks for five seconds. Its 30-second cooldown starts on activation; there are no charges, direct damage, Supply grants or purchases. War Drums adds two seconds to duration. Rapid Orders reduces the ordinary cooldown by five seconds but not the first 12-second delay. A troop spawned while active receives the modifier on new attacks. Enemy queues do not use Rally.

All effects expire on exact tick boundaries. A UI display may round remaining seconds upward for clarity but does not change eligibility. Background/paused elapsed time is excluded. The timer cannot become ready twice because two render frames read zero before one command resolves.

## End conditions

Player fortress starts at 900 HP; encounter records set the enemy maximum. Fortresses have no attack, healing or armor. At tick 3000 (150 s), base damage doubles on both sides. At tick 3600 (180 s), unresolved enemy purchase orders expire; existing actors and projectiles remain. Player deployment remains available. At tick 4200 (210 s), after due damage, compare remaining-health fractions by integer cross multiplication.

If only one fortress is destroyed, the other side wins. Simultaneous destruction is DRAW. Equal remaining fractions at hard finish are DRAW. A draw ends the expedition without paying the unresolved battle but retains previous wins. Do not compare raw HP when the two maxima differ. Do not grant a player tie advantage, coin flip or hidden loss.

## Combat summaries and diagnostics

Report commanded deployments, successful paid deployments, bonus spawns, cap rejections, Supply cap waste, peak population, attempted damage, barrier damage, actual HP damage, base damage and deaths separately. Overkill is not effective HP damage. Allocate simultaneous limited HP/barrier consumption in stable event order solely for attribution, while game outcome uses the complete tick's damage. The same actor dies once; no duplicate kill reports.

The debug tool exposes loadout, source-valid upgrades, encounter, seed, 1×/2×/4×/10× playback, pause/step, Supply, base health, unit counts, frontline and outcome. Test-only unlocked content, fast-forward and injected scenarios use a separate profile and environment and cannot ship in release. A debug scene is not an added player game mode.

## Proof obligations

Require replay determinism across render speeds, empty-field stability, cap saturation, opposing collision, ranged-only confrontation, reinforcements replacing deaths, simultaneous mutual kills, base blocking, projectile target death, exact splash edges, snapshot timing and overtime boundary tests. The resource-only Python tools are not a substitute for this model. Run balance policies against this same model after implementation; do not create a second convenient approximate battle engine and cite it as proof of the game.
