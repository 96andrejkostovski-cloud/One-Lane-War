<!-- Source: bibles/00_SOURCE_GOVERNANCE.md -->

# 00 — Source governance and migration Bible

**Authority:** OLW-SOURCE-1.0.0. **Assembled:** 27 September 2026. **Scope:** One Lane War only. **Runtime status:** not implemented in this package.

## Purpose

This is the complete consolidated implementation source for a deliberately small Android single-player strategy game. It turns the selected design and later corrections into one operating package for Codex. It is not a slide pitch, another brainstorming document, a Unity project, or evidence that the game is already built.

The owner delegates gameplay numbers, engineering design, toolchain selection and implementation planning to the Game Director. The owner retains final visual selection, external expenditure, account and legal identity, credentials, publication and expansion approvals. Codex implements the current task, tests it, reports defects, and preserves evidence; it does not silently change the product.

## Latest decisions take effect here

The latest workflow is **placeholder-first, entire game before final asset generation**. The previous sequence that required final visual/animation assets before the game is superseded. Build all content and functional screens with simple shapes. Integrate commercial services using controlled test accounts and no public sales. Reach the complete placeholder acceptance gate. Capture the actual game. Generate final-look targets from those captures. The owner chooses, then production art/music/SFX are generated, integrated, polished and regression-tested.

Single-player means local player versus deterministic enemy queues. There is no multiplayer, asynchronous opponent, co-op, account, leaderboard, network simulation, cloud progression or shared economy. The purchase service is not a game server.

V001 is an approved **style**, not an approved set of numeric values or a shipped screenshot. B001 remains the first-build numerical source. T001 is a selected toolchain, not a completed build proof. Source assembly does not grant permission to spend, deploy public services, publish, or mass-generate assets.

## Authority hierarchy

1. This package's explicit owner decisions and numbered scoped amendments, recorded in `records/DECISION_LOG.jsonl`.
2. Machine-readable current contracts in `data/`, their schemas, and `SOURCE_AUTHORITY.json`.
3. The numbered Bibles, which explain behavior and implementation requirements.
4. Task packets, which authorize a bounded subset of that source when the owner issues the task.
5. Approved visual references, for style only and never for rules, rewards, prices or text.
6. Historical packages and rejected examples: provenance only, never a second live source.

If current prose and current data disagree, report both paths and fields. The applicable current registry supplies numeric facts, but a genuine behavior contradiction is not permission to invent a rule. Record a narrow amendment; preserve unaffected records. A typo fix is not a reason to rebalance. A performance optimization must not change the replay result.

## Status vocabulary

`LOCKED_DESIGN` means selected instructions. `NOT_RUN` means a required test has not executed. `PASS` requires actual evidence for the exact tested source/build. `BLOCKED` identifies an external dependency or unsupported test environment. `DEFERRED_BY_WORKFLOW` is deliberate later work, not a forgotten field. `STYLE_APPROVED` does not mean production asset approval. `PRODUCTION_APPROVED` requires the actual final binary, metadata, rights and visual review.

Do not use closure percentages such as “98% finished.” The useful state is the named task, concrete outputs, unresolved defects and evidence. Earlier percentage estimates are not carried forward as measurements.

## What is preserved

The six troop records, 24 upgrades, 36 encounter queues, nine expeditions, two boss variants, Medal economy, two products, 35 custom events, 184 English strings and 148 planned asset families are inherited from the actual v0.2.0 package. Selected B001 registry files are retained byte-for-byte; their hashes are in `records/SOURCE_INPUTS.json`. Later additions specify workflow, capture contracts, test criteria, production and operational boundaries without increasing gameplay scope.

The v0.1.0 and v0.2.0 ZIPs are retained under `references/history/`. Do not extract either into a live runtime-content directory. The current Bibles and data are self-contained; the game must not depend on access to old ChatGPT conversations, memory, signed file URLs or another game's repository.

## Ownership and change control

Use a dedicated project. Do not modify Roman Legacy, Bad Boots Good Loot, Reactorfall, their asset registries or their source locks. Generic tooling may be reused only after a dependency/licence review; no cross-game content inheritance is assumed.

Every task records source package ID, source manifest hash, task ID, branch, starting HEAD, ending HEAD, configuration versions and outputs. Prefer branch `task/<TASK-ID>-<description>`, PR `[<TASK-ID>] <description>`, and descriptive commits containing the task ID. Those are local conventions, not instructions to create a remote repository without authorization.

Changes to gameplay values require a B002+ amendment and new balance evidence. Tool changes require T002+. Event meanings change through A002+. Save migrations change S1 to S2. Approved visual production changes create a new presentation revision without changing B001. Source revisions are cumulative: never leave multiple “current” source packs in the task prompt.

## Exact-head review

Review the actual final commit. A review on commit A does not approve B. After corrections, rerun affected tests, source validation and the review required by the task. Native Codex review is used when available; record its exact head and result. If unavailable, record that limitation and perform a clearly labeled alternative review rather than pretending a native check ran.

Technical correctness, gameplay quality, final visual quality, licence clearance and publication approval are different gates. One cannot substitute for another. A test count without command, environment and result logs is not sufficient evidence.

## Migration procedure

Extract this package into the chosen new local project directory. Keep `AGENTS.md`, `START_CODEX.md`, `SOURCE_AUTHORITY.json`, `data/`, `bibles/`, `tasks/` and `tools/` together. Read `START_HERE.md`, then run `python tools/verify_source.py` and the reference tests. These commands inspect source; they do not generate game assets, install Unity, deploy services or make purchases.

The first executable task is `OLW-CORE-001`. Issuing its prompt authorizes only its stated local implementation. It does not authorize automatic execution of every later task. The one-shot attempt records the owner's chosen model/reasoning setting and actual results without pretending one response can bypass build verification.

## Evidence boundaries

This handoff can verify files, links, identifiers, numeric arithmetic, queue funding and reference utilities. It cannot report Unity, Android, live billing, ad delivery, physical performance or human retention as passed because none ran here. The included game QA register therefore starts `NOT_RUN` throughout. External release inputs are recorded with owners and blocking stages rather than invented values.

The safe stopping condition is precise: complete the current authorized task and its evidence, or report the reproducible blocker. Do not end a task after scaffolding while describing it as a finished game; do not continue into unapproved production after a task passes.


---

<!-- Source: bibles/01_PRODUCT_AND_PLAYER_JOURNEY.md -->

# 01 — Product, gameplay and player-journey Bible

## Product contract

One Lane War is the internal codename. The game is a short-session, offline single-player army-builder. The player selects four troops, buys deployments with regenerating Supply, chooses upgrades between four battles, and destroys enemy fortresses. The army-building decisions, visible frontline and timing of one Rally command are the product. No hero controller or tactical dragging is present.

Android/Google Play is the only launch platform. Unity is the engine. Landscape is the supported presentation. English is the launch language; all strings have stable IDs. Intended creative audience is adults who enjoy short strategy games, with a working 18–44 profile. The proposed Play target audience is 18+, subject to truthful review of the finished art, advertising and content. This is not an assertion that cartoon art is automatically adult-targeted or that the game has an IARC 18 rating.

Initial production distribution is US, GB, CA, AU, NZ and IE. Test-track access may include the owner elsewhere; production geography and tester access are separate configurations. Acquisition is organic only. There is no paid-user-acquisition authorization, revenue guarantee or expectation of automatic discovery.

## Exact launch scope

Six units: Militia, Shieldguard, Crossbowman, Grenadier, Brute and Battering Ram. Four different units are equipped per expedition. Militia/Shieldguard/Crossbowman/Grenadier are initially owned. Brute and Ram are earned unlocks.

Three chapters contain three expeditions each. Each expedition contains four battles, with the last a stronghold battle. There are exactly 36 encounter configurations, 24 upgrades and two derived enemy boss variants. Three environment themes share the same gameplay geometry. Six main views are Home/Campaign, Army, Battle, Draft, Results and Shop. Pause, Settings, briefing and errors are overlays, not additional game modes.

The one earned persistent currency is Medals. There is no premium currency. Two non-consumable purchases and two optional rewarded-ad placements provide monetization. Purchased cosmetics have no combat effect. All campaign content is bundled and playable without payment, ads, login or a network connection.

## Exclusions

No PvP, co-op, asynchronous PvP, matchmaking, accounts, login, cloud saves, guilds, friends, chat, leaderboards, achievements, equipment inventory, rarities, gacha, loot boxes, pets, heroes, factions, historical ages, civilization evolution, procedural levels, dynamic difficulty, offline income, permanent combat-stat levels, energy, daily rewards, subscriptions, battle passes, quests, live events, push notifications, voice acting or narrative cinematics.

No mediation, runtime generative AI, remote gameplay content downloads, live A/B experiments or payer-targeted balancing. A seventh unit is not an acceptable “polish” task. Camera, input, reliable saving, consent, billing, accessibility and failure handling are existing production responsibilities, not excuses to expand gameplay.

## First launch

Boot local settings and the last valid save first. A slow analytics, ad, store or configuration service must not delay entering the offline game. Optional collection starts according to the consent contract, never from a pre-consent backlog. Display only necessary provider/privacy flows; no store popup or ad in the first expedition attempt.

Home presents the available first expedition and a clear Play action. The initial four-unit army is preselected; no account or player-name step exists. The briefing explains four battles and temporary upgrades. Draft 1 appears before Battle 1. Starting the draft creates and persists the run identity, seed, selected loadout and offer before interaction.

Tutorial steps are contextual: deploy a Shieldguard; deploy a Crossbowman; activate Rally when available after the first engagement. Instructions pause the model only while the explanatory overlay is open. Dismissing the explanation resumes play and waits for the player's real command; it never spends, deploys, or grants cooldown bypass automatically. A tutorial prompt must never require a command while the model is still paused. Skip is available and reported separately from completion. Commercial suppression lasts the entire first attempt even when skipped.

## Normal expedition loop

Home → Army/Briefing → Draft 1 → Battle 1 → bank reward/Draft 2 → Battle 2 → bank reward/Draft 3 → Battle 3 → bank reward/Draft 4 → Battle 4 → Results → Home.

Loadout locks at the first draft. Upgrades persist for that expedition only. Units, health, barrier state, deployment counters, Supply, Rally and base health reset for each new battle. The next encounter's explicit starting values apply; the previous battle's health deficit is not carried forward. This is a four-battle build arc, not an attrition campaign.

One upgrade is chosen before every battle, producing four total choices. Each is single rank and cannot be chosen twice. The player sees three eligible options. One free reroll and one additional rewarded/direct-claim reroll are expedition-wide, not repeated for each draft.

## Decisions during battle

Supply buys troops. One completed tap attempts one deployment; held touches do not create continuous deployment. Units move and attack automatically. The player decides what to deploy, when to save Supply and when to use Rally. Supply stops accumulating at its cap. Buying an expensive Ram means foregoing immediate defenders; that opportunity cost should be visible.

Readability comes from distinct silhouettes, costs, range and attack cadence. A unit's stated role does not override physical targeting. No cavalry/archer shortcut, flanking, teleporting or target immunity is added. The castle does not shoot, heal or repair itself. Supply is not mana for an undisclosed spell system.

## Result and progression

A battle win grants its encounter Medals exactly once and saves the next checkpoint. The final battle also grants completion and, when eligible, first-clear rewards. Defeat or draw ends the expedition and keeps already-banked wins. No unresolved-battle reward is granted.

On a successful expedition, the next expedition unlocks using the predecessor recorded in `expeditions.json`. The ninth clear completes the campaign but leaves every unlocked expedition replayable at its existing rules and rewards. There is no endless mode, prestige, new difficulty ladder or daily challenge screen.

Unlocks add choices rather than permanent power levels. Before buying Brute or Ram, the starter army must be capable of normal progression. The player may spend Medals on cosmetics first; the game must never soft-lock because of that choice. Cosmetic ownership is not a prerequisite to an encounter.

## Pause, quit and interruptions

Pause freezes all simulation clocks. Backgrounding or a store/ad overlay acquires its own pause reason. Returning from background leaves an active battle paused until the player resumes. Clearing one pause reason cannot accidentally resume beneath another overlay.

Returning Home between battles preserves the run. Starting a different expedition asks for explicit abandonment. A midbattle Home action saves the existing prebattle checkpoint and leaves that battle to restart on Resume; UI states this rather than promising exact midbattle recovery.

Force-closing during battle restarts the same battle from its prebattle state. No partial progress or battle reward is fabricated. Force-closing at a draft restores the same offers and allowances. Loss then Retry begins a new run at Battle 1; it is not a free revive in Battle 4. Abandoning banked progress does not claw back already-earned Medals.

## Pacing and experience targets

The introductory battle targets 45–90 seconds, normal battles 90–150, strongholds 120–180 and an expedition 8–12 minutes including drafts. These are evidence targets, not artificial minimum durations. A valid fast strategy is not delayed merely to reach a timer. Overtime and a hard finish prevent indefinite stalemates.

The first-session test asks whether an unfamiliar player understands deployment, protecting ranged troops, temporary upgrades and the four-battle goal without a developer explanation. Replay value should come from trying a different army/upgrade combination, not sunk-cost pressure, compulsory advertisements or fabricated rewards.

## Definition of the finished placeholder game

The complete placeholder build includes every troop, upgrade, encounter, boss, screen, reward, save, purchase state, ad state, consent path and analytics contract. Development graphics may be simple, but layout, hit areas, pause behavior, foreground feedback and error handling are real. All later content uses the same identifiers and interfaces.

Final art generation is not a prerequisite to this milestone. Conversely, “we will fix the rules once the art arrives” is not an acceptable placeholder pass. Art later replaces presentation assets; it must not be asked to hide incomplete gameplay.


---

<!-- Source: bibles/02_COMBAT_SIMULATION.md -->

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


---

<!-- Source: bibles/03_CONTENT_AND_ENEMY_DESIGN.md -->

# 03 — Troops, upgrades, encounters and boss Bible

## Authoritative content

Every runtime content ID is stable and lower-case. Load JSON through one validated importer. Do not hand-maintain a second set of ScriptableObject numbers. Imported Unity runtime objects are generated, version-tagged projections of the source. Invalid or duplicate content IDs fail development validation and release builds; they do not silently spawn a generic unit.

The complete tables, individual upgrade behavior and ordered encounter queues are reproduced in Bible 20. `data/units.json`, `upgrades.json`, `encounters.json`, `expeditions.json` and `boss_variants.json` contain the machine-readable originals.

## Unit roles

**Militia:** 20 Supply, 70 HP, 11 troop/base damage, 0.80-second period, 0.20-second windup, 0.60 m range, 1.25 m/s speed. Cheap deployment and reserves. Its role is volume, not a secret evasion modifier. A swarm must still obey the three-melee-position and population rules.

**Shieldguard:** 45 Supply, 240 HP, 10 damage, 1.10-second period, 0.25-second windup, 0.65 m range, 0.90 m/s and flat reduction 3. Protects expensive ranged damage. The normal unit does not start with a temporary barrier; that is an upgrade or explicit boss effect.

**Crossbowman:** 50 Supply, 75 HP, 50 troop damage, 25 base damage, 1.80-second period, 0.35-second release, 5.5 m range and 1.05 m/s movement. A 12 m/s bolt gives high single-target damage but is inefficient into many cheap bodies. No free base damage through defenders.

**Grenadier:** 65 Supply, 90 HP, 36 troop damage, 18 base damage, 2.40-second period, 0.50-second release, 4.6 m range, 0.95 m/s movement, 8 m/s lob travel and 1 m ground splash. Punishes packed targets. It may miss a moving group because the ground point is fixed.

**Brute:** 110 Supply, 480 HP, 65 troop/base damage, 1.60-second period, 0.45-second windup, 0.85 m range and 0.72 m/s movement. Expensive slow frontline pressure. Its ordinary strike is single-target; sweeping requires its upgrade.

**Battering Ram:** 100 Supply, 420 HP, 14 troop damage, 150 base damage, 2-second period, 0.55-second windup, 0.85 m range, 0.80 m/s movement and flat reduction 2. It is poor at clearing defenders but strong after reaching a base. It occupies one melee engagement position and counts as one actor, not an entire group of invisible crew.

Enemy ordinary troops use the same baseline mechanics. Per-encounter advantage comes from declared income, fortress health, schedule and boss substitution, not hidden strength linked to player payments or losses.

## Upgrade catalogue

There are three unit-specific upgrades per troop: one behavior change and two simpler modifiers. Six general upgrades complete the 24. Names and text are presentation; `operator`, `value` and `additional_rules` are implementation data. Do not infer effects from the illustration.

Militia: Conscription, Scrap Blades, Thick Coats. Shieldguard: First Into Battle, Reinforced Shields, Heavy Boots. Crossbowman: Piercing Bolts, Tighter Windlass, Quick Reload. Grenadier: Packed Powder, Heavy Charges, Fast Fuses. Brute: Sweeping Club, Iron Belly, Brutal Force. Ram: Splintering Head, Siege Engineering, Reinforced Frame. General: War Economy, Deep Stores, War Drums, Field Training, Rapid Orders and Forced March.

Every effect, cap, modifier group and secondary rule is listed in the registry. Each has rank one and equal base selection weight. No rarity, upgrade leveling, paid rarity boost or Legendary category exists. Behavioral upgrades may create strong combinations; their visual effect should be obvious without requiring exaggerated numbers.

## Draft algorithm

A four-unit loadout initially has 18 eligible upgrades: 12 attached to its units plus six general. Exclude every already-selected upgrade. Sort eligible IDs before random sampling so dictionary iteration cannot change offers.

Draft 1 reserves one uniformly sampled eligible behavior upgrade, then fills remaining positions from the rest without replacement. Drafts 2–4 reserve one eligible troop-specific upgrade and one general upgrade when available, then fill from the remaining eligible pool. If a required class has no candidates, fill from the other eligible pool. Shuffle the three completed offer positions using the same deterministic generator. A validation failure with fewer than three eligible distinct IDs is a content error, not permission for an empty card.

Use XorShift32, nonzero unsigned state, shifts 13/17/5 with unsigned wrapping. Bounded sampling uses rejection rather than biased modulo. XorShift32 outputs nonzero values: subtract one to obtain the uniform domain 0 through 2^32−2, reject values at or above `0xFFFFFFFF - (0xFFFFFFFF % bound)`, then take modulo. `tools/reference_math.py` fixes this exact mapping and the draft sampling/shuffle order for cross-language fixtures. Persist run seed, current generator state, three offers, draft index and offer ordinal before showing the UI. A fresh run seed comes from platform cryptographic randomness once. The seed has no role in combat hit chance.

Reroll replaces the offer by another valid complete sampling pass. Unselected cards can reappear; it does not promise three entirely new cards. One free and one additional ad-backed/direct claim exist per expedition. Persist allowance consumption and new offers together. Failed or cancelled ads do not spend the allowance. Choosing persists the upgrade before transitioning to the next battle. Replaying a command after a crash cannot choose twice.

## Enemy queue engine

All 36 queues are explicit finite lists. `enemy_first_deployment_earliest_s` controls the opening. After a successful purchase, the next permitted deployment is at least 1.2 seconds later. If the next item is unaffordable or the alive cap is full, wait; do not skip it, substitute another, repeat the queue or spend extra funds. One successful queued purchase is processed in a tick.

The enemy uses its recorded starting bank, rate, capacity and exact total supply budget. Queue length can exceed 24 because dead units free capacity over the battle. The 24 cap is living actors, not cumulative deployments. Deadline expiry at 180 seconds discards unresolved orders; no wave bursts are deferred beyond that point.

Pattern names such as `shield_line`, `swarm`, `artillery`, `brute_guard`, `siege_push` and `mixed` explain the authored order. They are not instructions to implement adaptive AI. Enemy decisions cannot examine payer status, advertising consent, prior defeats or the next queued player command.

Each encounter also identifies chapter, expedition, battle index, environment, target timing, win Medals, fortress health and optional boss. A briefing shows the relevant enemy doctrine and boss presence without needing a narrative or quest system.

## Boss variants

Bulwark derives from Shieldguard: 480 HP, 12 troop/base damage, ordinary movement/period/reduction and a 144 HP barrier activated by first positive damage for eight seconds. Powder Captain derives from Grenadier: 158 HP, 41 troop damage, 21 base damage, 1.5 m splash and ordinary movement/period.

A boss replaces the exact zero-based queue index recorded for that encounter. It does not add another unit or charge both the base troop and the boss. Its supply cost equals its base unit as an explicit encounter-budget exception. One boss maximum is present in any encounter. Show the boss in briefing and reveal its approach at least three seconds before its earliest permitted deployment. This reveal is informational and never spawns the boss early.

No boss phases, summons, special spells, extra animations, invulnerability window or camera takeover are added. Final boss art is a variant of its unit, produced after the placeholder game is accepted.

## What must be tested

Every four-unit loadout has exactly 18 initial eligible upgrades. All 15 possible loadouts are valid. Every expedition contains four unique ordered encounter IDs. All 36 encounters are assigned exactly once. All boss indexes refer to the correct base unit and fourth battle. Every queue's sum of unit costs equals its recorded total budget.

Funding-only checks show whether an order can be bought before 180 seconds without combat/cap interference. They do not show whether it will spawn during a real fight. A queue can legitimately be delayed by surviving troops occupying the cap; its stored earliest schedule must never be represented as measured battle length.

Balance analysis includes single-unit spam, protected ranged, swarm, Ram rush, hoarding and multiple Rally timing policies. Record seeds and action policies, then run human playtests. A powerful combination is not automatically a bug; a universal cheap strategy that makes the rest irrelevant is a design issue requiring evidence and a B002 amendment.


---

<!-- Source: bibles/04_CAMPAIGN_ECONOMY_MONETIZATION_DESIGN.md -->

# 04 — Campaign, economy and commercial-design Bible

## Campaign progression

The nine expeditions are ordered by `unlock_after_expedition`. Only the first is initially available. A successful four-battle clear permanently unlocks its successor. A loss or draw does not advance the campaign. Replay remains available after a clear. There are no star ratings, ranked ladders, difficulty toggles, mastery currency or recurring challenge schedules.

The chapter map is a presentation of three expeditions per chapter, not a procedural world. Inside an expedition the four-battle indicator tracks the current attempt. Do not mistake the four visible battle nodes in an early mockup for four expeditions in each chapter.

Player fortress health and all transient combat state reset per battle. Enemy baseline stat multiplier is one; declared fortress HP and funding change across encounters. Higher chapters introduce queue compositions and the two defined boss variants. Do not build permanent player damage upgrades to compensate for arbitrary enemy inflation.

## Persistent Medals

Medals start at zero and are earned, not purchased. Brute costs 40 and Ram costs 80. Earned banners cost Oak 160, Barrel 340 and Iron 700. The full earned catalogue costs 1,320. A player can buy in any affordable order. Unlock purchases atomically subtract Medals and mark ownership. Buying an already-owned unlock is a no-op with no charge.

The default cosmetic appearance exists without an unlock and is not a sixth paid sink. A paid Army Pack is separate from these earned banner records. Selecting a cosmetic never changes hitboxes, prices, stats, projectile speed, visibility of gameplay warnings or enemy targeting.

All Medals are integer units. Wallet bounds, intermediate sums and save serialization use 64-bit integers. No fractional or negative reward is allowed. A local checksum is for corruption detection, not security. Local Medal tampering is an accepted single-player risk; no anti-cheat subsystem is added.

## Reward ledger

A chapter 1/2/3 battle win grants 10/15/20. Completing an expedition grants an additional 20/30/40. Its first clear adds 20 once. Full first-clear totals are 80/110/140. Repeat full-clear totals are 60/90/120.

Battle rewards settle immediately after win and before another draft. A later failure leaves them intact. First-clear belongs to the expedition, not each intermediate battle. A final battle victory performs its win, completion, first-clear and campaign-unlock transaction exactly once using stable reward IDs.

Results show base earned amounts and bonus eligibility without fabricating a transfer that already happened. Mark already-banked rewards clearly. Reopening Results does not pay again. An abandoned run retains committed earlier wins but does not acquire another completion bonus. Explicit abandonment does not create a new Medal-ad claim opportunity; a normal resolved loss/draw with prior wins can show the one existing results placement.

## Earned-progression route

For full wins through all nine expeditions in order, buying troops before banners and then replaying the final expedition, the no-ad milestones are Brute after clear 1, Ram after clear 2, Oak after clear 4, Barrel after clear 7 and all five purchases after clear 12. The nine first clears total 990; three final-chapter repeats add 360, leaving 30 after all 1,320 costs.

Taking every eligible Medal bonus shortens the same full-win route to clear 10. This is arithmetic under stated assumptions, not a universal playtime promise. Losing, replaying early chapters, buying cosmetics first or declining bonuses changes the route. The reference tool prints every wallet transaction so a later B002 can explain its change.

## Rewarded placements

There are two, and only two.

**Additional draft reroll:** the player has one free reroll per expedition. Once it is spent, one additional reroll can be earned through an optional rewarded ad. A paid Ad-free Bonuses entitlement exposes the same action as a direct claim. The allowance is expedition-wide. No unlimited sequence or per-draft reset exists.

**Results Medal bonus:** once per resolved expedition with at least one battle win, award `floor(bankedBattleWinMedals * 0.5)`. Exclude completion and first-clear bonuses. It is valid on a partial-loss result because earlier wins were earned. Hide it once all five earned unlocks are owned, or when there is no eligible reward. Never increase the base amount because the player declined an ad earlier.

Suppress both commercial offers during the first expedition attempt even if the tutorial was skipped. Ads never appear during active combat. No interstitials, banners, startup ads, forced revives or ads on every results transition exist. A missing ad is a normal unavailable state, not a reason to block Play or remove base rewards.

## Non-consumable products

`adfree_bonuses`: Ad-free Bonuses, US base price $4.99. The extra reroll and eligible +50% Medal claim become immediate actions with the same limits. One free reroll remains for everybody. It does not imply that the free version contains forced ads. Product text explicitly says the Medal benefit ends when all earned unlocks are owned. After that, explain the remaining additional-reroll benefit; do not advertise a nonexistent permanent multiplier.

`cosmetic_army_pack`: Cosmetic Army Pack, US base price $2.99. One coherent set of banners, equipment markings and fortress accents. No damage, HP, extra currency, exclusive unit or gameplay advantage. Existing strings and product IDs are authoritative; do not rename it Royal Army Pack merely because a concept sheet did.

Native store price strings supply localized prices and currency. The source's USD amounts are base-price configuration hypotheses. Runtime monetary arithmetic uses integer micros/minor units, not binary floats. Product disappearance, pending payment and verified ownership have distinct UI states. Restoration restores purchases, not campaign progression.

## Commercial constraints and ethical design

No randomized paid rewards, personalized difficulty, pressure timer, deceptive discount, fabricated scarcity, rating reward or review gating. Do not describe a player who watches no ads and buys nothing as playing a trial. The full campaign is free.

A finite catalogue limits Medal-ad demand. Two one-time products cannot be modeled as recurring subscriptions. Cosmetic purchase interest, retention and organic acquisition remain unvalidated. A monetization problem does not authorize a new sink or permanent upgrade tree.

The design can be implemented and tested without live purchases: fake adapters are explicit development states. Only license-tested, owner-authorized service integration may connect to real merchant systems. No sale of placeholder cosmetics to ordinary users is allowed.

## Economy acceptance

Check grant identity at every interruption boundary, first-clear once, replay amounts, partial-loss preservation, no negative wallet, no duplicate unlock, finite-bonus suppression, one additional reroll, reset retaining purchases, and migration retaining already-earned progress. Simulate route totals from the actual registry. Compare earned progression separately from retention and net revenue; a complete wallet spreadsheet is not evidence that the game is enjoyable.


---

<!-- Source: bibles/05_UI_UX_AND_COPY.md -->

# 05 — UI, UX, input and copy Bible

## Common interface contract

Build functional UI now with Unity text, simple panels and primitive icons. Preserve the hierarchy, spacing budget, data binding, error states and input hit areas that final art will use. Approved generated images are style references, not executable UI specifications. The visual sheet's extra Army Power, stars, numeric values and language selection are explicitly non-authoritative.

The reference canvas is 1920×1080 landscape with a safe-area root and CanvasScaler. The battle's initial top HUD budget is 112 reference pixels, bottom control strip 224, and side margins 32. These are provisional geometry for real-build review, not permission to shrink text to an unreadable physical size. Primary targets are at least 48 dp. Body text starts at 24 reference pixels and important numeric text at 28; test actual phone-scale readability.

No live text, number, price, progress indicator or legal wording is baked into an image. All English strings in `strings_en.json` use stable IDs and typed replacement parameters. Dynamic integer amounts use the same model calculations as controls and reports. Never add a localization picker that implies untranslated languages exist.

Pointer-down shows feedback; pointer-up inside the originally pressed control commits once. Dragging outside cancels. Held fingers do not auto-deploy. Disabled controls show why: funds, cap, cooldown, lock, offline or service unavailable. Haptics alone are never the only feedback.

## Home / Campaign

New state: show first available expedition, chapter context, the selected starter army and Play. No ad, daily reward, inbox or promotional modal. Progress state: show three chapters and exactly three expeditions within each, with locked/available/completed distinctions. Locked cards state the predecessor requirement without opening a fake paywall.

A resumable run presents Resume prominently and indicates battle/draft position. Selecting another expedition requires abandonment confirmation. Campaign-complete state permits replays and clear completion acknowledgement; it does not show an unimplemented endless mode. Army, Shop and Settings remain accessible without entering battle.

No portrait-only bottom navigation is required. The approved composite navigation is styling inspiration; functional main views and overlays remain the source's six-view layout. Safe-area changes must not move hidden actions outside touchable space.

## Army

Display all six units with role, cost, brief strength/limitation, ownership and selected state. Four slots must contain different owned troops before starting. Equip/unequip is explicit. When Brute/Ram are locked, show exact Medal cost and wallet; purchase atomically unlocks them. Do not allow editing an active expedition's loadout.

Selecting a unit opens details using source stats with active context indicated: base data outside a run, modified stats only where the UI explicitly identifies the run. Do not show an invented composite Army Power score. Cosmetic selection previews owned or purchasable appearances, clearly distinguishing preview from ownership. Placeholder cosmetics use labeled color/marking variants, never real-money promises of unmade art.

## Briefing

Summarize selected expedition, four battles, expected enemy doctrine, known boss presence, active loadout and that upgrades are temporary. Play creates the run and opens Draft 1. Cancel returns without starting a new seed or consuming a reward allowance. Do not introduce a narrative/dialogue subsystem.

## Battle

Top: both fortress HP values/bars, expedition battle index, elapsed time/overtime state and Pause. Supply: current/cap plus rate where readable. Bottom: four equipped troop controls showing name, portrait/placeholder symbol, current modified cost and availability. Rally shows first cooldown, ready, active and cooldown separately. Optional population label explains the cap when relevant.

The battlefield displays reachable frontline, distinct troop classes, projectile releases and outcomes. The same logical lane and fortresses remain visible at all supported aspect ratios. A large central logo is decorative and must not obscure combat or take the place of needed state information.

When Supply is insufficient, do not pulse a purchase shortcut. When cap-full, do not spend and create an invisible queued unit. Button cooldown must match the next legal model tick. Game-speed controls are development tools only, excluded from shipping gameplay.

Overtime shows an explicit message that fortress damage is doubled. At enemy reinforcement cutoff, an informational indicator may state no further enemy reinforcements; no new ability appears. Victory/defeat/draw lock further deployment and route into durable result settlement. Never process user taps through the results overlay into a previous battle.

## Draft

Three readable cards show name, icon, exact effect and relevant unit. Selected upgrades are visible in a compact run summary. Choose commits one valid card, persists it and opens the battle. No card rarity or paid best-choice lock exists.

The free-reroll state shows one available allowance. After use, the optional additional-reroll state shows its own single allowance. Show loading, unavailable, consent-restricted, ad in progress, earned/committing, consumed and error states without mixing them with ordinary Choose. An ad failure leaves the existing three offers selectable.

After allowance settlement, the three new offers are shown together. App restart restores that result, not the prior allowance. Repeated taps while save/claim is committing are rejected without duplicating purchase or generator advancement. UI card position does not change the meaning of the source upgrade.

## Results

Intermediate wins primarily lead to the next draft, with the already-banked encounter reward shown. There is no repeated first-clear or per-battle results advertisement. Final/failed/drawn expedition Results shows battles won, banked wins, final completion amount, first-clear amount if applicable, total and optional result bonus separately.

The Medal bonus is based only on banked battle wins. Example: a chapter 1 expedition first-clear pays 80 base total, but its eligible bonus is 20, not 40. Claim once and display its settled state after re-entry. After all earned unlocks are owned, omit the placement rather than an empty ad button.

No star rating or new performance reward exists. Battle summaries may show factual source statistics; qualitative advice must be derived from measured events, not a fake AI analysis service. Home and Retry behavior follows the run lifecycle; Retry on defeat means a new expedition at Battle 1.

## Shop

Exactly two permanent products. Show accurate previews, entitlements, limits, localized store prices, ownership and Restore Purchases. States: service boot, loading catalogue, available, unavailable/offline, initiating, store overlay, pending payment, verifying, owned, cancelled, recoverable error and restore complete/no items.

No price is shown as a live payable price before store data is available. A development sample price must be visibly non-purchasable. Pending payment means no benefit yet. Already-owned items do not offer another purchase. Do not require a purchase to leave the Shop or return to offline play.

Purchase copy explains finite Medal value and local-only campaign storage. No hidden account registration, premium currency, offers carousel, loot chest or “starter pack” is added. Store-owned payment UI is not replicated with custom fake buttons.

## Settings, Pause and support

Settings: Music/SFX/UI levels, haptics, reduced motion, reduced flashes, render-quality/FPS fallback as implemented, privacy choices, support information, versions, Restore Purchases, Third-Party Notices and Reset Local Progress. Every displayed option must have working behavior; no inactive controls are included for future features.

Pause: Resume, Settings, Home with a clear checkpoint explanation, and explicit Abandon. Android Back closes the top dismissible modal; in active battle it opens Pause; in menus it goes toward Home. OS/store/consent surfaces have priority. Multiple pause reasons are reference-counted/tokens, not one fragile boolean.

Support copy can expose/copy app version, source/balance version, device model, OS and a pseudonymous diagnostic identifier. Do not put raw tokens, email, order details or save contents in routine diagnostics. Opening email/browser requires an explicit tap. Before a support route is provisioned, development builds say it is not configured; they do not invent an address.

## Error and destructive states

Save failure: preserve last valid data, show retry and an honest blocked action. Do not report a successful unlock whose save failed. Recovery: explain that a backup was loaded. Unknown newer save: preserve files and show incompatibility; never silently reset. Reset: two confirmations, exact local-progress-loss language, entitlements and privacy/accessibility retained.

No-network: offline core remains available. Ads unavailable: base gameplay and other draft cards remain usable. Billing unavailable: Shop/Restore error only. Analytics unavailable: no player-facing gameplay error. Receipt verification delayed: retain old verified benefits and show pending new ownership. Source/content validation failure: development diagnostic; release must never be built in this state.

## Accessibility and final styling

No team or control meaning depends only on red/blue, sound, flashing or vibration. Respect both landscape orientations, cutouts and system display scaling. Test alternate price lengths and text wrapping. Effects cannot cover buttons. Do not claim full screen-reader or formal accessibility certification without testing it.

Final panel borders, typography sizes, lighting/shadows, contrast treatment and icons are approved later from screenshots of these actual screens. A generated paintover may propose a layout change, but Codex does not apply it silently: annotate, approve and update the source geometry first. Style approval alone is not a change to input behavior or costs.


---

<!-- Source: bibles/06_SAVE_AND_RECOVERY.md -->

# 06 — Local state, saving and recovery Bible

## Storage promise

The whole campaign, army choices, Medals, unlocks, draft state and settings are local. No player account, cloud sync, server save or cross-device progression exists. Uninstalling, clearing app storage or changing device can lose campaign progress. Play purchases are separately restorable through verified ownership. A backup in the same app sandbox protects some corruption cases, not uninstall or device loss.

The source chooses schema S1, a UTF-8 JSON envelope with an explicitly hashed payload, active file, temporary write file and last-known-good backup. PlayerPrefs may hold noncritical preferences but is not authoritative campaign storage. Android backup/device-transfer exclusions must match this local-only promise and exclude entitlement material.

## Required logical payload

Persist schema, revision, content/balance version, settings, privacy choice, wallet, owned troop IDs, owned banner IDs, selected cosmetics, cleared expedition IDs, tutorial flags, preferred loadout, active run, last unsettled result/claim, settled grant identities and cached signed entitlements. Store only data, never serialized Unity scene objects or provider callbacks.

An active run includes run ID, expedition ID, four troop IDs, selected upgrades, battle index, phase, initial seed, PRNG state, current three offers, offer ordinal, free/additional-reroll allowance state, banked battle-win total, completed battle IDs and prebattle checkpoint. Content hash is pinned for the run. The prebattle state contains what is needed to start the same authored battle; it is not a frame-by-frame snapshot of actors.

`templates/SAVE_S1_EXAMPLE.json` is a synthetic schema fixture, not a real player's save or entitlement. Runtime must validate every content reference, wallet bound, uniqueness constraint and phase relationship before accepting a payload. Reject unsupported newer schema non-destructively.

## Encoding and integrity

Use an envelope containing schema, payload JSON as an exact UTF-8 string, and SHA-256 over that string's exact UTF-8 bytes. The payload string removes cross-language ambiguity about property-order canonicalization of a parsed object. When writing, serialize payload once, hash those bytes, then embed it safely in the envelope. A new schema may choose another encoding through an explicit migration.

The checksum detects corruption, not local cheating or purchase ownership. An attacker can edit both payload and checksum; this is acceptable for offline Medals. Purchased benefits are enabled only by valid signed server receipts, never a boolean plus checksum.

## Atomic write protocol

Build the entire new payload in memory, validate it, serialize/hash, write to a temporary sibling, flush as supported and read back to verify. Preserve the last valid active copy as backup, replace active using the platform's safe file operation, and verify the resulting active envelope. Never erase the only valid copy first.

A process kill between any two file steps must leave at least one recoverable valid state. Tests simulate every interruption, low disk space, permission failure and corrupted active/backup combinations. Ignore or quarantine a partial temp file unless it is explicitly validated and newer by the defined revision policy. Keep recoverable corrupt files only for local diagnosis; do not upload them by default.

On save failure, retain the last valid state and show the affected transaction as not completed. Block only conflicting further mutations until recovery, not unrelated offline navigation. Do not continue accepting wallet spends into unpersisted memory and hope that quitting saves them later.

## Idempotent reward transactions

Use deterministic grant keys, for example run ID plus battle index and reward type, and a separate expedition-first-clear identity. Bank the battle result, wallet delta, completed-battle marker and next phase in one revision. Duplicate callbacks, repeated Results entry and process restart reapply no settled grant.

Completion/first-clear/campaign advancement form one atomic transaction. Reroll allowance and new RNG state/offers form another. Unlock spend and ownership are another. An entitlement refresh and local signed-receipt journal are another. Do not split an operation across independent PlayerPrefs and JSON files.

Keep active-run grant identities until no interrupted callback can legitimately refer to the run. Retain enough settled results for recovery without unbounded logs; prune only fully settled old run records at safe Home checkpoints. First-clear IDs remain permanently because they constrain rewards. Retain the most recent32 fully settled closed-run summaries; prune only at a safe Home commit. Never prune permanent first-clear identities or unresolved earned receipts. The1MiB envelope limit and nonnegative signed64-bit wallet limit are in `contracts/save_constraints.json`; reject overflow before commit rather than wrapping.

## State transitions and recovery

A saved phase is explicit: Home/NoRun, DraftPending, BattleReady, BattleActiveWithPrebattleCheckpoint, RewardCommitting, NextDraftReady or ExpeditionResult. The source state graph prevents illegal transitions such as a fifth draft, a battle without its preceding upgrade or starting a new run while the old one has an uncommitted reward.

When a battle is active at process termination, restore its saved prebattle state and start that same encounter on Resume. Do not carry partial damage, elapsed time, current Supply or newly spawned actors. Previously banked rewards and previously chosen upgrades remain. A player can replay a battle's execution by restarting, but cannot reroll the draft or multiply a reward; anti-restart punishment is not added.

A draft reload restores offers and allowances exactly. A won battle whose reward was committed before a kill resumes after the win. A reward whose commit did not complete resumes from the last valid revision with no fabricated wallet change. A normal lose/draw result preserves earlier grants. Abandon preserves banked rewards and removes the active run after confirmation.

## Settings, reset and backup

Settings apply immediately to the current presentation and persist separately within the same envelope. Reset removes wallet, earned unlocks, campaign and run data, but retains purchased entitlements, privacy choice and accessibility/audio settings. Reset never requests a refund. Show two clear confirmations and the distinction from Restore Purchases.

Restore Purchases queries actual Play ownership online and verifies returned tokens. It does not claim to reconstruct the player's Medals or cleared campaign. A failed network request retains last verified ownership. A known authoritative revocation updates benefits at the next safe boundary; no retroactive Medal debt or deleted campaign is imposed.

No time-based currency, daily reward or offline income exists, so no anti-clock-cheat subsystem is required. Server signed receipt timestamps are for security/diagnostics, not advancing gameplay. Offline entitlement continuity and refund-recognition limitations are documented in the services Bible.

## Updates and migration

Every public save schema is retained as a fixture for future updates. Migrations are deterministic, reversible through backup where possible, and preserve earned value. An active run pins its old content version. Ship compatible data or safely end only that incompatible run while preserving banked rewards and explaining the interruption. Never reinterpret an old unit ID as a different unit silently.

Test previous public build → next build, interrupted migration, downgrade attempt with newer schema, old cached entitlement keys, privacy-state migration and restored ownership. A new app version does not automatically require a save-schema increment. A balance version change does not permit wiping progression.

## Acceptance

Pass requires recovery from deliberate active-file corruption; no loss/duplication at each transactional kill point; no grant on pending purchases; no consumption of rerolls on cancelled ads; same draft after restart; first-clear once; reset preserving verified purchases; non-destructive newer-schema handling; and working offline boot. The included source checks validate synthetic examples only. Real filesystem and Unity lifecycle tests remain implementation work.


---

<!-- Source: bibles/07_TECHNICAL_ARCHITECTURE.md -->

# Bible 07 — Technical Architecture

**Authority:** implementation architecture ARC001. Gameplay remains B001; workflow WF002. This is a Unity application specification, not existing executable code.

## 7.1 Project boundaries

Create one dedicated repository/workspace, not a branch inside Roman Legacy, BBGL, or Reactorfall. Extract the handoff contents into the new workspace root, retaining its `bibles/`, `data/`, `contracts/`, `tasks/`, `tools/` and root instructions. Codex later creates `Game/` for Unity, `Services/Entitlements/` for the backend, and `ImplementationEvidence/` for its own results beside those source folders. The included `evidence/` remains the source-package audit, not runtime proof. Do not nest a second competing source copy. Do not copy another game's databases, legal identities, platform credentials, scenes, or monetization code without a separate reviewed reuse decision.

Use `OneLaneWar` as the C# namespace. During local proof use the explicitly development-only application identifier `com.example.onelanewar.dev`. That identifier is not commercial clearance, must never be registered as the production app, and is a release-validation failure. The owner’s final package ID is a deployment input, not a reason to block offline placeholder work. Keep environment identities in an explicit build profile rather than scattered string replacements.

Runtime module responsibilities are deliberately limited:

| Module | Owns | Must not own |
|---|---|---|
| CombatModel | fixed-point state, commands, movement, attacks, outcomes | Unity objects, money, network |
| Content | typed validated registries and immutable configuration | mutable player inventory |
| RunProgression | expedition/draft/campaign/reward transitions | effects that award damage |
| Save | atomic persistence, recovery, migrations | balance decisions |
| Presentation | unit views, camera, animation, HUD, audio/VFX | authoritative HP/Supply/Medals |
| PlatformServices | consent, ads, purchases, diagnostics adapters | mandatory online gameplay |
| EditorValidation | import, build, capture, developer harness | release-only secret storage |
| Tests | pure model, Unity, integration and regression fixtures | fake production PASS reports |

Assemblies should express these dependency directions. Do not introduce ECS, a general-purpose dependency-injection framework, a custom scripting language, a networking layer for combat, or microservices. Plain C# classes and small interfaces are sufficient. No core combat class inherits MonoBehaviour. A scene disappearing must not destroy the only authoritative record of a reward.

## 7.2 Scenes and lifetime

Use one bootstrap/menu scene and one reusable battle scene. The bootstrap lifetime owns content, settings, save, run coordinator and adapters. Battle lifetime owns the model instance, presentation pools and subscriptions. All six main screens are views within these two scene responsibilities, not six separate world scenes. Game initialization orders local settings and save before network work. Invalid core content is a clear local fatal error with a diagnostic code; unavailable optional services are not fatal.

Every event subscription has a matching disposal path. Scene transitions cancel outstanding view requests, not earned transactions. At the end of battle freeze model input, settle the result once, commit the new checkpoint, then show the next screen. A failed commit holds a recoverable state rather than silently advancing. Re-entering the same scene does not initialize a second Firebase instance, duplicate music loops, purchase listener, or analytics session.

## 7.3 Adapter contracts

The detailed operation/state contracts are in `contracts/platform_interfaces.json` and `contracts/service_api.json`. Required abstractions are `ISaveStore`, `IAnalytics`, `IDiagnostics`, `IConsentState`, `IRewardedAds`, `IPurchases`, `IEntitlements`, `IRemoteSettings`, `IAudioOutput`, `IHaptics`, and `IPlatformLifecycle`. Fake, unavailable and real adapters implement the same contracts. Fake adapters expose explicit scenario controls in developer builds. They are never called a live integration.

Commands return explicit accepted/rejected/pending results with stable reason codes. UI presents those results; it does not infer success from a sound or button animation. Main-thread presentation consumes model events after a completed tick. A network callback arrives through a main-thread dispatcher before touching Unity objects. Durable grants and backend idempotency do not depend on which thread rendered a toast.

Every asynchronous operation carries an operation ID, originating run/draft/product where applicable, cancellation scope, and terminal status. Cancelling a screen request does not cancel a completed store purchase or erase an earned ad reward. Timeouts mean unknown/retryable when the remote system may already have committed; they do not prove payment failure.

## 7.4 Clocks, input and suspension

Combat uses its own integer tick, not wall-clock time, Animator speed or arbitrary deltaTime accumulation. Render interpolation observes neighboring simulation states. A frame accumulator may process multiple fixed steps when rendering is slow; the developer speed control schedules more identical steps, never changes the 0.05-second step size. A hard per-frame step budget should yield to rendering without skipping or coalescing authoritative impacts. Report severe backlog in development.

Pause is a set of reasons: player menu, focus/background, system overlay, consent/store/ad overlay, and blocking save/error state. Releasing one reason cannot resume while another remains. Background entry clears held input and the accumulator's suspended elapsed time. Returning from background presents an explicit paused state; no catch-up Supply, enemy purchases or Rally time is credited. The phone date has no progression use: there are no daily rewards, energy, or offline-income calculations.

Use the Input System for touch and editor pointer tests. Pointer-up inside the original enabled control is a single command; dragging outside cancels. Multitouch cannot bypass deployment cooldown. Keyboard shortcuts are developer harness conveniences only, not a marketed PC/controller mode. Inputs behind a modal are blocked. Changing application focus during a press cancels that press.

## 7.5 Content and representation

Import canonical JSON through a typed, deterministic importer. Generate runtime data from the current source hash; do not hand-edit a second set of ScriptableObjects and leave the JSON stale. Development can read JSON directly; release can use a validated bundled representation generated from the same bytes. Include an internal source/balance/content ID. Unknown IDs and missing references fail import; they never silently fall back to Militia or zero damage.

Model units, attacks, projectiles, damage events, barriers and command sequences use stable IDs. Unit views are pooled and bound to model IDs. Returning a view to a pool removes previous side, material, HP, animation, listeners, timers and cosmetic bindings. Cosmetic changes must not mutate combat configuration or hitboxes. A corpse is a presentation object, never a living actor.

At 48 living actors there is no need for speculative distributed processing. Prefer bounded arrays/lists and stable sorting to an elaborate scheduler. Avoid routine allocations in hot ticks and cache immutable lookups. If an actual valid battle exceeds a provisional projectile/VFX capacity, preserve gameplay and record the violation; never silently discard a damage-bearing projectile to satisfy a visual budget.

## 7.6 Rendering architecture

T001 selects built-in 2D rendering and OpenGL ES 3. The placeholder uses flat shapes, readable labels, primitive shadows and simple projectile/explosion cues. Final polish uses illustrated sprites, transform cutouts, materials and bounded particles. Do not import URP solely because a paintover says 'lighting'. A URP 2D Light or ShadowCaster prescription is not compatible by assumption with this baseline.

The default final implementation path is baked directional shading in artwork plus simple composited contact shadows and restrained material tinting. The precise light/shadow appearance is selected from captures after PH06. A need for a different renderer becomes a documented toolchain/presentation amendment with device and art cost evidence, not an implicit style change.

## 7.7 Offline and security posture

No network call is on the critical path to start, continue, or finish a battle. The application has no account authentication or cloud progression. It intentionally does not defend local Medals from a determined file editor. SHA-256 in saves detects corruption, not hostile manipulation. Protect real-money ownership through store verification and signed receipts; accept that a modified offline binary remains an anti-tamper risk in this small, noncompetitive game.

No runtime provider generation, reasoning-model calls, microphone, camera, contacts, location or notification feature. The intended runtime permission budget is zero prompts; inspect the merged manifest and any SDK permissions. A SDK-level normal permission is not automatically a gameplay permission. Unexpected wake/background behavior must be investigated rather than excused by the offline label.

## 7.8 Build observability and acceptance

Developer HUD shows source and model versions, tick, active pause reasons, Supply, base HP, alive counts, pending bonus, current enemy queue index, projectile count and result. It may show formation slots, ranges and hitboxes. It must be compiled out of release routes. Headless runs use the same combat assembly as Unity. Reference Python math in this handoff is an independent oracle for arithmetic, not a replacement combat engine.

Architecture acceptance requires a clean-checkout build, no assembly cycles, no network dependency for offline scenarios, no presentation-owned damage or currency, scene-reload subscription tests, and identical model outcomes across rendering speeds. Inspect the actual final commit; a diagram does not establish any of those properties.


---

<!-- Source: bibles/08_TOOLCHAIN_ANDROID_AND_BUILD_PROFILES.md -->

# Bible 08 — Toolchain, Android and Build Profiles

**Authority:** T001 is a selected version set. `data/toolchain_lock.json` is the exact table. Joint compatibility is NOT_BUILT. Version selection is not reopened as an owner question; a demonstrated conflict requires a numbered amendment.

## 8.1 Selection and sequencing

Use Unity **6000.3.21f1**, changeset `c02631ffc030`. Use its Android module and compatible bundled tooling. Android minimum/compile/target are **28/36/36**, IL2CPP, production **arm64-v8a**, OpenGL ES 3, built-in 2D and landscape-left/right only. The locked build tools are 36.0.0, NDK r27c / 27.2.12479018, Gradle 9.1.0, Android Gradle Plugin 9.0.0 and editor-bundled OpenJDK 17. Never substitute Android Studio's JBR casually. Capture the actual Java patch and binary hash during proof rather than inventing a separate patch here. [EXT01–EXT03]

The selected editor provides the editor-bound uGUI/Test Framework versions. Record the actual manifest and lock. Input System is 1.20.0 and Newtonsoft JSON 3.2.2. PH01 installs only what is needed for a clean offline project, import and tests. The selected commercial SDKs are reserved for PH05: Unity IAP 5.4.3 / Billing 9.0.0, Firebase Unity 13.17.0 / C++ 13.13.0 / Android BoM 34.19.0, one EDM4U 1.2.189, Google Mobile Ads Unity 11.5.0 / Android 25.4.0, and UMP 4.0.0. This corrects earlier instructions to force every SDK into the first placeholder foundation. [EXT04–EXT07]

Do not enable mediation, next-generation GMA, Unity Analytics, Unity D2C, a web shop, Firebase Auth/Firestore client/FCM/AI, or remote catalogues. Review the IAP package's own telemetry rather than assuming absence of Unity Analytics means absence of Unity data collection. Preserve a single dependency resolver.

## 8.2 Local tooling evidence

Android Studio is Quail 4 / 2026.1.4 Patch 1; the selected Emulator is 37.1.11. Host hardware, OS, virtualization and system images are not supplied by this package. Codex must inventory the actual workstation first. If a required executable or licensed editor is missing, report the exact requirement, detection command and blocked task. Do not manufacture an APK, emulator screenshot or test pass from source inspection. [EXT08–EXT09]

Record editor path/version/changeset; Unity licence availability without copying a licence secret; Android SDK package revisions; NDK source properties; Java version/hash; device/emulator list; ABI support; graphics mode; disk availability; and repository baseline. Record the commands and exit codes. The owner’s aggregate Unity licence eligibility is a separate business check, not an assumption based on this game's current revenue. [EXT30]

Use bounded installation requests only within the execution permissions of the issued task. This handoff does not authorize buying a Unity licence, provisioning paid cloud machines or changing another project's tools. Avoid machine-global changes when project-local/bundled tooling is available.

## 8.3 Android ABI and emulator reality

The primary development environment is Android Studio Emulator. Do not equate an x86_64 AVD with automatic ARM64 library support. Unity's x86_64 Android restriction and the particular system image's translation support must be checked. Google documents ARM translation for particular Android 11 images; that is not a blanket guarantee across newer/custom images, hosts, or every IL2CPP/SDK binary. [EXT09–EXT10]

Capture `adb shell getprop ro.product.cpu.abilist`, the system-image revision/fingerprint and actual native library load. The matrix includes API 28, 30 fallback, 33, 36 and a 16 KB environment. Mark incompatible rows **BLOCKED**, not PASS or silently removed. Do not disguise a new phone game as Magic Leap to access a restricted target. A compatible ARM64 device/image may be needed for a blocked row. That evidence is distinct from the owner's emulator-first development choice.

At least one actual ARM64 Android phone must receive a Play-installed release-candidate smoke test before publication. No new hardware purchase is authorized. Emulation can prove many OS/UI behaviors but does not establish real touch feel, heat, sustained battery use, haptics or every device driver interaction.

## 8.4 Build profiles

**Local development:** development identifier, Development Build on when useful, debug logging without secrets, test fixtures, fake/unavailable services, no real purchases or production analytics. Save data uses a development sandbox. Automated capture records whether the scene is a diagnostic fixture.

**Internal integration:** real SDKs configured against explicitly approved test identities, test ad units or registered test devices, licence-testing Google accounts, separate diagnostics environment, production-like IL2CPP stripping and signing path. A Play testing track by itself does not make purchases free; licence testers and actual test purchase dialogs must be verified. [EXT12]

**Release candidate:** final production identifier, Development Build and Script Debugging off, no debug entry points, ARM64 IL2CPP, conservative managed stripping initially, audited permissions, actual production service mapping, symbols/mapping retained, test credentials/fixtures disabled. Use LZ4HC where applicable and verify real download size rather than equating source ZIP size with the delivered app. Debug overlays may not be hidden only by an easily reachable menu flag.

Managed stripping, engine stripping, reflection and SDK/linker preservation must be tested together. Do not enable aggressive stripping simply to hit a size target. A symbolicated test crash and successful purchase/ad flow in a production-like build are stronger evidence than a debug-editor success.

## 8.5 Manifest and native compliance

Inspect the merged Android manifest, exported components, network-security configuration, permissions, billing dependency, advertising settings, backup/device-transfer exclusions and installed application ID. HTTPS is required for custom service calls. No certificate pinning at launch. Disable unnecessary exported components and cleartext traffic, subject to legitimate SDK requirements verified at integration.

Every native library in the shipped bundle participates in page-size compatibility, not just Unity's own library. Check ELF alignment, packaging and a suitable runtime environment. A selected NDK/editor does not prove third-party binaries comply. Inspect the actual AAB-generated APKs and Play pre-launch findings. API 36 is the project's target and matches the published requirement checked for this source; recheck the rule at real submission. [EXT11, EXT17]

## 8.6 Performance evidence

Targets are 60 FPS on the primary mid-range phone, stable 30 FPS fallback on the agreed lower tier, unchanged 20 Hz simulation, under 500 MiB steady-state process memory and under 150 MiB delivered download. Cold-start targets are four seconds mid-range/seven seconds low tier; warm Home-to-battle two seconds. These are internal goals and all remain unmeasured.

Measure frame-time percentiles, not just average FPS; cold/warm launches, repeated scene loads, 20-minute play, 24-vs-24 density, effects, ads and background cycles. Enable optimized frame pacing where supported and verify it. No background simulation or progression. No game-owned wake lock. Inspect SDK behavior separately. A no-growth memory result requires repeated measurements after comparable loads and garbage collection conditions, not one screenshot.

## 8.7 Reproducibility and amendments

A reproducible release record includes source commit, source manifest hash, editor/module identity, package/native locks, settings/build profile, imported asset hashes, environment mapping, versionCode, symbols and resulting AAB hash. A byte-identical rebuild is a separate reproducibility property affected by signing/timestamps; do not claim it merely because both builds launch.

On incompatibility preserve the failed dependency graph/log and minimal reproduction, identify the narrow affected pin, propose T002 with primary-source justification, run the relevant regressions, and obtain the required task/director approval. Do not quietly use 'latest'. Conversely, a security or store requirement may require an amendment; source lock is not permission to ship an obsolete or vulnerable dependency.


---

<!-- Source: bibles/09_SERVICES_PURCHASES_AND_ADVERTISEMENTS.md -->

# Bible 09 — Services, Purchases and Advertisements

**Authority:** S002 service consolidation and B001 commercial design. Real integration starts PH05, after the core placeholder game; no service is deployed by this document. The game is offline single-player, not a client of a combat server.

## 9.1 Service map and environments

Firebase Analytics/Crashlytics/Remote Config are managed optional services. AdMob supplies two rewarded placements. Google Play supplies two non-consumables. A small Firebase Functions service verifies purchases and reconciles ownership/refunds; Firestore Native is server-only. It stores no campaign, troop inventory, Medals, combat events or player account. There is no Firebase client authentication requirement.

The selected backend is second-generation Functions, managed Node 22, JavaScript ESM, firebase-functions 7.4.0 and firebase-admin 13.10.0, europe-west1. Initial min/max instances are 0/2, 256 MiB, one CPU, concurrency 10, 30-second timeout and 16 KiB request body. These are scaling controls, not guaranteed spending caps. Use a locked npm dependency graph and managed secret/key storage. No backend exists until an authorized integration task deploys one.

Separate development and production resource mappings. A build profile maps package/signing identity, Firebase app, ad units, product IDs, endpoint and public receipt keys. Missing production inputs fail the release preflight, but fake/unavailable adapters allow offline development. A diagnostic switch may simulate no-fill, pending payment or outages; it must not be reachable in the shipped product.

## 9.2 Purchase lifecycle

The UI obtains product metadata and localized price from Play. It shows what the permanent product does, the finite Medal benefit, no recurring billing, and no competitive/statistical advantage. It disables purchase while another conflicting store operation is active. The configured base prices are 499/299 USD cents, but the UI never fabricates a converted local price.

The normal flow is metadata ready → user invokes Play purchase UI → store result → pending or purchased → backend verification → durable idempotent entitlement record → acknowledgement → signed ownership receipt → durable client ownership cache → success presentation. A pending purchase grants nothing. A cancelled dialog grants nothing and is not an error requiring repeated prompts. A timeout after payment remains retryable/unknown, not proof the money was never charged. [EXT12–EXT13]

Backend verification checks package, allowlisted product, actual purchase state, token, quantity and revocation/acknowledgement state from the authoritative Play API. The installation/support ID and any client-supplied 'paid=true' flag are not proof. Use an access-controlled purchase-token hash as an idempotency index; protect the original token where authoritative reconciliation requires it. Never use a guessed order ID as universal purchase identity. Store acknowledgement must happen within Play's applicable window, ordinarily three days after PURCHASED, and be retried safely. [EXT13]

Only one owner performs acknowledgement. In S002 the backend acknowledges after recording verified ownership; the Unity integration must be configured so its client completion does not consume a non-consumable or independently award another entitlement. Implement the adapter deliberately for the selected IAP version. Repeated callbacks, acknowledgement retries, restore and server notifications all converge on the same entitlement, not multiple Medals or cosmetics. Unity IAP5.4.3 can report a DuplicateTransaction confirmation when a backend already acknowledged the order; map that outcome to the existing verified grant, not to ownership revocation or a second grant. [EXT05]

## 9.3 Ownership, offline receipts and restore

The server issues a signed ES256 receipt with format version, package/product, entitlement identifier, verified state, issue time, key ID and an installation-bound support reference where appropriate. Private signing keys never enter Unity/Git; public verification keys can. The exact JSON/OpenAPI transport fields are in `contracts/service_api.json`; examples contain no live credentials.

An already verified cached receipt remains usable offline. A temporary network error does not revoke an owned benefit. This accepts an unavoidable tradeoff: an offline device cannot immediately learn that a purchase was refunded. On reconnection, a verified revocation replaces the prior state; do not claim instant offline fraud prevention. No account/cloud progression is added to solve this.

Restore queries the store's actual owned non-consumables and verifies them. It restores benefits, not the campaign. A reinstallation may have no local save or signed cache; an online restore is then necessary. Account changes, already-owned dialogs and previously acknowledged purchases need their own tests. Do not bind ownership irrevocably to an installation ID such that a legitimate reinstall cannot restore.

## 9.4 Refunds and server operations

Real-time developer notifications are authenticated triggers to fetch authoritative purchase state, not trusted grants by themselves. Handle duplicate, delayed and out-of-order notifications. Reconcile missed or voided purchases through a bounded server job after integration approval. This is not client background polling and not a live-game server. Retain compatibility with installed public clients when changing response formats or rotating keys.

Restore/status endpoints accept only bounded allowlisted operations and validate bodies before outbound Play calls. Use least-privilege service identities, bounded retry/backoff, redacted structured logs and rate/volume guards. Play Integrity/App Check and certificate pinning are not v1 dependencies. Basic input validation and abuse limits are still required; 'no anti-cheat' is not permission for an open database or unbounded expensive endpoint.

## 9.5 Rewarded-ad transaction

There are only `draft_extra_reroll` and `expedition_medal_bonus`. Eligibility is calculated before displaying an offer. First introductory expedition attempt suppresses both even after tutorial skipping. No ad appears in active combat. Never automatically show an ad after losing, opening the app, selecting a troop or declining an offer. The ordinary reward is banked regardless of ad availability. [EXT14]

The flow is eligibility → explicit opt-in → load/show → earned callback → durable reward journal → grant exactly once. Persist an attempt ID tied to the relevant run/draft before showing. A close callback is not an earned callback. Failure/no-fill/cancel leaves allowances unchanged. A paid Ad-free owner uses the same grant transaction directly without contacting AdMob and with the same run limits.

While an ad is visible, hold the originating run/draft and pause reasons so gameplay cannot continue or abandon behind it. Earned callbacks on a dismissed view still commit to their originating transaction. Multiple callbacks, a late close, a failed save and a return from background must not grant twice. A successful earned callback that cannot be saved leaves a recoverable locked transaction, not a false success toast.

A killed process may never deliver a local earned callback. The app must not claim it can always infer that an ad was fully watched. Store the interrupted attempt and recover only from available legitimate evidence; do not grant an unlimited replacement or pretend a missing callback was verified. This is a release-test edge case and a support category. The selected backend remains purchase-only; adding AdMob server-side verification would be a separately approved service amendment, not silently invented scope.

## 9.6 Consent and initialization

Update required UMP privacy status before requesting affected ads, show required forms, check readiness and expose privacy options again when required. Treat consent, personalization and whether ads can be requested as distinct states. Refusing personalized advertising does not reduce normal gameplay rewards. Non-personalized ads are not automatically exempt from every storage/privacy obligation. [EXT15]

Behavioral analytics and optional diagnostics have deliberate defaults and a separate collection decision; UMP is not universal consent for Firebase or Unity package telemetry. Start optional collection disabled, with no pre-consent behavioral backlog. A plain-language diagnostics choice can be deferred without blocking the tutorial. Withdrawal stops future optional collection and invokes supported reset/deletion mechanisms according to the approved privacy mapping. Check actual network traffic in denied/accepted/withdrawn states, including automatic SDK initialization paths.

## 9.7 Outage matrix

| Unavailable component | Required behavior |
|---|---|
| Analytics/Crashlytics | play continues; no retry storm |
| Remote Config | safe bundled/last valid settings; no balance change |
| Ad network | offer reports unavailable; no progress loss |
| Play Billing | Shop metadata/purchase unavailable; campaign usable |
| Entitlement service | cached ownership honored; new verification pending/retryable |
| Internet | all local campaign features remain usable |

Client requests time out at 15 seconds, use bounded retry delays 1/4/15 seconds where the operation is safely retryable, then expose manual retry. Avoid synchronizing many clients into retries after an outage. Remote configuration fetches at most hourly and activates at Home/safe boundaries. Allowlisted switches disable new ad/purchase offers or show a support notice; they cannot erase paid rights or cancel earned rewards. Offline clients do not instantly receive switches.

## 9.8 Acceptance evidence

Use fake-adapter tests first, then genuine licence-testing transactions and test ad identities. Prove cancel, pending-to-purchased, restore after reinstall, already owned, duplicate callbacks, interrupted persistence, no-fill, consent refusal, refund/revocation, backend outage, account change and key rotation compatibility. Capture redacted receipt/operation IDs, actual test account classification, endpoint/build versions and resulting state. A Play test track user who is not a licence tester may make a real charge; inspect the actual billing dialog. [EXT12]

No service passes because an API method compiled or because a fake adapter returned success. Real integrations can remain a separately identified blocker while the offline placeholder game advances; they must pass before the release claims the relevant commercial capability.


---

<!-- Source: bibles/10_ANALYTICS_DATA_AND_DECISIONS.md -->

# Bible 10 — Analytics, Data and Decision Rules

**Authority:** A001 event catalogue, consolidated metric definitions, S002 privacy. There are 35 custom event definitions in `data/analytics_events.json`. Adding a telemetry SDK or a live A/B framework is outside scope.

## 10.1 Measurement purpose

The six dashboards are health, acquisition, retention, gameplay, monetization and cohort economics. Their job is to answer a decision, not maximize event volume. A debug event inspector and synthetic analytics journey are implementation requirements. Nothing in this source is connected to a live dashboard, deployed export, or measured player population.

Development/test/prod are separate. Test devices and licence-test purchases are explicitly flagged/excluded, not guessed from low revenue. Each event carries schema/source/app/balance/environment identifiers plus relevant run/draft/attempt identity. High-cardinality IDs belong in raw analysis, not dozens of custom summary dimensions. Never send raw purchase tokens, names, emails, support free text, exact location, or original provider account identifiers in gameplay telemetry.

## 10.2 Canonical event route

Model and run coordinators produce domain events. One analytics adapter maps them to the approved catalogue. UI re-renders do not re-emit wins, purchases or unlocks. Persist the corresponding settlement/event ID at transactional boundaries; deduplication downstream uses that ID. Consent-disabled mode emits nothing to remote behavioral analytics and does not queue a hidden backlog for later transmission.

Do not manually duplicate SDK-owned `first_open`, `user_engagement`, `ad_impression` or automatic purchase reporting when the selected integration already supplies the canonical fact. Keep the 35 custom names stable. `contracts/analytics_transport.json` defines flattening for structured fields and the normalization views; do not pass arbitrary nested dictionaries to an SDK that expects scalar parameters. Arrays such as offered upgrade IDs are compact, ordered, bounded strings with documented parsing. Aggregate counters are bounded scalar parameters or per-unit summary events already in the catalogue.

The session coordinator tracks foreground **gameplay** duration, not just an open Settings screen or background callback. It emits one `performance_summary` sample with `sample_kind=qualifying_gameplay` after the first10,000ms of actual foreground active-battle time in each new foreground play segment; its duration and sampled performance values describe that window. The additive transport fields `sample_kind` and `foreground_gameplay_ms` are explicitly defined in A001_TRANSPORT_1, preserving the35 custom event names. This marker, not simulation fast-forward time, maps to the qualifying activity view; test it before live reporting. Optional diagnostics sampling must not be confused with comprehensive play counts. Reinstall may create a new observed identity; local-only accounts cannot deduplicate humans perfectly.

## 10.3 Gameplay measurement

For each ended battle record encounter, attempt, result/reason, duration in simulation and real foreground time, fortress health, loadout, chosen upgrades, wasted Supply at cap, peak living units, Rally timing and version. Per-side/per-troop summary reports deployed units, deaths, effective damage, fortress damage and survival contribution where defined. Do not emit per-hit network events. True damage accounting caps overkill and separates barrier absorption, HP damage and fortress damage; otherwise a slow overkilling Brute appears falsely efficient.

Draft reporting includes all offered options and their positions, selected option, reroll ordinal and entitlement/ad route. A selection rate denominator is appearances, not total runs. An upgrade's win correlation is not proof of causation: players, encounter difficulty, army and access can differ. Compare like cohorts and use the shared simulator for controlled questions.

Distinguish expedition started, explicitly abandoned, defeated, drawn, completed and interrupted. Restarting a battle from a checkpoint is another attempt within the same run, not a second expedition reward. A backgrounded incomplete session cannot be labeled a loss without an actual outcome.

## 10.4 Metric definitions

| Metric | Definition and initial decision threshold |
|---|---|
| First-battle reach | new measurable installs with a battle start / new measurable installs; investigate below 85% |
| Tutorial resolution | completion or explicit skip / tutorial entrants; target 80%, report skip separately |
| First-expedition completion | completed first attempts / first expedition entrants; investigate below 50% |
| D1 return | qualifying activity in elapsed hours [24,48) after first observed open; target 30% |
| D7 return | qualifying activity in [168,192); target 8% |
| D30 return | qualifying activity in [720,744); target 3% |
| Crash-free users | Crashlytics' own defined user denominator; target at least 99.5% |
| Play user-perceived crash/ANR | Play Console denominators, not Crashlytics conversions; internal <0.5% / <0.20% |
| Earned-reward loss | unresolved earned grants / earned callbacks after allowed recovery window; alert at 0.5% |

These are internal investigation thresholds, not industry averages or revenue guarantees. Report mature denominators, uncertainty and consent missingness. Do not mix calendar-day retention with elapsed windows. Do not report D30 until its window has fully matured. The default analysis threshold is 200 measurable mature installs for behavioral rates and 500 for health rates; a known critical defect blocks regardless of sample. Organic-only acquisition may grow slowly: absence of 200 installs is not evidence of good retention, nor an excuse to hold a technically safe limited release indefinitely.

## 10.5 Revenue and money

Capture AdMob's impression-paid callback value, currency and precision for estimated revenue. An ad request, impression, earned reward, granted reward, estimated value and actual payout are different facts. Link each to its placement and opportunity ID where available. Do not claim every rewarded ad pays the same amount or that no-fill is revenue. Reconcile estimates with finalized AdMob reports. [EXT16]

Verified server purchases and revocations feed one canonical financial projection. Avoid counting Unity/Firebase automatic purchases plus a custom purchase-success callback as two sales. Gross customer price is not developer cash. Report refunds, platform fees, platform-collected tax, withholding, FX and net settlement separately using real provider reports. Price amounts use integer micros/minor units plus ISO currency; never assume every currency has two decimal places or use binary floats for money. The original product JSON decimal USD labels are design display inputs; the store remains localized price authority.

Contribution per install is cumulative net receipts minus attributable variable costs and acquisition cost; organic promotion also has labor cost even with zero paid media. Observed D7/D30 revenue is not measured lifetime value. No forecast is embedded as a success criterion. Permanent purchases do not renew monthly.

## 10.6 Query and reporting contract

`reports/sql/` provides BigQuery templates against **documented normalized views**, not a claim that those tables already exist. `contracts/analytics_transport.json` defines the adapter from Firebase export to `olw_events`, `olw_activity`, `olw_installs`, `olw_ad_revenue` and `olw_purchase_ledger`. Project/dataset placeholders must be supplied at deployment. Queries require a date range and partition filtering; no unbounded scheduled scans by default.

Raw identifiable behavioral export retention is initially 90 days; use bounded, non-identifying aggregate business summaries thereafter. Support logs target 30 days. Financial/entitlement retention requires an actual legal/business decision for the publisher and markets. Geography uses privacy-appropriate platform reporting, never GPS. Do not claim EU hosting of one database constrains all Firebase/AdMob processing to Europe. Review every service's processing terms and data route. [EXT19, EXT20]

## 10.7 Data-quality acceptance

Run a scripted synthetic journey with known outcomes: tutorial resolution, first win, draft offers/reroll/chosen, four-battle completion, reward bonus, fake pending-to-verified purchase, duplicate callback, save retry, consent withdrawal. Validate exact counts and values in the local adapter, approved SDK debug view, raw export, normalization and dashboard. Demonstrate no secret fields and no duplicate financial facts. Synthetic fixtures remain labeled synthetic and cannot enter production cohorts.

Use a monotonic clock for durations and UTC timestamps for records. Device-clock changes may affect raw event timestamps, so flag implausible order rather than giving rewards based on time. Dashboard queries handle empty/zero denominators as unavailable, not zero-percent success. Separate unknown/unattributed acquisition from Play organic; Install Referrer cannot reconstruct every organic exposure.

## 10.8 Decision protocol

Poor tutorial reach prompts onboarding/input investigation, not an extra content system. Low expedition completion prompts comprehension/difficulty review. Low D1 prompts first-session value and flow analysis before more monetization. Healthy retention with low ad opt-in does not justify forced ads. Rising ad revenue with falling return rates requires net cohort analysis, not automatic celebration.

A dominant army prompts a source-versioned balance test, not a seventh troop. A privacy-related reporting gap is disclosed, not filled with invented users. Gameplay changes are sequential versioned releases, not hidden per-player experiments. No automatic rollback, recurring monitoring, public posting or scheduled cloud query has been created by this handoff.


---

<!-- Source: bibles/11_VISUAL_DIRECTION_AND_SCREENSHOT_WORKFLOW.md -->

# Bible 11 — Visual Direction and Screenshot-Based Presentation

**Authority:** V001 is approved style direction; WF002 defers final production until a working placeholder game. Lighting/shadow/UI exact execution becomes P001 only after owner review of paintovers based on real build captures.

## 11.1 What the references mean

Three prior conversation images are included under `references/visual/` with verified file hashes. V001_A is the owner's chosen direction; V001_B is the polished battle finish target; V001_C is a multi-screen style sheet. They are generated references, not screenshots from a Unity implementation and not already-ready commercial assets. No new images were generated for this handoff.

Preserve the shared character of these references: bright sunlit comic medieval world, illustrated 2D/2.5D depth, scenic valley/mountains/river, chunky readable soldiers/equipment, blue player and red enemy supported by symbols, dark metallic panels, gold accents and a legible action hierarchy. No photorealism, gritty realism, painterly sketch finish, gore or child-directed marketing assumption.

Do **not** adopt the mock images' mechanics. Examples of non-authoritative content include 4,000 fortress HP, 1,000 Supply capacity, 150/300/250/350 unit prices, extra star/power progression, invented rewards or units, inaccurate upgrade percentages, altered currencies and a logo implying trademark clearance. Actual B001 values are 900 default player HP, Supply cap 200 and starter costs 20/45/50/65. `data/visual_references.json` records these differences. The style sheet is not permission to add a screen or feature.

## 11.2 Placeholder first, including presentation interfaces

Use flat colored shapes with role labels and distinct geometry. Unit size represents the intended relative category; model half-width remains independent. A simple ellipse contact shadow, colored projectile and expanding explosion ring are sufficient to verify layering, timing and readability. Placeholder animation can articulate primitive parts so the same sockets and timing events are exercised before final art. This is allowed local development, not final asset generation.

Do not spend weeks matching V001 before PH06. However, do implement real responsive layout, safe areas, input states, animation/VFX interfaces and capture hooks. Deferring artwork does not mean postponing readable troop roles or touchable controls. Gameplay logic must be entirely separate so replacing a sprite cannot change damage or a paid entitlement.

## 11.3 Camera and composition contract

The battlefield is one fixed horizontal simulation lane, both fortresses visible, no camera panning or zoom during ordinary combat. Reference canvas is 1920×1080. A fit-to-safe-gameplay-rect algorithm calculates orthographic size at screen/layout changes; it does not invent different attack ranges for wider phones. Fit the entire logical lane and fortress art extents. At wider ratios, decorative scenery may extend; at narrower supported ratios the view fits the required horizontal extent and keeps controls outside the gameplay viewport. Portrait is not a supported mode.

The camera's world-to-screen mapping and unit root bounds are captured as metadata. Horizon height, final unit pixel height, fortress artwork width and exact lane vertical placement are evaluated on the actual placeholder layout; they are P001 decisions, not numbers silently derived from a generated image. UI safe-area changes may move anchors; they cannot crop fortress health or hide troop buttons. Depth offsets and parallax are visual only and never create selectable lanes.

## 11.4 Lighting and shadows without changing the engine

T001 uses built-in 2D, not a 3D scene with physically simulated sun shadows. V001's lighting can be implemented through illustrated shading, sprite tint/material treatment, atmosphere layers and contact-shadow sprites. A paintover may depict warm upper-left light; it does not prove that Unity needs a Directional Light component or a URP renderer. Implement only the effect needed to match the chosen screen within the performance contract.

For the placeholder use neutral flat materials, no bloom/post-processing dependency, and simple soft ground-shadow shapes. At P001 lock key-light apparent direction, ambient contrast, shadow tint/opacity/softness/offset, atmospheric depth, foreground/background saturation, UI shading and any material parameters with actual scene tests. Ground shadows follow unit feet, are removed with the unit view, and do not become gameplay colliders. Avoid baking contradictory left/right lighting into mirrored characters; the chosen art/rig production must handle the two facings coherently.

## 11.5 Capture pack

`data/screenshot_pack.json` enumerates the required captures. Codex exports **raw real render captures** with correct HUD, no debug overlay and no external retouching. A separate annotated copy may show bounds; never overwrite the raw image. The capture sidecar records source/app/balance version, scene, screen state, dimensions, safe area, camera matrix or fit values, run/encounter/attempt, loadout, upgrades, tick, device/AVD and whether the state is a developer fixture.

Capture Home/Campaign, Army, all relevant battle densities and outcomes, Draft, Results, Shop, Settings, Pause and important error/consent states. Include early engagement, 24-vs-24 readability, Rally, barrier, grenade explosion, protected Crossbow line, Ram-to-fortress contact, overtime, victory/defeat/draw. Dense artificial fixtures are valid engineering references but must not be advertised as ordinary attainable gameplay without proving that route.

The main review pack uses 1920×1080; actual supported-aspect captures supplement it. Do not stretch a phone screenshot to fake that aspect. Keep a real capture at the native rendered size and identify any separately re-rendered reference-size capture. Animation and VFX also need short real recordings; a paused screenshot cannot prove timing or motion.

## 11.6 Paintover loop

The owner supplies or identifies a real placeholder capture. Generate alternative final-look targets using that image as the layout reference and V001 as style reference. Maintain the same screen, camera, unit roles, current numeric values and controls. An image generator can still drift in typography, geometry or counts; therefore the target is reviewed against the source capture and cannot be treated as a pixel-exact conversion by assertion.

The owner approves a particular target, with the approval scope recorded. Extract implementable parameters and required modular assets, not a flattened screenshot installed as the game. Codex applies UI styles, sprite assets, shadows, materials and VFX, then captures the same state again. Compare source capture → approved target → actual implementation. Changes to layout or gameplay discovered during this review need explicit source amendments, not hidden visual reinterpretation.

The template prompt and acceptance checklist are included under `templates/`. They are instructions for a later authorized generation task, not executed work. No final artwork, music or effects are purchased/generated merely because this package contains prompts.

## 11.7 Presentation acceptance

At full density a player must distinguish categories and sides, locate the frontline, read fortress HP/Supply/Rally and use all four deployment controls. Smoke, bursts, foreground grass, shadows and particles cannot obscure essential controls. Do not convey ownership, blocked buttons or teams by color alone. Test both landscape orientations and the narrowest supported safe viewport.

Approve final visual states for normal/pressed/disabled/focused controls, all Rally states, unit affordability/cap/cooldown, draft selected/reroll-used/ad-unavailable, Shop owned/pending/unavailable, and result types. A beautiful normal-state mock does not cover the state machine.

P001 records actual values, font licences, texture/atlas settings, approved screenshots, asset mappings and profile results. Store screenshots/trailer gameplay are captured from the final executable, not generated paintovers. They must show attainable implemented mechanics and correct prices/benefits.


---

<!-- Source: bibles/12_ASSETS_ANIMATION_AND_VFX.md -->

# Bible 12 — Assets, Animation and VFX Production

**Authority:** animation mechanics AM001, asset catalogue 148 planned families, V001 style, later P001 execution. External production begins PH08 after placeholder completion and screenshot-based targets. No font binaries or finished production artwork are distributed in this source pack.

## 12.1 Asset catalogue and replacement boundary

`data/assets.json` is the complete inherited launch catalogue: six troop masters, two derived bosses, two fortress families, three environments, six portraits, 36 animation bindings, 24 upgrade icons, six main UI views, earned/paid cosmetics, 12 VFX families, 25 SFX families, two music loops, three stings and marketing families. A record is a family or binding, not necessarily one file. A six-state character can require multiple parts, clips, atlases and exports. Every current production record remains PLANNED_NOT_GENERATED with no invented source path, approval or rights proof.

Use an asset binding layer from stable IDs to placeholder or final presentation. Runtime content refers to IDs, not hand-entered file names in combat code. A missing final binding is visible in development and fails final readiness; it must not silently ship a gray rectangle. Placeholders remain available for diagnosis but are excluded from advertised final capture fixtures.

## 12.2 Production order after the gate

Begin with Militia, Crossbowman and Ram to prove humanoid melee, two-hand projectile use and mechanical movement. These production proofs happen **after** the complete placeholder game, not before it. Then produce Shieldguard, Grenadier and Brute; derive boss equipment/scale while retaining mechanics; produce environments/fortresses, UI/icon families, cosmetics and remaining effects. Shared style sheets and approved target screens govern every generation batch.

Generate a small reviewed batch, not the entire catalogue blindly. Keep source prompt/model/provider/date and revision. Rejected alternatives remain history with a rejection reason, not active master candidates. No overwrite of an approved original during a repair. Output acceptance has separate visual, technical, rights and integration statuses.

## 12.3 Cutout source specification

Use Unity-native transform cutouts: separated transparent PNG parts, a shared biped hierarchy for five humanoids, and a separate Ram hierarchy. No root motion, external skeletal-software licence, 3D model requirement, or generated-video animation dependency. The source reference canvas is 1024×1024 at 512 pixels/world metre with a feet-root convention. Actual part bounds/pivots depend on approved drawings and are stored in metadata.

Required humanoid components include head, torso, near/far upper/lower arms, hands, upper/lower legs, feet, weapon and any shield/accessory. Use view-relative near/far names internally to avoid confusing mirrored screen direction with anatomical left/right. Include concealed overlap beneath joints, neck, hips and grips. A flattened attractive soldier lacks the hidden pixels needed to bend its elbow; it is not a completed rig source.

Define parent, local pivot, draw order, attachment socket and allowed transform range per part. Weapon grip must remain stable; a crossbow release socket follows its muzzle, not the torso center. Feet contacts and weapon reach are visual calibration against the model, not replacement collision geometry. Mirroring must not invert text/heraldry incorrectly or produce a contradictory light source; separate approved facing variants are permitted within the same unit family when necessary.

The Ram includes frame/body, wheels, moving strike beam, recoil connection and decorative parts. Wheel angle is actual distance divided by 0.25m radius. No unrelated spinning wheels while stationary. Its mechanical body does not imply hidden operator units, extra health pools or new attack logic.

## 12.4 Animation synchronization

All six required states are Idle, Move, Attack, Hit, Death and Victory. Exact attack/windup/follow-through/recovery/death times and movement-cycle targets are in `data/animation_contract.json` and the generated catalogue. Idle loops are 2.4 seconds, victory 1.6 seconds, blend 0.08 seconds, additive hit 0.10 seconds without stun, fade after death 0.25 seconds. A hit reaction cannot reset an attack or postpone simulation damage.

The model publishes attack-start/release/impact/death events with tick IDs. Visual playback follows the quantized snapshot; Rally changes new attack intervals rather than speeding an in-progress animation arbitrarily. Clip import and Animator transitions must preserve release/impact correspondence. Animation events can request visual/sound cues but never award damage. If presentation drops a frame, model impact still occurs once.

Use precedence death > committed attack > movement > idle, with additive hit feedback where compatible. No simulation-wide hit stop. Presentation-only shake/recoil is bounded and disabled/reduced by the accessibility setting. Corpses stop blocking immediately at model death and their finite fade returns views to pools. Victory visuals begin only after the model/result transaction has resolved.

## 12.5 Texture/import rules

Preserve lossless original sources and export processed runtime copies. Use sprite atlases separated into UI, troops, environments and effects, maximum 4096 per atlas under this baseline, avoiding an enormous combined texture loaded everywhere. ETC2 is the initial compression baseline for the selected OpenGL ES 3 target; inspect alpha edges and memory. Bilinear filtering is default. Character/UI sprite mipmaps are off; environment mipmaps are evaluated where minification requires them. Premultiplication/alpha conventions are consistent throughout import and shaders.

Do not embed changing text, prices, counters, health numbers, buttons or entire menus into images. UI labels use licensed runtime fonts. Preferred typography is Roboto Slab ExtraBold for display, Inter for function and Noto Sans fallback, subject to actual licence acquisition and readability in P001. The package includes names and licence obligations, not font files. Glyph atlases must cover every shipped English string and store-returned prices without missing-currency boxes.

Linear color-space selection and material consistency must be tested against the actual art and low-tier renderer. No unapproved post-processing stack or realtime light/shadow system is introduced to imitate a paintover. Exact tints, grading and shadows are P001 parameters.

## 12.6 VFX families and behavior

The 12 families cover spawn dust, slash, generic hit, block, bolt trail/impact, grenade, barrier, Rally, hit flash, death, reward and fortress destruction. Use short readable silhouettes rather than unlimited bloom/smoke. A grenade is the largest ordinary troop effect, a Ram/fortress impact the strongest standard hit, and fortress destruction the main terminal spectacle. Militia attacks do not shake the whole screen.

Default limits are 64 active effects and 400 particles across the effect manager, with priorities favoring gameplay communication. When saturated, reduce decorative dust/trails first. The model still resolves every projectile/damage event. An exhausted VFX pool may omit a low-priority spark, never the damage itself or essential barrier/Rally state indicator. `audio_vfx_contract.json` contains baseline timing/shake settings; P001 chooses the sprites and final material treatment without changing those gameplay events.

Effects clear on transition; late callbacks cannot attach to a recycled unit ID. Shake is presentation-only, accumulated and clamped rather than stacking indefinitely. Haptics and reduced-motion controls are honored across every trigger. Smoke cannot cover deployment buttons or become a simulated obstacle. Explosions do not fling units as a new knockback mechanic; any decorative debris has no collision authority.

## 12.7 Rights and acceptance record

For every production item record asset ID, provider/model, account/licence holder, applicable terms date/reference, generation/download dates, prompt, supplied references and their rights, original/checksum, edits, exported files, technical settings, visual approval, integration evidence and replacement history. Provider account access alone is not a licence audit. Generated output is not necessarily unique or free of third-party similarity.

Technical acceptance includes exact canvas/import settings, clean alpha, no edge halos, hidden joint coverage, both facings, grip/pivot integrity, coherent scale, readable phone-size silhouette, no baked live text and complete ID mapping. Integration acceptance includes same-state screenshot comparison, six animation states, active speed buffs, 24-vs-24 readability, pool reset, memory/performance and source-hash traceability. Approval of a style reference does not mark all future generated assets approved.


---

<!-- Source: bibles/13_AUDIO_MUSIC_AND_HAPTICS.md -->

# Bible 13 — Audio, Music and Haptics

**Authority:** AU001 mechanical/mix targets. The chosen providers are Suno for music and ElevenLabs for SFX. Actual generation occurs PH08, not during placeholder development. Silence or small locally synthesized test cues are acceptable until then.

## 13.1 Catalogue and musical direction

Two instrumental loops are sufficient: Menu/Army at 96 BPM, 40 seconds, sixteen 4/4 bars; Battle at 120 BPM, 32 seconds, sixteen 4/4 bars. Three short stings cover victory, defeat and expedition completion at approximately 2/2/3 seconds. These are generation/edit targets and not a claim the provider will output seamless bar-perfect files directly. Trim, crossfade and measure the final exports.

Musical identity should match bright comic medieval tactics: rhythmic acoustic/percussive character, melodic restraint, no vocals, no imitation of a named copyrighted game's signature tune. Battle music supports deployment decisions rather than escalating so densely that impacts disappear. No five-era soundtrack, adaptive music-composition system or voice actor is added.

Maintain 48 kHz/24-bit lossless masters. Music mastering target is −16 LUFS integrated and at most −1 dBTP; final playback mix is validated on headphones and phone speakers. Record measurement tool/settings. Runtime encoding, streaming/decompression and loop boundaries are verified on the selected Unity/audio backend. Never loop an MP3 by hoping its encoder delay is inaudible without testing it.

## 13.2 Sound design

The 25 sound families in `data/assets.json` cover interface, deployment, each weapon/impact family, barrier/block, grenade, Ram movement/contact, Rally, deaths, fortress damage/destruction, rewards/unlocks, draft and purchases. Family variations are permitted to avoid repetition but do not expand gameplay. Generate dry isolated effects without speech, unrelated ambient beds or hidden music. Use short tails appropriate to repeated attacks.

Auditory hierarchy follows gameplay: interface/deploy acknowledgement is clear and brief; light impacts stay light; shield block is distinct; crossbow release/impact is precise; grenade is spatially readable; Brute/Ram convey heavier mass; fortress destruction resolves the battle. Avoid a purchase-success sound implying a pending payment already granted ownership. Error/pending states have neutral feedback, not repeated alarms.

Use separate Music, SFX and UI mixer groups. Initial normalized levels are 0.55/0.80/0.65. Player settings persist locally; the UI can expose Music and Effects while the internal UI bus retains its mix relationship. Overall silence must leave the game fully understandable. No gameplay information is audio-only.

## 13.3 Runtime budget and scheduling

The default pool permits sixteen concurrent voices, at most three of one family. Rank critical UI/fortress/Rally above ambient or repeated light hits. A crowded army must not play forty-eight equally loud simultaneous impact files. Voice stealing fades/removes a lower-priority sound and never changes combat timing. Keep bounded volume/pitch variation within approved ranges and deterministic debug options for comparison; audio randomization is not combat RNG.

Trigger audio from the model's committed presentation events. A missed melee swing may use a swing without a hit. A projectile hitting a shield uses the correct impact family. Pool reuse and scene transitions clear obsolete scheduled sounds. Death clips do not leave loops running on a despawned Ram. Music loop owners have one active instance; reopening Army cannot layer identical tracks.

## 13.4 Focus, advertisements and lifecycle

Loss of focus/background follows platform audio focus and the game's pause policy. A store/ad overlay acquires the correct mixer duck/mute state. Restoration releases only its own reason; it must not override the user's volume choice or another active focus loss. Incoming calls, headphones unplugging, Bluetooth changes and repeated suspend/resume require device tests. Respect Android media-volume behavior; do not promise that a ringer switch universally controls game media volume.

On return, restore the previous loop position where the implementation supports it cleanly; avoid abrupt restarts after every short overlay. Never leave the app permanently muted after an advertisement, or resume two loops after a callback race. A denied audio/haptic preference must remain denied after save reset if the specified reset retains settings.

## 13.5 Haptics and motion

Light feedback may confirm deployment or a deliberate UI action; medium feedback marks Rally; stronger bounded feedback marks Ram/fortress impact. No continuous buzzing on every light attack. Platform support varies: unsupported haptics is a no-op, not an error. A persistent toggle disables every haptic route. Reduced motion suppresses heavy screen impulses and flashes; it does not change damage or attack periods.

Haptic timings are calibrated in the final device pass. An emulator screenshot or vibration API call does not prove perceived strength. Limit repeated triggers with a minimum interval and a priority policy; detailed values live in the presentation contract when measured. Do not advertise universal accessibility compliance from having a toggle.

## 13.6 Rights, delivery and approval

Retain the provider plan/licence holder, creation/download dates, relevant terms, prompt and source audio hash. Suno's commercial-use permissions and ElevenLabs' SFX terms must cover the actual output and intended game distribution; do not assume upgrading later retroactively clears older material. [EXT31–EXT33]

Deliver lossless source masters, edited loop/effect masters, runtime encodes, loop metadata, loudness/peak report and the binding manifest. Review clipping, noise, click-free boundaries, consistency, silence/focus behavior and crowded battle intelligibility. The owner approves the final set after listening in the actual game. Final audio acceptance is separate from source catalogue completeness.


---

<!-- Source: bibles/14_QA_BALANCE_AND_EVIDENCE.md -->

# Bible 14 — QA, Balance and Evidence

**Authority:** QA001 consolidated registry and B001. The supplied source/math tools can run now. Unity, Android, SDK, device and human-play checks remain NOT_RUN until Codex produces the corresponding evidence.

## 14.1 Evidence classes

Keep five separate categories: source structural validity, arithmetic/reference validity, executable game correctness, presentation/device correctness, and human/commercial outcomes. A JSON parse is not combat validation. A thousand bots are not a thousand players. A generated picture is not a runtime screenshot. A test that uses a fake ad is not AdMob integration. This package may be source-verified while every game gate remains unexecuted.

`data/qa_cases.json` contains inherited 93 cases, the 12 B001 amendments, and additional migration/workflow/release edge cases. Every case has an ID, category, procedure/expected result or inherited acceptance description, assigned phase and evidence status. Store actual execution in a separate run report with tested commit, command, environment, result, log and artifact links. Never overwrite NOT_RUN with PASS merely because a task says to test it.

## 14.2 Source tests

Run `tools/verify_source.py` to check manifest integrity, JSON structure, IDs/references, source preservation, counts, authority, workflow ordering and required paths. Run `python -m unittest discover -s tests -v` for independent numerical fixtures and transport examples. Run `tools/audit_balance.py` for upgrade arithmetic and funding/economy analysis; it is explicitly not a battle simulator.

The 15 four-unit loadouts each have 18 eligible upgrade definitions initially. Enumerating four selections gives 15 × C(18,4) = 45,900 arithmetic configurations, irrespective of draft-path guarantees. This is an upper-envelope arithmetic audit, not a claim each configuration occurs with equal probability or that it wins any encounter. Distinguish the eligible combination set from reachable draft paths. The tests must not report a reduction formula's output as measured damage delivered through congestion and travel.

## 14.3 Executable model fixtures

Required deterministic scenarios include empty lane, equal melee contact, three-slot engagement turnover, ranged-only armies, melee passing friendly ranged, two opposing fast units approaching, off-front reserve unable to attack, base defense blocking, same-tick death impacts, shooter death after release, swept projectile intersection, grenade target moving away, no friendly splash, secondary hits excluding base, barrier first-hit/timer/absorption and every cost/rate rounding boundary.

For each create minimal input snapshots, tick-stamped commands, expected assertions and seed where relevant. Re-run the same command stream under 30/60 FPS presentation, 1×/2×/4×/10× debug scheduling and headless batch. The authoritative outcome/state hash must match. Accelerated scheduling never changes time-step size. Debug tools may step one tick and inspect targets/slots; they cannot become a player-visible speed-up or sandbox mode.

Every upgrade has unit and interaction tests. Apply selected modifiers to eligible troops only, preserve base/troop distinction and avoid recursive bonus spawning or damage. Test Conscription at cap, lost melee target during windup, three-hit Ram counter per individual Ram, pierce two-target identity, Rally beginning/ending on attack boundaries, oath-style barrier only once and upgrade exclusion after selection. No hot-loop implementation may use dictionary iteration order as a combat rule.

## 14.4 Full balance harness

Once the Unity-independent C# combat assembly exists, use that exact assembly in the batch runner. Exercise all 36 encounters with all 15 loadouts where access restrictions are intentionally bypassed only for analysis. Separately test normal campaign-unlock routes without bypasses. Player-policy families are cheapest spam, costliest spam, role-protected ranged, mixed formation, hoard-then-push, Ram push, ranged-heavy and varying Rally timing. Policies must actually obey costs, caps, global cooldown and visibility rules.

Record encounter, army, upgrade path, seed, policy, source/balance version, result, duration, base fractions, effective/base/barrier damage, Supply spent/wasted, deployment counts, frontline occupancy, stalled time, overtime/cutoff outcomes and performance cost. Include equal-budget isolated matchups and full runs; do not compare units on nominal DPS alone.

Review high-level failure modes: universal dominant strategy, deployment inactivity, high fraction of timeout-fraction wins rather than fortress breakthroughs, mandatory ad/paid reroll for campaign viability, inaccessible upgrades, sudden chapter spike, protected ranged never reachable, siege becoming worse than ordinary ranged in every relevant context, and population limits invalidating intended swarm play. A strong build can be desirable; near-universal dominance that removes decisions is not.

Numerical corrections require B002 with exact changed fields, reasoning, before/after evidence and regression. Do not ask the owner to choose HP or quietly patch B001. Do not promise all 15 armies win all battles: roster constraints and player strategy may legitimately matter. Require at least one demonstrated no-ad/no-purchase full campaign policy and human comprehension of alternatives.

## 14.5 Stateful and failure testing

Test first launch, skip tutorial, replay, later failure preserving previous rewards, draw, explicit abandon, Home/resume, process kill in battle, process kill during draft generation/selection, duplicate result callback, low storage, corrupt latest save, valid backup, both invalid, unknown newer schema and migrations. A pause menu, service overlay and background focus can overlap; removing one must not resume another.

Test transaction boundaries by injecting failure before write, after temporary file flush, before atomic replacement, after replacement but before UI success, and during backup rotation. Verify recovery without double-spending or duplicate banked Medals. A reset retains ownership/privacy/accessibility settings as specified. A reset must not refund money, imply cloud deletion or corrupt a pending verification.

Commercial tests cover all documented ad and purchase states using fakes first and genuine test flows later. A known lost verified purchase, destructive save defect, duplicate charge path, security breach, inaccessible primary control or unresolved required declaration blocks release regardless of average pass rate.

## 14.6 Device and presentation testing

AVD rows record actual ABI loading and system-image details. Unsupported rows remain blocked. Real phone coverage includes installed-through-Play build, cold/warm launch, input, safe areas, both landscape orientations, 20-minute soak, frame-time/memory, audio focus, haptics, consent and ad/store returns. Font/display scaling and tablet-like views must not lose controls. Do not claim every Android device supported based on a single emulator.

After final art, repeat all relevant tests. Atlas size, alpha overdraw, shader compatibility, animation pivots, audio streaming, effect pools, glyph coverage and screenshots can regress even when the model is unchanged. Art replacement is not just copying files and skipping release QA.

## 14.7 Human validation and severity

Closed testers must include people who did not design the game. Observe whether they understand deployment, protection, draft effects and Rally; finish an expedition; choose another army; and voluntarily replay. Do not coach every decision then count success as intuitive onboarding. Collect actionable confusion/abandonment notes with consent. Formal retention targets require mature unbiased-enough cohorts; a few friends are usability evidence, not monetization proof.

P0 includes systemic lost paid ownership, destructive saves or security exposure. P1 includes widespread failure to start, crashes/ANRs or systematic earned-reward loss. P2 covers important bounded balance/UI/isolated defect clusters. P3 is minor polish. Severity relates to user impact, not an arbitrary code-review label. Preserve exact-head review and evidence; avoid days of unrelated refactors while critical work waits.

## 14.8 Release decision

No known critical corruption/payment/security defect, unresolved mandatory policy issue or fake final asset can pass. Minor issues require an explicit accepted-risk record with owner/director disposition. Release evidence cites the exact AAB hash and tested commit; any subsequent code/content change invalidates only the affected evidence through a documented regression map, never silently reuses an old all-green label. A source-validation PASS in this package grants none of these runtime approvals.


---

<!-- Source: bibles/15_CODEX_EXECUTION_AND_PRODUCTION_PLAN.md -->

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


---

<!-- Source: bibles/16_LEGAL_PRIVACY_AND_PUBLISHER.md -->

# Bible 16 — Legal, Privacy, Rights and Publisher Readiness

**Authority:** operational legal checklist, not a legal opinion or completed compliance assessment. Exact publisher facts and final SDK behavior remain required deployment inputs. This Bible defines the work; it does not certify the game or generate fictitious identities.

## 16.1 Publisher and licensing identity

The intended route is the owner's Macedonian-company Google Play organization account. Exact legal name, registered address, D-U-N-S, verified contacts, merchant/payment profile, tax/bank details and public developer identity must be supplied/verified by the owner through the relevant services. Do not copy private identifiers into Git. Keep only completion status, responsible owner, secure location and evidence references. Organization/contact requirements and potential public display of address must be reviewed before publication. [EXT22]

`One Lane War` remains an internal working name. Final title, logo, package ID, website, support address and privacy URL require naming/store/trademark checks and owner approval. No generated logo establishes rights. A development package ID can unblock local builds but cannot become production accidentally. Final identity is needed before Firebase/Play/AdMob commercial registration.

Review Unity licence eligibility for the actual entity and relevant aggregate finances, not only this game's revenue. A zero-revenue prototype is not automatically evidence the publisher qualifies for a particular plan. Do not provision paid seats without approval. [EXT30]

## 16.2 Asset and code rights

Maintain a rights ledger for visual/music/SFX output, supplied references, fonts, icons, third-party packages and any reused code. Record applicable provider/model/plan/date and the output's creation/download history. Having Higgsfield/Suno/ElevenLabs access is not proof of every commercial permission. Keep terms references/snapshots and original output hashes. Review similarity and prohibited third-party material; generated output is not guaranteed unique or free of other rights. [EXT31–EXT33]

No copied Age of War characters, UI, music, trademarked heraldry or misleading association. No celebrity likeness or real extremist symbol is required. Generate original game assets with the approved style rather than imitation instructions aimed at a particular protected work. Fonts use properly licensed distributions and their notices; this handoff deliberately contains no font binaries. Assemble Third-Party Notices from actual imported dependencies and licences, including backend npm dependencies where applicable.

## 16.3 Audience and rating

The creative audience is adults who like short strategy sessions. The 18+ target-audience selection and the IARC content rating answer different questions. A colorful cartoon can still appeal to children; do not declare adults merely to bypass child-directed obligations. Finished art, marketing channels, copy, store metadata and actual use need honest review. No age-screen or birthday collection is added by default to pretend the issue is solved. [EXT18]

The game has stylized non-gory combat, no real gambling, loot boxes, cash-out, social communication or user content. Complete the actual content questionnaire from the final product; do not invent an IARC result. If review determines different audience treatment is required, amend consent/ads/declarations before launch rather than continuing an incompatible monetization path.

## 16.4 Data inventory and lawful handling

The core game requires no name, email, precise location, photos, contacts, microphone or account. Optional support may voluntarily receive email and diagnostics; store/payment providers and SDKs process their own data. Do not claim 'we collect nothing' simply because combat is offline. Inventory Firebase, AdMob/UMP, Unity IAP telemetry, entitlement backend, host logs, support and attribution, including automatic collection. [EXT19]

For each category record purpose, fields, collection trigger, optional/essential basis, processor, transfers/hosting, recipients, retention, deletion/reset mechanism, security and user disclosure. Analytics starts disabled and has a clear optional choice distinct from UMP's ads flow. No pre-consent backlog. Withdrawal stops future optional transmission; verify actual SDK behavior. Required transaction records are not erased blindly just because optional analytics consent changes.

Initial raw behavioral export retention is 90 days; support logs 30 days. These are implementation defaults, not a universal statutory retention rule. Financial/entitlement records need the publisher's actual applicable requirements. Data-subject requests, deletion exceptions and processor handling must be documented for relevant markets, including EU/UK exposure. Hosting the purchase database in Europe does not mean all SDK traffic stays there.

## 16.5 Documents needed before release

Prepare public Privacy Policy, support page, appropriate consumer/purchase terms, and Third-Party Notices. Internal templates in this pack identify required sections and unresolved inputs; they are **not ready to publish verbatim**. The policy must name the correct entity and contact, accurately describe actual fields/services and their purposes, choices, retention, transfers, security limitations and rights/request route. It must be accessible from Play and the game.

Separate local reset, server data requests, purchase restoration and refund requests. No account creation exists; do not add login solely to satisfy a hypothetical account-deletion screen. Still provide a real channel for relevant data requests about remote records. Explain that reinstall/device change may lose local campaign progress while purchases can be restored online through Play.

Consumer copy accurately explains two one-time products, same reward limits, finite Medal usefulness and absence of forced ads. No fake timer discounts, deceptive recurring wording, manipulative purchase confirmation or guaranteed future content. Actual applicable taxes/refunds/trader requirements and payment-provider handling are reviewed before production; do not present a generic template as jurisdiction-specific advice.

## 16.6 Google Play declarations

Contains ads: yes. Offers in-app purchases: yes. Account/login: no. Main gameplay is accessible without account, ad completion or payment. Target audience follows the reviewed adult positioning, IARC from actual questionnaire. Data Safety follows final measured behavior, including SDKs. App access instructions give reviewers a clear route to combat and do not require unavailable credentials. Other console declarations are answered from the actual app; do not blindly copy a generic app-content form. [EXT19, EXT22]

Version privacy and legal copy with the released build. A SDK update can change behavior even if gameplay is unchanged, so the inventory/declarations are rechecked. Record who approved the public documents and on what date. Legal checklist completion is evidence of review, not a promise against every future dispute.

## 16.7 Security and incident obligations

Use access control, least privilege, HTTPS, redacted logs, secure secrets and key recovery. No payment card data is collected by our backend. Purchase tokens/signing keys are sensitive operational material. Privacy/security incidents require preserving necessary evidence, containing exposure, assessing applicable notification obligations with qualified guidance, and recording remediation. Never delete all logs indiscriminately during an incident or expose raw tokens in a public issue.

No new cash spending, legal-service purchase or public publishing is authorized by the source pack. Unknown identity/retention/terms items remain clear release blockers in `data/deployment_inputs.json`, not invented completed facts or a reason to block the initial offline prototype.


---

<!-- Source: bibles/17_GOOGLE_PLAY_RELEASE_AND_DISTRIBUTION.md -->

# Bible 17 — Google Play Release and Distribution

**Authority:** REL001 process. Owner-controlled external actions. Nothing is currently uploaded, reviewed, approved, monetizing or published by this handoff.

## 17.1 Identity and store preparation

Before real integration register the final package identity in the verified organization route, configure merchant/payment profile and public developer details, prepare support/privacy website and verify recovery access. Keep app signing and upload key separate under Play App Signing. Store encrypted recovery material outside Git and outside a single workstation. Actual keys/passwords are never included in task packets.

Maintain a deployment identity map: final package, app title, publisher, signing certificate fingerprints, Play app/products, Firebase app/project, AdMob app/ad units, backend endpoint, public receipt-key IDs, site and support/legal URLs. Missing values fail production preflight. Replacing a development identifier in one manifest does not automatically update every provider mapping.

## 17.2 Track sequence

Local/debug builds prove development. Play internal track proves installation and platform integration. Closed testing brings independent usability/quality evidence. Production follows owner approval in US, GB, CA, AU, NZ and IE with English content. Wider markets/localization are not automatically authorized.

Google's additional twelve-testers/fourteen-days prerequisite applies to qualifying newer personal accounts, not universally to every organization. Confirm actual account eligibility in its console. Irrespective of that platform prerequisite, this project's independent closed validation remains a quality gate. [EXT23]

The first production release does not offer a percentage staged rollout: eligible users in selected countries can receive it. Control first-release risk with internal/closed testing and the chosen country scope. Subsequent updates may stage percentages. Halting an update prevents further distribution but does not remove binaries already installed; fix forward with a higher versionCode. [EXT24]

## 17.3 Android and bundle acceptance

The selected target is API 36, minimum 28, ARM64 IL2CPP. Recheck current target/Billing requirements at actual submission. Verify each native dependency's 16 KB compatibility and actual bundle output. Use an AAB with release configuration, stripping preservation, correct permissions/backups, no debug menus/secrets/test assets and final version identity. Upload required symbols/mapping so Unity IL2CPP native crashes can be diagnosed. [EXT11, EXT17, EXT21]

Install the Play-delivered build, not just a locally sideloaded APK. Check split/native libraries, landscape/safe areas, startup/offline campaign, final assets, IAP metadata, restoration and privacy controls. The AAB hash, source commit, source/balance/toolchain/save/analytics versions and backend/config revision must be in the release record. A screenshot from a different head is not release proof.

## 17.4 Commercial readiness

Create the two non-consumable products with accurate descriptions, localized pricing and entitlement mapping. Test through licence-testing accounts, including pending/cancelled/already-owned/restored/refunded flows. Internal-track membership alone does not prevent a real charge. Verify server acknowledgement, retry, ownership persistence and outage behavior. [EXT12–EXT13]

AdMob needs correct app/store linking, `app-ads.txt` on the developer website associated with the listing, discoverability/crawler access and required app-readiness review. Record the actual publisher entry and verification status. Production IDs must be present only in the approved release profile; test ad identities must not masquerade as monetizing inventory. No-fill is handled cleanly while readiness/serving varies. [EXT25]

Required consent/Data Safety/public documents must match the final SDK behavior. Store reviewer can access ordinary gameplay without a paid product or completed ad. Do not disable essential functionality for review and then remotely turn on hidden monetization afterward. Remote switches are bounded safety controls, not a policy evasion mechanism.

## 17.5 Store material

Prepare app icon, feature graphic, six to eight actual gameplay screenshots, short description, full description and short authentic gameplay trailer. Verify live Play asset format/dimension requirements at export. Use the approved final executable to capture gameplay. The V001 images and paintovers are planning references, not final store screenshots.

Show the real four-unit army, draft choice, frontier combat, progression and truthful product benefits. No fake unit counts, extra heroes, endless content claim, fabricated currency reward or future feature. A diagnostic full-cap fixture may be used to test readability; advertising it requires demonstrating the depicted state is attainable under normal rules. No bought reviews, review gating or incentivized ratings.

The public listing explains offline core gameplay and the online requirements for ads, purchases/restoration, plus local-only save limitations without implying guaranteed cloud backup. It does not claim all products work before verification or all content is infinite.

## 17.6 Release checklist and approval

`data/release_checklist.json` is the machine-readable gate. Required evidence includes identity/rights, licensed toolchain, validated final AAB, source/test/asset manifests, migrations, actual phone/AVD findings, purchase/ad/privacy tests, analytics correctness, support/legal pages, symbols, app-ads/readiness, accessibility checks and operator recovery. No known critical save/payment/security defect can be accepted by a high average pass rate.

An owner release approval records exact app/source/AAB version, countries, commercial activation, public documents and accepted noncritical risks. Review submission and publication are external mutations, not implicit from 'finish the build'. A Google approval is not proof of game retention or profitable organic acquisition.

## 17.7 Updates and rollback limits

Every update tests all supported public save schemas, active run handling, entitlements, previous offline receipt, consent migration and backend compatibility. Never require users to wipe progress as a convenience for schema changes. When an active run is genuinely incompatible, preserve banked rewards and explain the interruption under a documented migration.

Keep the previous public backend contract functioning during transition. Remotely disabling a broken new-purchase offer must preserve existing benefits and earned rewards. An offline device cannot see a safety switch immediately. Rollback of server/config and fix-forward app updates are distinct; an installed binary cannot be assumed to downgrade safely. Record rollback/incident drills before relying on them.

## 17.8 Commercial evidence after launch

Monitor critical reliability first, then onboarding, balance, consent/ad quality and organic reach. Small early samples are not conclusive retention. Mature cohorts and reconciled receipts decide whether continued effort is justified; downloads alone are not profit. No live events, paid acquisition or additional feature systems are automatically added by reaching production.


---

<!-- Source: bibles/18_ORGANIC_MARKETING_AND_BUSINESS.md -->

# Bible 18 — Organic Marketing and Business Measurement

**Authority:** organic-only launch; no paid user acquisition. Product profitability is the goal, not a promise. This source contains no market-share claims or invented revenue forecast.

## 18.1 Positioning

The proposition is a compact single-player army-builder: bring four of six troops, select four upgrades through four battles, time deployments and break a fortress. Differentiation is changing army combinations and tactical timing, not historical-age evolution, idle income, endless permanent stats or a simulated multiplayer opponent.

Keep that promise identical in game, store, clips and creator notes. The final commercial name is separate from the internal codename and requires checks. The selected style should communicate accessible strategy for the intended adult audience, not 'for kids' marketing used alongside an incompatible declaration.

## 18.2 Five capture concepts

Swarm reversal shows cheap Militia succeeding through numbers and support. Protected firing line shows Shieldguards preserving Crossbow damage. Grenade impact shows punishment of a packed formation. Ram finish shows the payoff after protecting a costly siege push. Upgrade transformation shows the same army before/after an actual behavior-changing choice.

Produce these from attainable final-build play. Capture each as clean landscape source plus carefully framed vertical crops for Shorts/Reels/TikTok where the action remains truthful. Do not add fake controls, unshipped rewards or unrelated cinematic footage presented as interactive play. Preserve clean source recordings, capture state and release version; edits do not create a different game.

The same footage can support store trailer moments, screenshots, community GIFs and a small press/creator kit. No separate marketing minigame. A screenshot-based paintover is useful for art direction but is not footage of the shipped game.

## 18.3 Distribution work

Prepare a press/creator kit with concise description, facts, approved screenshots, logo/icon, gameplay clip, store link, contact and transparent monetization. Community posts must follow each community's rules and be individually relevant, not automated spam. Organic outreach is manual/approved publishing work; no messages or posts have been sent by this source creation.

Keep a small release-week content plan and ownership checklist rather than inventing a live-ops calendar. Public account creation/posting, contacting creators, using third-party music on social platforms, and commitments to deliver codes require owner approval. Do not buy reviews or disguise paid relationships as independent opinions.

## 18.4 Attribution and interpretation

Use creative/source IDs such as `CR_SWARM_01`, `CR_RAM_01`, and channel values for Play organic, Reddit, YouTube, short-video channels, community/creator, direct and unknown. Record source links where the platform and consent permit. Install Referrer and Play reports can support attribution but cannot trace every organic view or cross-device journey. Unknown is not automatically organic search.

Compare exposure/store visit/install/first battle/completion only when denominators actually exist. Do not concatenate unlinked counts into a precise conversion funnel. Track per-version/source cohorts and exclude internal test traffic. The absence of paid acquisition means CPI is zero cash media cost, not zero founder time or zero cost to generate final content.

## 18.5 Cost and accounting ledger

Separate existing subscription allocation, incremental provider credits/retries, domain/support, lawful software seats, optional approved devices, backend functions/storage/logs, analytics export/queries, legal/publisher expenses and founder labor. The user has provider access, but no new cash ceiling beyond zero unapproved spend was supplied. Cost alert thresholds are not budgets approved to spend.

A small server can still generate variable charges. Cap request size, log retention, function scale and queries; use budget alerts. Budgets are not a universal automatic stop mechanism and maximum instances are not a dollar guarantee. Avoid an unbounded reconciliation job or dashboard scan. [EXT26]

Monthly close reconciles Play and AdMob source statements with payouts/bank settlement. Distinguish gross customer sales, platform tax handling, fees, refunds, withholding where applicable, currency conversion, final net receipts and timing. Apply the publisher's actual accounting treatment with appropriate records; this design document does not invent Macedonian tax conclusions.

## 18.6 Revenue model and limits

Advertising estimate equals actual impressions divided by 1,000 times observed publisher eCPM, reported by currency and precision. Permanent product income is actual one-time purchases net of relevant deductions/refunds; existing owners do not pay again every month. Once the finite Medal catalogue is exhausted, that ad opportunity disappears. Ad-free owners replace some future ad impressions with a purchase; evaluate total contribution rather than counting both hypothetical streams simultaneously.

Cohort contribution is observed net receipts minus attributable variable service/acquisition costs. Extrapolated lifetime revenue must show assumptions, uncertainty and the finite campaign ceiling. The game can be fun and still have weak purchase demand or poor discoverability. There is no guarantee that copying the structure of a successful browser game reproduces its audience.

## 18.7 Continue, correct or stop

Correct evidenced comprehension, pacing, dominant strategies, crashes or monetization errors within scope. Do not solve low retention automatically with gear, heroes, dailies or a seventh troop. Healthy retention with low ad opt-in is not permission to force ads. Lack of organic reach may justify ending investment rather than violating organic-only constraints.

Track opportunity cost against the owner's other games without importing their scope. The continuation decision uses actual play/reliability/revenue and required maintenance effort. No background marketing, scheduled report or automatic spending has been configured by this source pack.


---

<!-- Source: bibles/19_OPERATIONS_SUPPORT_AND_RECOVERY.md -->

# Bible 19 — Operations, Support, Recovery and Retirement

**Authority:** OPS001. The operator is the owner or an explicitly authorized delegate. These are runbooks, not configured automation or a promise of around-the-clock service.

## 19.1 Ownership and access

Each production system needs an owner, least-privilege operator role, secure credential location, MFA/recovery method, backup procedure and rotation procedure. Cover Play, payments, AdMob, Firebase/cloud, domain/DNS/support, provider licences, repository/storage and signing/receipt keys. Do not put passwords or service-account secrets in the documentation. One workstation failure must not destroy the ability to build, restore ownership records or publish a hotfix.

Use project-scoped resources and separate environments. Only the entitlement service may write ownership records. A game's offline campaign does not justify an unprotected database. Record public certificate/key IDs and hashes as needed; private keys remain in authorized secret storage.

## 19.2 Support intake

Categories are missing purchase, restore, pending purchase, missing ad reward, save/progress, crash/startup, gameplay, privacy/data request, refund and other. The game can copy a support diagnostic summary containing app/build/balance/save versions, Android/device and an anonymous support ID. It must not copy purchase tokens, banking information, full SDK logs, arbitrary file contents or analytics identifiers unnecessarily.

Support is an external page/email route with the actual address supplied before release. Opening support does not silently upload the save. The owner can request a user-approved redacted diagnostic file when necessary. Explain local reset, reinstall loss and restoration accurately; never tell a player to uninstall as a routine first step without warning about local progress.

Pending purchases may finish through Play later; do not tell users to buy again to fix unknown verification. Restore queries actual ownership. Refund processing follows Play/applicable procedures, not an invented instant refund endpoint. Missing ad rewards require the original run/attempt evidence; support cannot promise to reconstruct a callback that never arrived.

## 19.3 Severity and response

P0: systemic destructive saves, paid ownership lost/incorrectly exposed, security breach. Contain the affected flow, preserve evidence, stop unsafe distribution/new sales where appropriate and prioritize recovery.

P1: widespread crash/ANR/start failure or systematic earned-reward failure. Halt affected update/offer where possible, identify build/config/device scope and prepare a tested fix.

P2: bounded balance/visual/isolated reliability defect. Reproduce and schedule a focused correction with regression. P3: minor cosmetic/copy polish. Do not spend the entire small-project budget fixing harmless formatting while player-impacting issues remain.

An incident report includes first observation, affected versions/cohorts, impact, logs/IDs with redaction, containment, source change, tests, rollout and root cause. Source-controlled code review severity and operational severity are related but not automatically identical.

## 19.4 Containment boundaries

Remote switches can disable new ad or IAP requests and show a support notice. They cannot erase an existing entitlement or cancel an already earned grant. A switch does not reach a disconnected client instantly. Halted Play updates do not uninstall affected binaries. Server/config rollback and a higher-versionCode fix-forward app are separate procedures.

Restore backend snapshots through an access-controlled procedure; do not regrant purchases blindly by replaying notifications. Reconcile authoritative store states and preserve idempotency. Keep prior public client response formats and receipt keys valid during transition. If a key is compromised, document the specific rotation/reverification response and unavoidable offline limitations.

## 19.5 Costs and telemetry maintenance

After releases check crashes/ANRs, saves, purchases, ad grants and service costs before interpreting retention. Review gameplay/organic cohorts periodically and reconcile finances monthly when data exists. Internal cloud alert reference levels are $10 review, $25 urgent investigation and $50 incident; these are alerts, not approved spend or hard caps. Actual provider quotas/maximum instances and query budgets are separately enforced where supported.

Restrict raw log/event retention and dashboard scan range. No raw purchase token or secret in analytics logs. Review SDK changes, provider notices, API/Billing deadlines and licence/security advisories before updates. This source does not schedule reminders, cloud jobs or unattended reviews; those require actual authorized configuration.

## 19.6 Backup and recovery proof

Back up repository/source, approved asset masters and rights records, runtime exports/manifests, release AABs/symbols/mapping, signing recovery, legal/store versions and entitlement datastore. Keep an independent copy outside the main workstation/service failure domain. A backup is accepted only after a restore exercise verifies a fresh build or a consistent datastore restoration, not just after a file copy succeeds.

Archive rejected/superseded visuals without making them current references. Keep the exact source and content for each public release so player reports can be reproduced. Use a documented retention policy for sensitive transaction/support data; do not keep everything forever for convenience.

## 19.7 Update checklist

Recheck source integrity, model regression, every supported save migration, active-run handling, restores/refunds, offline receipt compatibility, consent/SDK behavior, native-page-size/ABI output, performance, audio/focus, final asset mappings and store-installed smoke tests. Verify release profile identities and symbols. Diff the Data Safety/legal inventory when data handling changes.

Record publication approval and rollout state. Monitor actual error evidence before widening an update percentage; a timer alone does not establish safety. A previous public client can remain installed for a long time, so backend compatibility and graceful unavailable states must be explicit rather than assuming every user upgrades immediately.

## 19.8 Retirement

If ending support, stop new purchases before withdrawing verification/restoration, publish clear service expectations, preserve local campaign and already-paid benefits where feasible, and remove unnecessary online dependencies through an appropriate final update. Retain required financial records while expiring unnecessary personal/pseudonymous data according to policy. Do not leave an app selling products against a deleted backend.

Avoid promises of perpetual service or automatic lifetime cloud restoration that this architecture does not provide. A responsible retirement plan is part of a small commercial game's cost, not a reason to add accounts or subscriptions now.


---

<!-- Source: bibles/20_COMPLETE_GENERATED_CATALOGUE.md -->

# Bible 20 — Complete Generated Content and Acceptance Catalogue



**Generated from the canonical files in this source package.** Edit JSON through a source amendment, then regenerate this reading aid. These tables do not create a second balance authority. All runtime QA and production assets remain unexecuted/planned.



## Units — B001

| ID | Name | Supply | HP | Troop/base hit | Period/windup ticks | Range m | Speed m/s | Half-width m | DR |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| militia | Militia | 20 | 70 | 11 / 11 | 16 / 4 | 0.6 | 1.25 | 0.25 | 0 |
| shieldguard | Shieldguard | 45 | 240 | 10 / 10 | 22 / 5 | 0.65 | 0.9 | 0.25 | 3 |
| crossbowman | Crossbowman | 50 | 75 | 50 / 25 | 36 / 7 | 5.5 | 1.05 | 0.25 | 0 |
| grenadier | Grenadier | 65 | 90 | 36 / 18 | 48 / 10 | 4.6 | 0.95 | 0.25 | 0 |
| brute | Brute | 110 | 480 | 65 / 65 | 32 / 9 | 0.85 | 0.72 | 0.45 | 0 |
| ram | Battering Ram | 100 | 420 | 14 / 150 | 40 / 11 | 0.85 | 0.8 | 0.45 | 2 |


## All24 upgrades

| ID | Name | Requires equipped | Operator/value | Exact description | Additional rules |
| --- | --- | --- | --- | --- | --- |
| u01 | Conscription | militia | paid_militia_every = 5 | Every fifth paid Militia deployment grants one additional Militia. Bonus spawns do not increment this counter. | {"counter_basis": "paid_successful_militia_deployment", "bonus_count": 1, "recursive": false, "pending_bonus_cap": 1, "counter_reset": "each_battle"} |
| u02 | Scrap Blades | militia | damage_add_pct = 0.25 | Militia damage +25%, including base damage. | {} |
| u03 | Thick Coats | militia | hp_add_pct = 0.25 | Militia maximum HP +25%. | {} |
| u04 | First Into Battle | shieldguard | first_damage_barrier_maxhp_pct = 0.3 | Shieldguard carries a barrier worth 30% of modified maximum HP. Its 8-second lifetime begins on the first positive incoming damage, absorbing that hit. One activation per unit. | {"duration_s": 8, "hp_basis": "modified_maximum", "refresh": "never_for_same_unit", "activation": "first_positive_post_mitigation_damage", "absorbs_triggering_damage": true, "untriggered_expiry": false} |
| u05 | Reinforced Shields | shieldguard | flat_reduction_add = 2 | Shieldguard flat damage reduction increases by 2. | {} |
| u06 | Heavy Boots | shieldguard | hp_add_pct = 0.3 | Shieldguard maximum HP +30%; movement speed -10%. | {"movement_add_pct": -0.1} |
| u07 | Piercing Bolts | crossbowman | additional_pierce_targets = 1 | A bolt may hit one additional enemy behind the first for 60% of the original bolt damage. | {"secondary_damage_factor": 0.6, "max_extra_distance_m": 1.5, "can_secondary_hit_base": false, "recursive": false} |
| u08 | Tighter Windlass | crossbowman | damage_add_pct = 0.25 | Crossbowman damage +25%. | {} |
| u09 | Quick Reload | crossbowman | attack_rate_add_pct = 0.2 | Crossbowman attack rate +20%. | {} |
| u10 | Packed Powder | grenadier | splash_radius_add_pct = 0.5 | Grenadier explosion radius +50%. | {} |
| u11 | Heavy Charges | grenadier | damage_add_pct = 0.25 | Grenadier damage +25%. | {} |
| u12 | Fast Fuses | grenadier | attack_rate_add_pct = 0.2 | Grenadier attack rate +20%. Projectile travel is unchanged. | {} |
| u13 | Sweeping Club | brute | extra_melee_targets = 2 | Brute strikes also hit the nearest two additional enemy units within 0.8m of the primary target for 40% damage. | {"additional_targets": 2, "radius_m": 0.8, "secondary_damage_factor": 0.4, "can_secondary_hit_base": false, "recursive": false} |
| u14 | Iron Belly | brute | hp_add_pct = 0.25 | Brute maximum HP +25%. | {} |
| u15 | Brutal Force | brute | damage_add_pct = 0.25 | Brute damage +25%. | {} |
| u16 | Splintering Head | ram | base_hits_per_bonus = 3 | Every third landed Ram hit on an enemy base deals an additional 100% of that hit’s direct damage to the base. | {"landed_base_hits_interval": 3, "bonus_damage_factor": 1.0, "recursive": false, "counter_reset": "per_ram_spawn"} |
| u17 | Siege Engineering | ram | base_damage_add_pct = 0.35 | Ram base damage +35%; Supply cost +15%. | {"supply_cost_add_pct": 0.15} |
| u18 | Reinforced Frame | ram | hp_add_pct = 0.25 | Ram maximum HP +25%. | {} |
| u19 | War Economy | General | supply_rate_add_pct = 0.15 | Supply regeneration +15%. | {} |
| u20 | Deep Stores | General | supply_cap_add = 50 | Supply capacity +50 and starting Supply +25 each battle. | {"starting_supply_add": 25} |
| u21 | War Drums | General | rally_duration_add_s = 2 | Rally duration +2 seconds. | {} |
| u22 | Field Training | General | hp_and_damage_add_pct = 0.1 | All troops gain +10% maximum HP and +10% damage. | {"hp_add_pct": 0.1, "damage_add_pct": 0.1} |
| u23 | Rapid Orders | General | rally_cooldown_add_s = -5 | Rally cooldown -5 seconds. The initial 12-second cooldown is unchanged. | {"initial_cooldown_changed": false} |
| u24 | Forced March | General | move_speed_add_pct = 0.15 | All troops move 15% faster. | {} |


## Nine expeditions

| ID | Name | Unlock after | Ordered encounters | Completion | First clear |
| --- | --- | --- | --- | --- | --- |
| c01_e01 | First Muster | Initially | c01_e01_b01, c01_e01_b02, c01_e01_b03, c01_e01_b04 | 20 | 20 |
| c01_e02 | Shield Road | c01_e01 | c01_e02_b01, c01_e02_b02, c01_e02_b03, c01_e02_b04 | 20 | 20 |
| c01_e03 | Barrel Crossing | c01_e02 | c01_e03_b01, c01_e03_b02, c01_e03_b03, c01_e03_b04 | 20 | 20 |
| c02_e01 | Heavy Footsteps | c01_e03 | c02_e01_b01, c02_e01_b02, c02_e01_b03, c02_e01_b04 | 30 | 20 |
| c02_e02 | Siege Track | c02_e01 | c02_e02_b01, c02_e02_b02, c02_e02_b03, c02_e02_b04 | 30 | 20 |
| c02_e03 | Powder Ridge | c02_e02 | c02_e03_b01, c02_e03_b02, c02_e03_b03, c02_e03_b04 | 30 | 20 |
| c03_e01 | Broken Standards | c02_e03 | c03_e01_b01, c03_e01_b02, c03_e01_b03, c03_e01_b04 | 40 | 20 |
| c03_e02 | Iron Convoy | c03_e01 | c03_e02_b01, c03_e02_b02, c03_e02_b03, c03_e02_b04 | 40 | 20 |
| c03_e03 | Last Gate | c03_e02 | c03_e03_b01, c03_e03_b02, c03_e03_b03, c03_e03_b04 | 40 | 20 |


## All36 enemy schedules

Each queue is ordered and finite. Funding bounds below assume no living-unit cap/congestion/combat; they are **not battle duration**. Boss index is zero-based. Orders expire at180 seconds.



### c01_e01_b01 — militia_patrol

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 650 | 70 / 4.5 / 200 | 8 / 1.2 | 215 | 10 | None / None | 32.25s |


Queue: militia → militia → militia → crossbowman → militia → shieldguard → militia → militia.



### c01_e01_b02 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 650 | 70 / 4.5 / 200 | 3 / 1.2 | 650 | 10 | None / None | 128.9s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c01_e01_b03 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 650 | 70 / 4.5 / 200 | 3 / 1.2 | 460 | 10 | None / None | 86.7s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c01_e01_b04 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 800 | 70 / 4.9 / 200 | 3 / 1.2 | 650 | 10 | None / None | 118.4s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c01_e02_b01 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 685 | 70 / 4.75 / 200 | 3 / 1.2 | 650 | 10 | None / None | 122.15s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c01_e02_b02 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 685 | 70 / 4.75 / 200 | 3 / 1.2 | 460 | 10 | None / None | 82.15s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c01_e02_b03 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 685 | 70 / 4.75 / 200 | 3 / 1.2 | 720 | 10 | None / None | 136.85s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c01_e02_b04 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 835 | 70 / 5.15 / 200 | 3 / 1.2 | 460 | 10 | None / None | 75.75s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c01_e03_b01 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 720 | 70 / 5.0 / 200 | 3 / 1.2 | 460 | 10 | None / None | 78.0s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c01_e03_b02 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 720 | 70 / 5.0 / 200 | 3 / 1.2 | 720 | 10 | None / None | 130.0s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c01_e03_b03 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 720 | 70 / 5.0 / 200 | 3 / 1.2 | 650 | 10 | None / None | 116.0s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c01_e03_b04 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 870 | 70 / 5.4 / 200 | 3 / 1.2 | 720 | 10 | boss_bulwark / 0 | 120.4s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c02_e01_b01 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 755 | 80 / 5.25 / 200 | 3 / 1.2 | 975 | 15 | None / None | 170.5s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c02_e01_b02 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 755 | 80 / 5.25 / 200 | 3 / 1.2 | 995 | 15 | None / None | 174.3s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia.



### c02_e01_b03 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 755 | 80 / 5.25 / 200 | 3 / 1.2 | 690 | 15 | None / None | 116.2s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c02_e01_b04 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 905 | 80 / 5.65 / 200 | 3 / 1.2 | 1060 | 15 | boss_bulwark / 1 | 173.5s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier.



### c02_e02_b01 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 790 | 80 / 5.5 / 200 | 3 / 1.2 | 1060 | 15 | None / None | 178.2s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier.



### c02_e02_b02 — siege_push

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 790 | 80 / 5.5 / 200 | 3 / 1.2 | 1050 | 15 | None / None | 176.4s |


Queue: shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard.



### c02_e02_b03 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 790 | 80 / 5.5 / 200 | 3 / 1.2 | 1030 | 15 | None / None | 172.75s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia.



### c02_e02_b04 — siege_push

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 940 | 80 / 5.9 / 200 | 3 / 1.2 | 1135 | 15 | None / None | 178.85s |


Queue: shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia.



### c02_e03_b01 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 825 | 80 / 5.75 / 200 | 3 / 1.2 | 1080 | 15 | None / None | 173.95s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c02_e03_b02 — swarm

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 825 | 80 / 5.75 / 200 | 3 / 1.2 | 690 | 15 | None / None | 106.1s |


Queue: militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard → militia → militia → militia → grenadier → militia → militia → militia → shieldguard.



### c02_e03_b03 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 825 | 80 / 5.75 / 200 | 3 / 1.2 | 1105 | 15 | None / None | 178.3s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard.



### c02_e03_b04 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 975 | 80 / 6.15 / 200 | 3 / 1.2 | 1080 | 15 | boss_powder / 1 | 162.65s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c03_e01_b01 — mixed

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 860 | 90 / 6.0 / 200 | 3 / 1.2 | 1110 | 20 | None / None | 170.0s |


Queue: militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia.



### c03_e01_b02 — shield_line

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 860 | 90 / 6.0 / 200 | 3 / 1.2 | 975 | 20 | None / None | 147.5s |


Queue: shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman → shieldguard → crossbowman → militia → shieldguard → crossbowman → militia → shieldguard → crossbowman.



### c03_e01_b03 — siege_push

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 860 | 90 / 6.0 / 200 | 3 / 1.2 | 1135 | 20 | None / None | 174.2s |


Queue: shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia.



### c03_e01_b04 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 1010 | 90 / 6.4 / 200 | 3 / 1.2 | 1125 | 20 | boss_bulwark / 1 | 161.75s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia.



### c03_e02_b01 — siege_push

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 895 | 90 / 6.25 / 200 | 3 / 1.2 | 1185 | 20 | None / None | 175.2s |


Queue: shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman.



### c03_e02_b02 — mixed

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 895 | 90 / 6.25 / 200 | 3 / 1.2 | 1110 | 20 | None / None | 163.2s |


Queue: militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia.



### c03_e02_b03 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 895 | 90 / 6.25 / 200 | 3 / 1.2 | 1080 | 20 | None / None | 158.4s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c03_e02_b04 — siege_push

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 1045 | 90 / 6.65 / 200 | 3 / 1.2 | 1185 | 20 | boss_powder / 5 | 164.7s |


Queue: shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman → shieldguard → crossbowman → ram → militia → shieldguard → grenadier → militia → crossbowman.



### c03_e03_b01 — mixed

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 930 | 90 / 6.5 / 200 | 3 / 1.2 | 1220 | 20 | None / None | 173.85s |


Queue: militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute.



### c03_e03_b02 — artillery

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 930 | 90 / 6.5 / 200 | 3 / 1.2 | 1080 | 20 | None / None | 152.35s |


Queue: shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman → shieldguard → grenadier → militia → crossbowman.



### c03_e03_b03 — brute_guard

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 930 | 90 / 6.5 / 200 | 3 / 1.2 | 1125 | 20 | None / None | 159.25s |


Queue: militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia → militia → shieldguard → brute → crossbowman → militia → grenadier → shieldguard → militia.



### c03_e03_b04 — mixed

| Enemy base HP | Start/rate/cap Supply | Opening/gap sec | Budget | Win Medals | Boss/index | Funding-only last deployment |
| --- | --- | --- | --- | --- | --- | --- |
| 1080 | 90 / 6.9 / 200 | 3 / 1.2 | 1265 | 20 | boss_powder / 3 | 170.3s |


Queue: militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard → ram → militia → shieldguard → crossbowman → grenadier → militia → brute → shieldguard.



## Boss variants

```json

[
  {
    "id": "boss_bulwark",
    "base_unit": "shieldguard",
    "hp_multiplier": 2,
    "damage_multiplier": 1.2,
    "supply_cost_multiplier": 1,
    "special": "30%-max-HP barrier armed at spawn; activated by first positive incoming damage; lasts 8 seconds including trigger hit",
    "maximum_per_encounter": 1,
    "asset_id": "boss_bulwark",
    "note": "Explicit encounter enemy-budget exception: stronger fixed variant costs base unit price; disclosed in briefing.",
    "resolved_b001": {
      "hp": 480,
      "damage": 12,
      "base_damage": 12,
      "supply_cost": 45,
      "attack_period_ticks": 22,
      "windup_ticks": 5,
      "move_speed_m_s": 0.9,
      "barrier_hp": 144
    }
  },
  {
    "id": "boss_powder",
    "base_unit": "grenadier",
    "hp_multiplier": 1.75,
    "damage_multiplier": 1.15,
    "supply_cost_multiplier": 1,
    "special": "existing splash radius multiplier 1.5",
    "maximum_per_encounter": 1,
    "asset_id": "boss_powder",
    "note": "Explicit encounter enemy-budget exception: stronger fixed variant costs base unit price; disclosed in briefing.",
    "resolved_b001": {
      "hp": 158,
      "damage": 41,
      "base_damage": 21,
      "supply_cost": 65,
      "attack_period_ticks": 48,
      "windup_ticks": 10,
      "move_speed_m_s": 0.95,
      "splash_radius_m": 1.5
    }
  }
]

```



## Economy and products

```json

{
  "economy": {
    "currency": "medals",
    "premium_currency": false,
    "starting_balance": 0,
    "troop_unlocks": {
      "brute": 40,
      "ram": 80
    },
    "cosmetic_banners": [
      {
        "id": "banner_oak",
        "cost_medals": 160
      },
      {
        "id": "banner_barrel",
        "cost_medals": 340
      },
      {
        "id": "banner_iron",
        "cost_medals": 700
      }
    ],
    "reward_bonus": {
      "factor": 0.5,
      "basis": "sum of battle-win Medals in the just-finished expedition only; excludes completion and first-clear bonuses",
      "rounding": "floor",
      "claim_once_per_run": true,
      "eligible": "at least one battle won; expedition not the introductory attempt; at least one remaining Medal unlock",
      "max_rewarded_ads_per_run_total": 2
    },
    "rewards_atomic": true,
    "no_reward_on_unresolved_battle": true,
    "no_daily_rewards": true,
    "finite_sinks_acknowledged": true,
    "ad_bonus_after_all_unlocks": "hidden for all players; do not sell future value that no longer exists",
    "balance_version": "B001",
    "total_medal_sinks": 1320,
    "design_path": "Troops first, then Oak/Barrel/Iron. First-clear campaign in order; repeat c03_e03 after finishing nine. Consecutive full wins; no failure assumption.",
    "purchase_priority": [
      "brute",
      "ram",
      "banner_oak",
      "banner_barrel",
      "banner_iron"
    ],
    "promised_unlock_times": false,
    "unlock_costs_are_design_authority": true
  },
  "products": [
    {
      "id": "adfree_bonuses",
      "type": "non_consumable",
      "entitlements": [
        "one additional draft reroll per expedition without an ad",
        "one eligible +50% battle-Medal bonus per ended expedition without an ad"
      ],
      "limits": "same limits and eligibility as the two rewarded placements; one free reroll remains for everyone",
      "restorable": true,
      "store_copy_requirement": "Explain finite Medal progression and continued reroll benefit; no permanent stats; no forced ads exist in the free game.",
      "after_all_medal_unlocks": "Keep same USD base price; dynamically truthful benefit text mentions only additional reroll. No personalized price changes. Owned benefits persist.",
      "usd_base_price": 4.99,
      "price_status": "LOCKED_INITIAL_PRICE_NOT_CONVERSION_VALIDATED",
      "external_store_created": false
    },
    {
      "id": "cosmetic_army_pack",
      "type": "non_consumable",
      "entitlements": [
        "one coordinated cosmetic set: banner, shield marking, fortress trim, equipment accents"
      ],
      "restorable": true,
      "statistics_effect": "none",
      "store_copy_requirement": "Preview exactly what changes; one set, not six new troop models.",
      "usd_base_price": 2.99,
      "price_status": "LOCKED_INITIAL_PRICE_NOT_CONVERSION_VALIDATED",
      "external_store_created": false
    }
  ]
}

```



## Animation timing

| Unit | Move cycle s | Attack s | Release/impact s | Follow-through s | Recovery s | Death s |
| --- | --- | --- | --- | --- | --- | --- |
| militia | 0.64 | 0.8 | 0.2 | 0.15 | 0.45 | 0.45 |
| shieldguard | 0.9 | 1.1 | 0.25 | 0.2 | 0.65 | 0.6 |
| crossbowman | 0.8 | 1.8 | 0.35 | 0.15 | 1.3 | 0.45 |
| grenadier | 0.85 | 2.4 | 0.5 | 0.2 | 1.7 | 0.55 |
| brute | 1.1 | 1.6 | 0.45 | 0.25 | 0.9 | 0.8 |
| ram | distance driven | 2 | 0.55 | 0.3 | 1.15 | 1.0 |


## 35 custom events

| ID | Name | Parameters | Origin |
| --- | --- | --- | --- |
| ev01 | game_boot | boot_outcome, startup_ms, save_version | client |
| ev02 | tutorial_step | step_id, outcome | client |
| ev03 | view_open | view_id, entry_reason | client |
| ev04 | army_changed | loadout_id, slot, unit_id | client |
| ev05 | expedition_start | expedition_id, run_id, loadout_id, is_replay | client |
| ev06 | expedition_resume | expedition_id, run_id, checkpoint_kind | client |
| ev07 | expedition_end | expedition_id, run_id, outcome, battles_won, active_seconds | client |
| ev08 | battle_start | encounter_id, run_id, attempt_id, loadout_id, build_id | client |
| ev09 | battle_end | encounter_id, run_id, attempt_id, outcome, duration_s, base_hp_fraction, enemy_base_hp_fraction, supply_spent, supply_wasted, peak_units | client |
| ev10 | battle_unit_summary | attempt_id, unit_id, side, spawned, damage_units, damage_base, deaths, time_alive_s | client |
| ev11 | battle_interrupted | attempt_id, cause, elapsed_s | client |
| ev12 | rally_summary | attempt_id, uses, first_use_s, active_s | client |
| ev13 | draft_offered | run_id, draft_id, option_1, option_2, option_3, offer_ordinal | client |
| ev14 | draft_chosen | run_id, draft_id, upgrade_id, decision_ms, offer_ordinal | client |
| ev15 | draft_reroll | run_id, draft_id, source, reward_id | client |
| ev16 | medals_changed | transaction_id, source_or_sink, amount, balance_after | client |
| ev17 | unlock_complete | unlock_id, medal_cost | client |
| ev18 | shop_view | entry_point, remaining_medal_unlocks | client |
| ev19 | reward_offer | placement_id, run_id, reward_id, eligible | client |
| ev20 | reward_request | placement_id, reward_id, consent_bucket | client |
| ev21 | reward_load_result | placement_id, reward_id, outcome, error_class | client |
| ev22 | reward_show_result | placement_id, reward_id, outcome, error_class | client |
| ev23 | reward_earned | placement_id, reward_id, sdk_source | client |
| ev24 | reward_granted | placement_id, reward_id, grant_source, reward_value | client |
| ev25 | iap_intent | product_id, display_currency, entry_point | client |
| ev26 | iap_state | product_id, outcome, error_class | client |
| ev27 | entitlement_sync | product_id, state, source, latency_ms | client |
| ev28 | restore_result | outcome, entitlements_found, error_class | client |
| ev29 | save_result | operation, schema_version, outcome, error_class | client |
| ev30 | consent_state | revision, analytics_allowed, ads_request_allowed | client |
| ev31 | config_applied | config_version, outcome | client |
| ev32 | performance_summary | device_tier, duration_s, p95_frame_ms, peak_memory_mb, fps_target | client |
| ev33 | support_open | reason, view_id | client |
| ev34 | purchase_verified | product_id, purchase_hash, currency, value, is_test | backend |
| ev35 | purchase_revoked | product_id, purchase_hash, reason | backend |


The transport contract adds bounded source/schema context and a qualifying-gameplay sample on performance_summary. SDK-owned automatic events are not manually duplicated.

## Complete English copy

| String ID | English template |
| --- | --- |
| home.title | Campaign |
| home.play | Start expedition |
| home.resume | Resume expedition |
| home.army | Army |
| home.shop | Shop |
| home.settings | Settings |
| campaign.locked | Complete {expedition} to unlock. |
| campaign.complete | Campaign complete. Replay any expedition with a different army. |
| army.title | Choose your army |
| army.equipped | {count}/4 equipped |
| army.need_four | Equip four different troops. |
| army.equip | Equip |
| army.unequip | Unequip |
| army.locked | Unlock for {medals} Medals |
| army.unlock | Unlock |
| army.no_medals | Not enough Medals. |
| army.run_locked | Your army is fixed for this expedition. |
| briefing.title | Expedition briefing |
| briefing.battles | Four battles. Choose an upgrade before each. |
| briefing.enemy | Enemy formation |
| briefing.boss | Stronghold defender: {boss} |
| briefing.start | Choose starting upgrade |
| battle.supply | Supply |
| battle.base | Your fortress |
| battle.enemy_base | Enemy fortress |
| battle.army_full | Army full: 24/24 |
| battle.no_supply | Need {supply} Supply |
| battle.cooldown | Deploying… |
| battle.rally | Rally |
| battle.rally_ready | Ready |
| battle.rally_active | Rally active |
| battle.rally_wait | {seconds}s |
| battle.overtime | Overtime: fortress damage doubled |
| battle.end_time | Battle ends in {seconds}s |
| tutorial.front | Deploy a Shieldguard to protect your army. |
| tutorial.ranged | Deploy a Crossbowman behind your frontline. |
| tutorial.rally | Use Rally to speed up your army’s attacks. |
| tutorial.skip | Skip guidance |
| tutorial.next | Continue |
| draft.title | Choose an upgrade |
| draft.pick | Choose |
| draft.progress | Upgrade {number}/4 |
| draft.free_reroll | Free reroll |
| draft.ad_reroll | Watch an ad for one reroll |
| draft.owned_reroll | Use extra reroll |
| draft.no_rerolls | No rerolls left this expedition |
| draft.ad_unavailable | Ad unavailable. Choose an upgrade or retry later. |
| results.win | Victory |
| results.loss | Defeat |
| results.draw | Draw |
| results.expedition_win | Expedition complete |
| results.banked | {medals} Medals saved |
| results.bonus | Watch an ad for +{medals} Medals |
| results.owned_bonus | Claim +{medals} Medals |
| results.claimed | Bonus claimed |
| results.continue | Continue |
| results.retry | Try expedition again |
| results.home | Return to campaign |
| results.last_battle | Rewards from earlier wins are already saved. |
| pause.title | Paused |
| pause.resume | Resume |
| pause.home | Return to campaign |
| pause.abandon | Abandon expedition |
| pause.save_notice | A closed app restarts this battle from its beginning. |
| abandon.title | Abandon this expedition? |
| abandon.body | Your {medals} banked Medals stay saved. This army build and unfinished battle will be lost. |
| abandon.confirm | Abandon |
| abandon.cancel | Keep expedition |
| shop.title | Shop |
| shop.adfree | Ad-free Bonuses |
| shop.adfree_body | Claim the extra expedition reroll and eligible Medal bonus without watching ads. The usual limits still apply. Medal bonuses end when all Medal unlocks are owned. The free game has no forced ads. |
| shop.adfree_exhausted | Claim one extra reroll per expedition without an ad. You already own every Medal unlock, so Medal bonuses are no longer offered. The free game has no forced ads. |
| shop.cosmetic | Cosmetic Army Pack |
| shop.cosmetic_body | One coordinated banner, shield marking, fortress trim and equipment-accent set. No combat advantage. |
| shop.buy | Buy · {price} |
| shop.owned | Owned |
| shop.restore | Restore purchases |
| shop.preview | Preview |
| shop.no_price | Store unavailable |
| shop.network | An internet connection is needed to purchase or restore. |
| purchase.pending | Payment pending. Benefits unlock after the store confirms payment. |
| purchase.verifying | Verifying purchase… |
| purchase.success | Purchase restored or completed. Benefits are available. |
| purchase.cancelled | Purchase cancelled. No benefit was added. |
| purchase.failed | Purchase could not be completed. Check the store and try again. |
| purchase.recovering | Purchase received. Verification will retry when connected. Do not buy it again. |
| purchase.restore_none | No owned products were returned by this store account. |
| purchase.revoked | The store reports this purchase is no longer owned. Contact support for purchase issues. |
| settings.title | Settings |
| settings.music | Music |
| settings.sfx | Sound effects |
| settings.ui | Interface sounds |
| settings.haptics | Vibration |
| settings.motion | Reduced motion |
| settings.flashes | Reduced flashes |
| settings.privacy | Privacy choices |
| settings.support | Support |
| settings.reset | Reset local progress |
| settings.build | Version {version} · {balance} |
| save.failed | Progress could not be saved. Free device storage and retry. Your last valid save has been kept. |
| save.retry | Retry saving |
| save.backup | Your backup save was recovered. The most recent unsaved action may be missing. |
| save.unreadable | Neither local save could be read. No automatic reset was performed. |
| save.newer | This save was created by a newer game version. Update the app; your save has not been replaced. |
| save.local_notice | Progress is stored on this device only. Reinstalling or changing devices may lose progress. Purchases can be restored separately. |
| reset.title | Reset local progress? |
| reset.body | Campaign progress, Medals, troop unlocks, earned banners and the current expedition will be erased. Purchases and privacy settings remain. This cannot be undone. |
| reset.confirm | Reset progress |
| reset.cancel | Cancel |
| service.offline | Offline. Battles and saved progress remain available. |
| service.retry | Retry |
| service.close | Close |
| privacy.notice | Manage advertising and data choices. These choices do not block ordinary gameplay. |
| support.missing | Support information is not configured in this development build. |
| reward.processing | Saving your earned reward… |
| reward.failed | Your reward receipt is saved, but the grant could not be saved yet. Retry saving; do not watch another ad for this claim. |
| unit.hp | Health |
| unit.damage | Troop damage |
| unit.base_damage | Fortress damage |
| unit.period | Attack interval |
| unit.range | Range |
| unit.speed | Movement |
| unit.cost | Supply cost |
| unit.reduction | Damage reduction |
| general.back | Back |
| general.confirm | Confirm |
| general.cancel | Cancel |
| general.on | On |
| general.off | Off |
| unit.militia.name | Militia |
| unit.shieldguard.name | Shieldguard |
| unit.crossbowman.name | Crossbowman |
| unit.grenadier.name | Grenadier |
| unit.brute.name | Brute |
| unit.ram.name | Battering Ram |
| upgrade.u01.title | Conscription |
| upgrade.u01.body | Every fifth paid Militia deployment grants one additional Militia. Bonus spawns do not increment this counter. |
| upgrade.u02.title | Scrap Blades |
| upgrade.u02.body | Militia damage +25%, including base damage. |
| upgrade.u03.title | Thick Coats |
| upgrade.u03.body | Militia maximum HP +25%. |
| upgrade.u04.title | First Into Battle |
| upgrade.u04.body | Shieldguard carries a barrier worth 30% of modified maximum HP. Its 8-second lifetime begins on the first positive incoming damage, absorbing that hit. One activation per unit. |
| upgrade.u05.title | Reinforced Shields |
| upgrade.u05.body | Shieldguard flat damage reduction increases by 2. |
| upgrade.u06.title | Heavy Boots |
| upgrade.u06.body | Shieldguard maximum HP +30%; movement speed -10%. |
| upgrade.u07.title | Piercing Bolts |
| upgrade.u07.body | A bolt may hit one additional enemy behind the first for 60% of the original bolt damage. |
| upgrade.u08.title | Tighter Windlass |
| upgrade.u08.body | Crossbowman damage +25%. |
| upgrade.u09.title | Quick Reload |
| upgrade.u09.body | Crossbowman attack rate +20%. |
| upgrade.u10.title | Packed Powder |
| upgrade.u10.body | Grenadier explosion radius +50%. |
| upgrade.u11.title | Heavy Charges |
| upgrade.u11.body | Grenadier damage +25%. |
| upgrade.u12.title | Fast Fuses |
| upgrade.u12.body | Grenadier attack rate +20%. Projectile travel is unchanged. |
| upgrade.u13.title | Sweeping Club |
| upgrade.u13.body | Brute strikes also hit the nearest two additional enemy units within 0.8m of the primary target for 40% damage. |
| upgrade.u14.title | Iron Belly |
| upgrade.u14.body | Brute maximum HP +25%. |
| upgrade.u15.title | Brutal Force |
| upgrade.u15.body | Brute damage +25%. |
| upgrade.u16.title | Splintering Head |
| upgrade.u16.body | Every third landed Ram hit on an enemy base deals an additional 100% of that hit’s direct damage to the base. |
| upgrade.u17.title | Siege Engineering |
| upgrade.u17.body | Ram base damage +35%; Supply cost +15%. |
| upgrade.u18.title | Reinforced Frame |
| upgrade.u18.body | Ram maximum HP +25%. |
| upgrade.u19.title | War Economy |
| upgrade.u19.body | Supply regeneration +15%. |
| upgrade.u20.title | Deep Stores |
| upgrade.u20.body | Supply capacity +50 and starting Supply +25 each battle. |
| upgrade.u21.title | War Drums |
| upgrade.u21.body | Rally duration +2 seconds. |
| upgrade.u22.title | Field Training |
| upgrade.u22.body | All troops gain +10% maximum HP and +10% damage. |
| upgrade.u23.title | Rapid Orders |
| upgrade.u23.body | Rally cooldown -5 seconds. The initial 12-second cooldown is unchanged. |
| upgrade.u24.title | Forced March |
| upgrade.u24.body | All troops move 15% faster. |
| briefing.enemy_orders | Enemy reinforcements stop after 3:00. Existing troops keep fighting. |


## 148 planned asset families

| ID | Category | Name | Provider | Status |
| --- | --- | --- | --- | --- |
| unit_militia | troop_master | Militia | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_militia | unit_portrait | Militia portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_militia_idle | animation_binding | Militia idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_militia_move | animation_binding | Militia move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_militia_attack | animation_binding | Militia attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_militia_hit | animation_binding | Militia hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_militia_death | animation_binding | Militia death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_militia_victory | animation_binding | Militia victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| unit_shieldguard | troop_master | Shieldguard | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_shieldguard | unit_portrait | Shieldguard portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_shieldguard_idle | animation_binding | Shieldguard idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_shieldguard_move | animation_binding | Shieldguard move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_shieldguard_attack | animation_binding | Shieldguard attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_shieldguard_hit | animation_binding | Shieldguard hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_shieldguard_death | animation_binding | Shieldguard death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_shieldguard_victory | animation_binding | Shieldguard victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| unit_crossbowman | troop_master | Crossbowman | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_crossbowman | unit_portrait | Crossbowman portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_crossbowman_idle | animation_binding | Crossbowman idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_crossbowman_move | animation_binding | Crossbowman move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_crossbowman_attack | animation_binding | Crossbowman attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_crossbowman_hit | animation_binding | Crossbowman hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_crossbowman_death | animation_binding | Crossbowman death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_crossbowman_victory | animation_binding | Crossbowman victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| unit_grenadier | troop_master | Grenadier | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_grenadier | unit_portrait | Grenadier portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_grenadier_idle | animation_binding | Grenadier idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_grenadier_move | animation_binding | Grenadier move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_grenadier_attack | animation_binding | Grenadier attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_grenadier_hit | animation_binding | Grenadier hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_grenadier_death | animation_binding | Grenadier death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_grenadier_victory | animation_binding | Grenadier victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| unit_brute | troop_master | Brute | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_brute | unit_portrait | Brute portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_brute_idle | animation_binding | Brute idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_brute_move | animation_binding | Brute move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_brute_attack | animation_binding | Brute attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_brute_hit | animation_binding | Brute hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_brute_death | animation_binding | Brute death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_brute_victory | animation_binding | Brute victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| unit_ram | troop_master | Battering Ram | Higgsfield | PLANNED_NOT_GENERATED |
| portrait_ram | unit_portrait | Battering Ram portrait | derived_from_approved_master | PLANNED_NOT_GENERATED |
| anim_ram_idle | animation_binding | Battering Ram idle | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_ram_move | animation_binding | Battering Ram move | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_ram_attack | animation_binding | Battering Ram attack | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_ram_hit | animation_binding | Battering Ram hit | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_ram_death | animation_binding | Battering Ram death | Unity editor / Codex | PLANNED_NOT_GENERATED |
| anim_ram_victory | animation_binding | Battering Ram victory | Unity editor / Codex | PLANNED_NOT_GENERATED |
| boss_bulwark | derived_boss | Bulwark | Higgsfield + approved unit derivatives | PLANNED_NOT_GENERATED |
| boss_powder | derived_boss | Powder Captain | Higgsfield + approved unit derivatives | PLANNED_NOT_GENERATED |
| env_fields | environment | Border Fields | Higgsfield | PLANNED_NOT_GENERATED |
| env_timber | environment | Timber Pass | Higgsfield | PLANNED_NOT_GENERATED |
| env_keep | environment | Broken Keep | Higgsfield | PLANNED_NOT_GENERATED |
| base_player | base | Player makeshift fortress | Higgsfield + Unity assembly | PLANNED_NOT_GENERATED |
| base_enemy | base | Enemy fortress | Higgsfield + Unity assembly | PLANNED_NOT_GENERATED |
| icon_u01 | upgrade_icon | Conscription | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u02 | upgrade_icon | Scrap Blades | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u03 | upgrade_icon | Thick Coats | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u04 | upgrade_icon | First Into Battle | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u05 | upgrade_icon | Reinforced Shields | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u06 | upgrade_icon | Heavy Boots | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u07 | upgrade_icon | Piercing Bolts | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u08 | upgrade_icon | Tighter Windlass | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u09 | upgrade_icon | Quick Reload | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u10 | upgrade_icon | Packed Powder | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u11 | upgrade_icon | Heavy Charges | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u12 | upgrade_icon | Fast Fuses | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u13 | upgrade_icon | Sweeping Club | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u14 | upgrade_icon | Iron Belly | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u15 | upgrade_icon | Brutal Force | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u16 | upgrade_icon | Splintering Head | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u17 | upgrade_icon | Siege Engineering | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u18 | upgrade_icon | Reinforced Frame | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u19 | upgrade_icon | War Economy | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u20 | upgrade_icon | Deep Stores | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u21 | upgrade_icon | War Drums | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u22 | upgrade_icon | Field Training | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u23 | upgrade_icon | Rapid Orders | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| icon_u24 | upgrade_icon | Forced March | Higgsfield + symbol cleanup | PLANNED_NOT_GENERATED |
| ui_home_campaign | ui_view | Home Campaign | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_army | ui_view | Army | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_battle | ui_view | Battle | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_draft | ui_view | Draft | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_results | ui_view | Results | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_shop | ui_view | Shop | Unity UI assembly | PLANNED_NOT_GENERATED |
| ui_icon_medal | shared_ui_symbol | Medal | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_supply | shared_ui_symbol | Supply | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_health | shared_ui_symbol | Health | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_rally | shared_ui_symbol | Rally | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_pause | shared_ui_symbol | Pause | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_close | shared_ui_symbol | Close | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_back | shared_ui_symbol | Back | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_lock | shared_ui_symbol | Lock | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_check | shared_ui_symbol | Check | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_retry | shared_ui_symbol | Retry | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_audio | shared_ui_symbol | Audio | original vector/simple geometry | PLANNED_NOT_GENERATED |
| ui_icon_privacy | shared_ui_symbol | Privacy | original vector/simple geometry | PLANNED_NOT_GENERATED |
| music_menu | music_loop | Menu instrumental loop | Suno + offline loop edit | PLANNED_NOT_GENERATED |
| music_battle | music_loop | Battle instrumental loop | Suno + offline loop edit | PLANNED_NOT_GENERATED |
| banner_oak | earned_banner | Oak banner | Higgsfield + approved heraldry | PLANNED_NOT_GENERATED |
| banner_barrel | earned_banner | Barrel banner | Higgsfield + approved heraldry | PLANNED_NOT_GENERATED |
| banner_iron | earned_banner | Iron banner | Higgsfield + approved heraldry | PLANNED_NOT_GENERATED |
| cosmetic_paid_set | paid_cosmetic_family | One banner/shield/fortress/equipment accent set | Higgsfield + approved unit derivatives | PLANNED_NOT_GENERATED |
| store_app_icon | store_deliverable | App Icon | approved game captures + Higgsfield/editorial as appropriate | PLANNED_NOT_GENERATED |
| store_feature_graphic | store_deliverable | Feature Graphic | approved game captures + Higgsfield/editorial as appropriate | PLANNED_NOT_GENERATED |
| store_screenshot_set | store_deliverable | Screenshot Set | approved game captures + Higgsfield/editorial as appropriate | PLANNED_NOT_GENERATED |
| store_gameplay_trailer | store_deliverable | Gameplay Trailer | approved game captures + Higgsfield/editorial as appropriate | PLANNED_NOT_GENERATED |
| store_store_copy | store_deliverable | Store Copy | approved game captures + Higgsfield/editorial as appropriate | PLANNED_NOT_GENERATED |
| vfx_deployment_dust | vfx_prefab | Deployment Dust | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_melee_slash | vfx_prefab | Melee Slash | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_light_hit | vfx_prefab | Light Hit | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_shield_block | vfx_prefab | Shield Block | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_bolt_trail_impact | vfx_prefab | Bolt Trail Impact | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_grenade_explosion | vfx_prefab | Grenade Explosion | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_spawn_barrier | vfx_prefab | Spawn Barrier | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_rally_aura | vfx_prefab | Rally Aura | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_hit_flash | vfx_prefab | Hit Flash | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_death_puff | vfx_prefab | Death Puff | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_medal_reward | vfx_prefab | Medal Reward | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| vfx_fortress_destruction | vfx_prefab | Fortress Destruction | Unity particles/materials/tweens; Higgsfield textures as needed | PLANNED_NOT_GENERATED |
| sfx_ui_tap | sound_effect | Ui Tap | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_ui_confirm | sound_effect | Ui Confirm | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_ui_cancel | sound_effect | Ui Cancel | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_ui_error | sound_effect | Ui Error | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_deploy | sound_effect | Deploy | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_troop_unlock | sound_effect | Troop Unlock | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_draft_choose | sound_effect | Draft Choose | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_medal_receipt | sound_effect | Medal Receipt | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_light_swing | sound_effect | Light Swing | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_club_swing | sound_effect | Club Swing | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_light_impact | sound_effect | Light Impact | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_shield_impact | sound_effect | Shield Impact | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_heavy_impact | sound_effect | Heavy Impact | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_crossbow_fire | sound_effect | Crossbow Fire | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_bolt_impact | sound_effect | Bolt Impact | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_grenade_release | sound_effect | Grenade Release | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_explosion | sound_effect | Explosion | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_ram_roll | sound_effect | Ram Roll | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_ram_impact | sound_effect | Ram Impact | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_soft_death | sound_effect | Soft Death | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_heavy_death | sound_effect | Heavy Death | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_rally | sound_effect | Rally | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_base_damage | sound_effect | Base Damage | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_base_destruction | sound_effect | Base Destruction | ElevenLabs | PLANNED_NOT_GENERATED |
| sfx_overtime_warning | sound_effect | Overtime Warning | ElevenLabs | PLANNED_NOT_GENERATED |
| sting_victory | audio_sting | Victory | derived from cleared Suno material | PLANNED_NOT_GENERATED |
| sting_defeat | audio_sting | Defeat | derived from cleared Suno material | PLANNED_NOT_GENERATED |
| sting_expedition_completion | audio_sting | Expedition Completion | derived from cleared Suno material | PLANNED_NOT_GENERATED |


##155 planned runtime QA cases

| ID | Area | Scenario | Acceptance | Phase | Status |
| --- | --- | --- | --- | --- | --- |
| QA-001 | combat | Empty battlefield with no deploy | No NaN, stuck engagement slot, or spontaneous damage | PH03 | NOT_RUN |
| QA-002 | combat | Same seed/input on repeated runs | Same combat outcome and currency ledger | PH03 | NOT_RUN |
| QA-003 | combat | Insufficient Supply tap | No spend, spawn, or queued purchase | PH03 | NOT_RUN |
| QA-004 | combat | 24 alive cap and rapid multi-touch | No overspend or excess actor; reason shown | PH03 | NOT_RUN |
| QA-005 | combat | Only ranged troops on both teams | They become reachable frontline targets; no invulnerability | PH03 | NOT_RUN |
| QA-006 | combat | Melee reinforcement catches own ranged line | Advances through friendlies without crossing enemies | PH03 | NOT_RUN |
| QA-007 | combat | Three melee slots and waiting reserves | Slot turnover stable; nobody teleports into range | PH03 | NOT_RUN |
| QA-008 | combat | Equal-distance targets and repeated spawns | Stable target ID ordering | PH03 | NOT_RUN |
| QA-009 | combat | Target dies during melee windup | Misses without retargeting or duplicate damage | PH03 | NOT_RUN |
| QA-010 | combat | Shooter dies after bolt release | Already released projectile remains authoritative | PH03 | NOT_RUN |
| QA-011 | combat | Grenade target moves/dies | Explosion remains at committed ground point | PH03 | NOT_RUN |
| QA-012 | combat | Splash overlaps defending base | No forbidden incidental base damage | PH03 | NOT_RUN |
| QA-013 | combat | Simultaneous actor deaths | Due same-tick impacts both resolve | PH03 | NOT_RUN |
| QA-014 | combat | Both bases destroyed in same tick | DRAW; no current battle-win reward | PH03 | NOT_RUN |
| QA-015 | combat | 150s and 210s boundaries | Overtime and integer fraction outcome exactly once | PH03 | NOT_RUN |
| QA-016 | combat | Pause/background/SDK overlay | No Supply, cooldown, movement, or enemy time advance | PH03 | NOT_RUN |
| QA-017 | combat | Rally during existing attack and new spawn | Existing attack snapshot retained; new attacks use buff | PH03 | NOT_RUN |
| QA-018 | combat | Float-equivalent rounding edges | Half-up damage, ceiling costs, minimum damage shared with UI | PH03 | NOT_RUN |
| QA-019 | combat | Projectile VFX pool exhausted | No lost gameplay damage or duplicate award | PH03 | NOT_RUN |
| QA-020 | combat | Enemy queued troop cannot afford cost | Waits without skipping queue or inventing Supply | PH03 | NOT_RUN |
| QA-021 | draft | Initial three offers | One eligible behavior option; all options usable | PH03 | NOT_RUN |
| QA-022 | draft | All 15 loadouts and seeded offer sequences | No ineligible troop upgrades; no chosen duplicate | PH03 | NOT_RUN |
| QA-023 | draft | Free and rewarded reroll exhaustion | Exactly one each; no further charge or ad offer | PH03 | NOT_RUN |
| QA-024 | draft | Force close on choice/reroll | Persisted offers and counts; no free reroll from restart | PH03 | NOT_RUN |
| QA-025 | draft | Conscription at full actor cap | At most one owed bonus; no recursive deployment | PH03 | NOT_RUN |
| QA-026 | draft | Pierce and sweeping secondary hits | Target limits/damage factors; no recursive or forbidden base proc | PH03 | NOT_RUN |
| QA-027 | draft | Every upgrade plus every pair | Modifier composition, caps, and UI descriptions agree | PH03 | NOT_RUN |
| QA-028 | draft | Third ram base hit | Only landed base hits increment; bonus never recursively retriggers | PH03 | NOT_RUN |
| QA-029 | draft | Barrier expires or takes excess damage | Correct armor/barrier/HP order and remaining damage | PH03 | NOT_RUN |
| QA-030 | save | Win reward callback repeats | One battle grant; no duplicate completion/first-clear | PH03 | NOT_RUN |
| QA-031 | save | App killed while writing | Last complete checkpoint loads; atomic write not partial JSON | PH03 | NOT_RUN |
| QA-032 | save | Primary corrupt but backup valid | Backup recovered and recorded; no unnecessary reset | PH03 | NOT_RUN |
| QA-033 | save | Primary and backup invalid | Explicit recovery state; purchases restored separately | PH03 | NOT_RUN |
| QA-034 | save | App killed mid-battle | Same prebattle checkpoint, no partial reward | PH03 | NOT_RUN |
| QA-035 | save | App killed between battle/draft | Correct next encounter and preserved banked Medals | PH03 | NOT_RUN |
| QA-036 | save | Update from every supported prior schema | Migrations preserve rewards/loadout and entitlements | PH03 | NOT_RUN |
| QA-037 | save | Storage full on reward checkpoint | No false saved claim; recoverable retry state | PH03 | NOT_RUN |
| QA-038 | save | Abandon and start other expedition | Confirmation, previous banked rewards retained | PH03 | NOT_RUN |
| QA-039 | economy | All nine first clears and repeat clears | Registry-consistent reward ledger; first-clear only once | PH03 | NOT_RUN |
| QA-040 | economy | Purchase troop/banner with insufficient Medals | No unlock, negative balance, or duplicate debit | PH03 | NOT_RUN |
| QA-041 | economy | All Medal sinks unlocked | Reward-bonus placement hidden for free and paid users | PH03 | NOT_RUN |
| QA-042 | economy | Failed run with one prior victory | Banked rewards retained; valid defined bonus only | PH03 | NOT_RUN |
| QA-043 | ads | Introductory attempt | No commercial offer or ad request tied to placement | PH05 | NOT_RUN |
| QA-044 | ads | No fill/offline/load/show failure | Gameplay continues; allowance not consumed | PH05 | NOT_RUN |
| QA-045 | ads | Reward callback arrives twice | One durable receipt and grant | PH05 | NOT_RUN |
| QA-046 | ads | Close without earned callback | No unearned reward; no lost earned receipt | PH05 | NOT_RUN |
| QA-047 | ads | Earn callback then forced close | Persisted receipt reconciles on restart | PH05 | NOT_RUN |
| QA-048 | ads | Paid bypass offline | Eligible benefits claim without ad SDK availability | PH05 | NOT_RUN |
| QA-049 | ads | Feature disabled while reward already earned | Earned obligation still honored | PH05 | NOT_RUN |
| QA-050 | ads | Consent denied/changed/withdrawn | Legal configured requests only; no retroactive backlog | PH05 | NOT_RUN |
| QA-051 | billing | Completed purchase | Verify server-side; grant exactly once; acknowledge | PH05 | NOT_RUN |
| QA-052 | billing | Pending purchase | No entitlement until verified PURCHASED | PH05 | NOT_RUN |
| QA-053 | billing | Cancelled/failed purchase | No charge claim, entitlement, or fake success | PH05 | NOT_RUN |
| QA-054 | billing | Duplicate notification/callback | Idempotent entitlement; one financial record | PH05 | NOT_RUN |
| QA-055 | billing | Reinstall and restore nonconsumables | Play ownership recovered; no campaign-restore promise | PH05 | NOT_RUN |
| QA-056 | billing | Already-owned product | Entitlement sync instead of duplicate sale | PH05 | NOT_RUN |
| QA-057 | billing | Refund/void/revoke | State reconciles online; documented offline cached limit | PH05 | NOT_RUN |
| QA-058 | billing | Wrong package/product/token | Denied; no raw token logged | PH05 | NOT_RUN |
| QA-059 | billing | Service outage after payment | Pending confirmation shown; no permanent loss or duplicate charge | PH05 | NOT_RUN |
| QA-060 | billing | Play account changes | Ownership follows verified current account; no install-ID ownership shortcut | PH05 | NOT_RUN |
| QA-061 | billing | Prices/catalog unavailable | No invented local price or enabled broken buy button | PH05 | NOT_RUN |
| QA-062 | analytics | Known scripted journey | Exact expected events appear once in raw export and dashboard | PH05 | NOT_RUN |
| QA-063 | analytics | Draft offers and selections | Offer denominators/position/reroll ordinal available | PH05 | NOT_RUN |
| QA-064 | analytics | Client plus automatic purchase/ad collection | No double-counted revenue | PH05 | NOT_RUN |
| QA-065 | analytics | Debug/test orders and dev builds | Excluded from production business metrics | PH05 | NOT_RUN |
| QA-066 | analytics | Consent denied and outgoing traffic captured | No disallowed behavior collection | PH05 | NOT_RUN |
| QA-067 | analytics | Raw export retention/deletion and access | Approved settings enforceable and verified | PH05 | NOT_RUN |
| QA-068 | analytics | Impression value/currency/precision | Correct units; estimate distinguished from final payout | PH05 | NOT_RUN |
| QA-069 | config | Malformed/offline/stale response | Local known-good default, no gameplay block | PH05 | NOT_RUN |
| QA-070 | config | Config changes during active expedition | No silent mid-run balance replacement | PH05 | NOT_RUN |
| QA-071 | assets | Militia/Crossbow/Ram rig proof | Six states, both facings, feet/grip/impact coherent | PH08 | NOT_RUN |
| QA-072 | assets | Master vs generated parts | Silhouette, joints, source rights and provenance approved | PH08 | NOT_RUN |
| QA-073 | assets | Both team appearances without color | Unit/team recognition works through shape/markings | PH03 | NOT_RUN |
| QA-074 | audio | Loop seams and overlapping combat | No clicks, clipping, or unbounded loudness | PH03 | NOT_RUN |
| QA-075 | audio | Pause/background/call/headphones | Audio focus, pause and resume correct | PH10 | NOT_RUN |
| QA-076 | performance | Crowded fight sustained device run | Bounded memory/particles/audio; stated frame budget measured | PH10 | NOT_RUN |
| QA-077 | performance | Lower tier, GPU families and aspect ratios | No clipped controls or unreadable troop silhouettes | PH10 | NOT_RUN |
| QA-078 | performance | Android native 16KB check | Native libraries and Play-delivered build work | PH10 | NOT_RUN |
| QA-079 | performance | Nearly-full disk/network transitions | Save/UI stable and truthful | PH10 | NOT_RUN |
| QA-080 | accessibility | Reduced motion/haptics/audio settings | Settings persist and apply to all effects | PH10 | NOT_RUN |
| QA-081 | accessibility | Smallest supported display and scaling | Readable prices, choices, health and touch areas | PH10 | NOT_RUN |
| QA-082 | release | Fresh clean checkout Android build | Exact pinned toolchain produces reproducible artifact | PH01 | NOT_RUN |
| QA-083 | release | Release AAB dependency/security audit | Current target/Billing; no secrets/dev menus/test ads | PH10 | NOT_RUN |
| QA-084 | release | Play-installed internal build | Signatures, products, ads and symbols checked end-to-end | PH10 | NOT_RUN |
| QA-085 | release | App-ads.txt/app readiness | Correct developer site and verified production ad path | PH11 | NOT_RUN |
| QA-086 | release | Listing/privacy/audience/content rating | Consistent with actual build and SDK data inventory | PH11 | NOT_RUN |
| QA-087 | release | First production country selection | No false first-release percentage staging assumption | PH11 | NOT_RUN |
| QA-088 | release | Upgrade rollout/incident exercise | Halt vs rollback limits understood; fix-forward prepared | PH11 | NOT_RUN |
| QA-089 | release | Independent observed first session | Player understands draft, deployment, Rally and banked rewards | PH10 | NOT_RUN |
| QA-090 | release | 15 loadouts x campaign balance sweep | No mandatory purchase/unlock to beat appropriate content | PH03 | NOT_RUN |
| QA-091 | operations | Restore source/assets/backend backup | Recoverability demonstrated, not just backup existence | PH11 | NOT_RUN |
| QA-092 | operations | Net settlement reconciliation | Gross/refunds/fees/FX/cash/expenses separated | PH11 | NOT_RUN |
| QA-093 | operations | Sunset plan | No selling benefits after abandoning the service | PH11 | NOT_RUN |
| LOCK-QA-01 | B001 amendment | Barrier approach | A Shieldguard walking without being attacked for20s retains armed barrier; first post-mitigation damage at20s activates it and is absorbed; expires at28s; no refresh. | PH03 | NOT_RUN |
| LOCK-QA-02 | B001 amendment | Barrier same tick | Two simultaneous positive hits consume one30%-HP barrier in stable order or aggregate-equivalent arithmetic; no second shield is created. | PH03 | NOT_RUN |
| LOCK-QA-03 | B001 amendment | Attack quantization | Crossbow period36ticks becomes24ticks with Quick Reload20% and Rally30%; windup7 becomes5ticks; ongoing snapshots do not change when Rally expires. | PH03 | NOT_RUN |
| LOCK-QA-04 | B001 amendment | Base-damage split | Crossbow troop/base hits50/25, Grenadier36/18, Ram14/150; global damage scales the correct independent baselines. | PH03 | NOT_RUN |
| LOCK-QA-05 | B001 amendment | Enemy cutoff | At tick3599 affordable order may deploy; at3600 and later no new enemy order; living enemies continue. Player deployments remain permitted. | PH03 | NOT_RUN |
| LOCK-QA-06 | B001 amendment | Finite queue | Every queued unit spends once; queue never wraps; population cap delays but cannot create a debt burst after cutoff. | PH03 | NOT_RUN |
| LOCK-QA-07 | B001 amendment | Boss substitution | Exact zero-based index replaced once at base-unit cost with fixed boss values; no extra ordinary unit at that index. | PH03 | NOT_RUN |
| LOCK-QA-08 | B001 amendment | Economy route | Nine ordered first clears pay990; troop-first/Oak/Barrel/Iron full-win no-ad path exhausts1320 catalogue on12th clear. | PH03 | NOT_RUN |
| LOCK-QA-09 | B001 amendment | Reroll restart | Save displayed offer and PRNG state; app kill before/after reroll cannot duplicate entitlement, allowance or regenerate a different offer. | PH03 | NOT_RUN |
| LOCK-QA-10 | B001 amendment | ES256 ownership | Tampered product/token-hash/signature is rejected; network failure retains previously verified receipt; authoritative refund removes only affected product. | PH03 | NOT_RUN |
| LOCK-QA-11 | B001 amendment | IAP telemetry consent | Observe actual UnityIAP/Firebase/ads traffic with declined, accepted and withdrawn privacy states; no unapproved duplicate analytics or pre-consent backlog. | PH03 | NOT_RUN |
| LOCK-QA-12 | B001 amendment | Emulator ABI | Record image fingerprint/abilist/native loader; a nonlaunching ARM64 library or unsupported page-size row is blocked, not counted as test success. | PH03 | NOT_RUN |
| MIG-QA-001 | migration | Source import against manifest | All hashes match;one current source;history ZIPs not implementation authority | PH01 | NOT_RUN |
| MIG-QA-002 | workflow | No provider generation before placeholder acceptance | No final image/music/SFX generation in PH01–PH06;existing V001 refs only | PH06 | NOT_RUN |
| MIG-QA-003 | workflow | No real commercial SDK in CORE001 | Core build uses fake/unavailable interfaces only;no external spend | PH01 | NOT_RUN |
| MIG-QA-004 | combat | Three melee slots and reserve turnover | No reserve damage;vacancies refill without teleport or immortal ranged queue | PH01 | NOT_RUN |
| MIG-QA-005 | combat | Two opposing high-speed approach | Proportional clamp prevents crossing with stable mirrored outcome | PH01 | NOT_RUN |
| MIG-QA-006 | combat | New projectile on release tick | Projectile begins travel next tick;no framerate-dependent extra distance | PH01 | NOT_RUN |
| MIG-QA-007 | combat | Hard limit tick ordering | 4200 due impacts resolve before HP-fraction comparison;spawn cutoff exact | PH01 | NOT_RUN |
| MIG-QA-008 | combat | Render speed deterministic | Same input stream at1/2/4/10x yields same model hash/outcome | PH03 | NOT_RUN |
| MIG-QA-009 | combat | Player command count at one tick | Only first accepted deploy spends;cooldown rejects remaining without queued spend | PH01 | NOT_RUN |
| MIG-QA-010 | combat | No paid/dynamic difficulty | Enemy queues unaffected by ownership,ads or prior losses | PH03 | NOT_RUN |
| MIG-QA-011 | save | Newer-schema file | Explain incompatibility;no silent reset or overwrite | PH04 | NOT_RUN |
| MIG-QA-012 | save | Process kill at each commit boundary | Active/backup recovery yields one atomic grant,not partial purchase/unlock | PH04 | NOT_RUN |
| MIG-QA-013 | save | Consent/settings reset retention | Local reset retains privacy/audio/accessibility and owned entitlements | PH04 | NOT_RUN |
| MIG-QA-014 | save | Pending backend receipt after reset | No paid ownership loss or fake campaign restore | PH05 | NOT_RUN |
| MIG-QA-015 | save | Unknown current-content snapshot on update | Preserve banked value;compatible resume or documented ended run | PH10 | NOT_RUN |
| MIG-QA-016 | privacy | No optional pre-consent network backlog | Actual traffic and export match disabled/accepted/withdrawn choices | PH05 | NOT_RUN |
| MIG-QA-017 | privacy | Unity IAP own telemetry | Developer Data/identifiers inventory verified,not ignored because no Unity Analytics package | PH05 | NOT_RUN |
| MIG-QA-018 | privacy | Support summary redaction | No purchase token,secret,full raw logs or unrelated user data | PH04 | NOT_RUN |
| MIG-QA-019 | billing | Backend already acknowledged Unity order | DuplicateTransaction confirmation does not revoke or double-grant verified ownership | PH05 | NOT_RUN |
| MIG-QA-020 | billing | Test track non-license account | Test protocol prevents accidental real charge;licence dialog/account evidence | PH05 | NOT_RUN |
| MIG-QA-021 | billing | Receipt key rotation old client | Old legitimate offline entitlement verified;new receipts use approved kid | PH05 | NOT_RUN |
| MIG-QA-022 | billing | Refund while offline | No fabricated immediate revocation;authoritative sync on reconnect | PH05 | NOT_RUN |
| MIG-QA-023 | billing | Identifier mismatch | Wrong package/product rejected before grant;developer ID cannot release | PH05 | NOT_RUN |
| MIG-QA-024 | ads | Late earned callback after view close | Grant correct originating run once or persist recoverable state;no cross-run reroll | PH05 | NOT_RUN |
| MIG-QA-025 | ads | Process killed without earned callback | No invented verified reward;interrupted attempt documented | PH05 | NOT_RUN |
| MIG-QA-026 | ads | First attempt skipped tutorial | Commercial offers still suppressed for entire first attempt | PH02 | NOT_RUN |
| MIG-QA-027 | analytics | 35 named events plus mapped activity sample | Bounded scalar transport,qualifying10s gameplay sample,exact normalized output | PH05 | NOT_RUN |
| MIG-QA-028 | analytics | Automatic purchase/impression dedup | One canonical revenue fact;test rows excluded | PH05 | NOT_RUN |
| MIG-QA-029 | analytics | Retention windows and maturity | Exact elapsedD1/D7/D30,unknown empty denominator,consent bias visible | PH05 | NOT_RUN |
| MIG-QA-030 | analytics | Overkill and barrier attribution | Effective HP excludes overkill;barrier and HP not double counted | PH03 | NOT_RUN |
| MIG-QA-031 | analytics | Unknown organic attribution | Unknown not relabeled Play organic;no false cross-channel funnel linkage | PH05 | NOT_RUN |
| MIG-QA-032 | capture | Raw versus generated target | Raw Unity capture retained with sidecar;paintover labeledreference | PH07 | NOT_RUN |
| MIG-QA-033 | capture | Mockup numerical errors excluded | RuntimeB001 values not4kHP/1kSupply/oldfakeprices orinventedstars | PH07 | NOT_RUN |
| MIG-QA-034 | capture | Aspect and safe-area preservation | No stretched native image;real rendered dimensions and controls documented | PH07 | NOT_RUN |
| MIG-QA-035 | presentation | Built-in renderer compatibility | No accidental URP2DLight/ShadowCaster dependency from paintover instructions | PH09 | NOT_RUN |
| MIG-QA-036 | presentation | Final art only replaces presentation | Identical commandstream modelresult before/after art replacement | PH09 | NOT_RUN |
| MIG-QA-037 | presentation | 48 units with all essential controls | Roles/frontline/HP/Supply/Rally readable;smoke/UI do not obscure input | PH09 | NOT_RUN |
| MIG-QA-038 | presentation | No font/licence omissions | Actual imported fonts/notices cleared;no embedded screenshot text for live UI | PH09 | NOT_RUN |
| MIG-QA-039 | audio | Focus/ad restore overlap | One loop;user volume retained;no permanently muted/doubled music | PH09 | NOT_RUN |
| MIG-QA-040 | audio | Ram despawn loop | Movement sound stops and pool resets;wheel motion tied to distance | PH09 | NOT_RUN |
| MIG-QA-041 | android | AVD native ABI mismatch | BLOCKED with exactlogs ratherthanclaimedPASS | PH01 | NOT_RUN |
| MIG-QA-042 | android | 16KB all native libs | Inspect every bundledSDK/IL2CPP library and actual environment | PH10 | NOT_RUN |
| MIG-QA-043 | android | Release debug removal | No devspeed/fixture/fake purchase entry points in release | PH10 | NOT_RUN |
| MIG-QA-044 | release | First production rollout | No fictitiouspercentagefirstlaunch;country and owner approval explicit | PH11 | NOT_RUN |
| MIG-QA-045 | release | Play-delivered artifact identity | Installedbundle sourcehead/AAB/versionmatchesapprovedrecord | PH10 | NOT_RUN |
| MIG-QA-046 | release | Closed human instructions | Uncoached comprehension observations,notfriendretentionclaim | PH10 | NOT_RUN |
| MIG-QA-047 | operations | Backup restore | Fresh source/build or datastore restoration tested,not only fileexists | PH10 | NOT_RUN |
| MIG-QA-048 | operations | Kill switch offline limit | Doesnotrevokeownedbenefits;offlineclientnotclaimedinstantlyupdated | PH05 | NOT_RUN |
| MIG-QA-049 | operations | Cloud budget alarms | Alerts not hardcaps or new spend authorization | PH05 | NOT_RUN |
| MIG-QA-050 | operations | Retirement selling status | New purchases disabled before withdrawingservice;localgamepreserved | PH11 | NOT_RUN |


## Screenshot pack

| ID | File | View | Required state | Status |
| --- | --- | --- | --- | --- |
| SC01 | SC01_home_new.png | Home/Campaign | new save;first expedition highlighted | NOT_CAPTURED |
| SC02 | SC02_home_progress.png | Home/Campaign | chapter2unlocked;earnedcurrency;resumeentry | NOT_CAPTURED |
| SC03 | SC03_army_starter.png | Army | fourstarterunits;BruteRamlocked | NOT_CAPTURED |
| SC04 | SC04_army_full.png | Army | allsixunlocked;fourselected;clearreplacementstate | NOT_CAPTURED |
| SC05 | SC05_battle_open.png | Battle | firstengagement;cleanHUD | NOT_CAPTURED |
| SC06 | SC06_battle_frontline.png | Battle | threeengagementslots/protectedranged visuallyreadable | NOT_CAPTURED |
| SC07 | SC07_battle_dense.png | Battle | 24vs24engineeringfixture,labelnotmarketproof | NOT_CAPTURED |
| SC08 | SC08_battle_grenade.png | Battle | grenadeimpactfiniteframe;UIunobscured | NOT_CAPTURED |
| SC09 | SC09_battle_crossbow.png | Battle | protectedfiringlineandprojectile | NOT_CAPTURED |
| SC10 | SC10_battle_ram.png | Battle | Ramcontactwithfortress | NOT_CAPTURED |
| SC11 | SC11_battle_rally.png | Battle | Rallyactiveandcooldownreadable | NOT_CAPTURED |
| SC12 | SC12_battle_barrier.png | Battle | first-hitShieldguardbarrier | NOT_CAPTURED |
| SC13 | SC13_battle_overtime.png | Battle | 150s+overtime,correctHP | NOT_CAPTURED |
| SC14 | SC14_battle_caps.png | Battle | unitcaporinsufficientSupplydisabledreasons | NOT_CAPTURED |
| SC15 | SC15_draft_normal.png | Draft | threeactualeligibleoptions | NOT_CAPTURED |
| SC16 | SC16_draft_reroll.png | Draft | freeused;extraoffereligibleorowned | NOT_CAPTURED |
| SC17 | SC17_result_win.png | Results | completeexpedition;banked/completion/firstclearbreakdown | NOT_CAPTURED |
| SC18 | SC18_result_loss.png | Results | partiallossretainwins;eligiblebonus | NOT_CAPTURED |
| SC19 | SC19_result_draw.png | Results | drawreasonnotwin | NOT_CAPTURED |
| SC20 | SC20_shop_available.png | Shop | twoexactproducts;testmetadata labeledifneeded | NOT_CAPTURED |
| SC21 | SC21_shop_owned.png | Shop | ownedbenefitsandfiniteMedalstate | NOT_CAPTURED |
| SC22 | SC22_settings.png | Settings | audio/haptics/reducedmotion/privacy/restore | NOT_CAPTURED |
| SC23 | SC23_pause.png | Pause | resume/abandonnohiddenaction | NOT_CAPTURED |
| SC24 | SC24_save_recovery.png | Save recovery | recoverableerror/newerschemalimitation | NOT_CAPTURED |
| SC25 | SC25_purchase_pending.png | Purchase pending | clearpendingstate,nogrant | NOT_CAPTURED |
| SC26 | SC26_privacy_options.png | Privacy | actualSDKorclearlymarkedplaceholderform | NOT_CAPTURED |
| SC27 | SC27_victory_field.png | Battle terminal | fortressdestructionandvictory | NOT_CAPTURED |
| SC28 | SC28_defeat_field.png | Battle terminal | lossandclearcontinuation | NOT_CAPTURED |


---

<!-- Source: bibles/21_COVERAGE_AND_PRIMARY_REFERENCES.md -->

# Bible21 — Coverage, Decisions and Primary References



This index maps the source to implementation and proof. It does not claim final lighting, real service setup, legal clearance or a Unity build has already occurred. Exact deployment inputs are intentionally stage-gated; no unresolved troop values are delegated back to the owner.



## Coverage matrix

| Area | Bible | Data/contracts | Phase | Required evidence |
| --- | --- | --- | --- | --- |
| Authority/latest decisions | 00 | SOURCE_AUTHORITY.json;records/DECISIONS.jsonl;records/SUPERSESSIONS.json | PH01 | Source integrity and no stale history authority |
| Product/scope/single player | 01 | data/game_rules.json | PH02 | Full campaign offline,excluded systems absent |
| Combat/timing/formation | 02 | data/game_rules.json;data/units.json | PH01 | Model tests and deterministic harness |
| Upgrades/draft/enemies/bosses | 03 | data/upgrades.json;data/encounters.json;data/boss_variants.json | PH03 | Everyoperator/queue and all15loadouts |
| Economy/monetization | 04 | data/economy.json;data/products.json | PH02 | Actualatomicrewardpaths;finitecatalogue |
| UI/allstatecopy | 05 | data/ui_contract.json;data/strings_en.json | PH04 | Screenstate/input/copycoverage |
| Saves/migrations | 06 | schemas/save_envelope.schema.json;contracts/state_machines.json | PH04 | Killpointrecoverytests |
| Architecture/interfaces | 07 | contracts/platform_interfaces.json | PH01 | Dependencydirectionandlifecycletests |
| Toolchain/AVD/native | 08 | data/toolchain_lock.json;data/test_matrix.json | PH01 | Actualbuild/native/environmentproof |
| Services/ads/purchases | 09 | data/service_contract.json;contracts/service_api.json | PH05 | Realtestservicesnotfakes |
| Analytics/metrics/queries | 10 | data/analytics_events.json;contracts/analytics_transport.json;reports/sql/ | PH05 | Knownjourneyexportandqueries |
| Visuals/lighting/screenshots | 11 | data/visual_references.json;data/screenshot_pack.json;contracts/presentation_contract.json | PH07 | Ownerselectedreal-layouttargets |
| Assets/animation/VFX | 12 | data/assets.json;data/animation_contract.json | PH08 | Finalproductionafterplaceholder |
| Music/SFX/haptics | 13 | data/audio_vfx_contract.json | PH09 | Ingameaudio/focus/listeningproof |
| QA/balance/evidence | 14 | data/qa_cases.json;tools/;tests/ | PH03 | Sourcevsruntimeevidenceseparation |
| Codex tasks/gates | 15 | data/tasks.json;data/build_gates.json;tasks/ | PH01 | Scopedevidenceandexact-headreview |
| Legal/privacy/rights | 16 | contracts/data_inventory.json;data/deployment_inputs.json | PH10 | ActualentitySDK/rightsreview |
| Playrelease/store | 17 | data/release_checklist.json | PH11 | Exactowner-approvedAAB/storeproof |
| Organic/business | 18 | reports/sql/;templates/PUBLIC_DOCUMENTS_WORKSHEET.md | PH11 | Truthfulcreativeandactualreceipts |
| Ops/support/recovery | 19 | templates/TASK_RESULT.md;data/release_checklist.json | PH11 | Recovery/incident/retirementdrills |


## Source history and supersession

| ID | Prior direction | Current authority | Reason |
| --- | --- | --- | --- |
| C01 | Final animation/asset proof before first code | PH01–PH06 placeholders;externalproductionPH08 | Latest owner WF002 |
| C02 | One single expedition called entire game | CORE001foundation;CORE002all9/36;PH06entireplaceholder | Fullplaceholder scope |
| C03 | Images showed4000HP/1000Supply/differentprices | UseB001900playerHP/200Supply/20,45,50,65startercosts | Imagesstyleonly |
| C04 | Reactive counter-buy AI example | Finite exact queues inencounters.json | B001 |
| C05 | $7.99 Ad-free proposal | $4.99 initially;$2.99cosmetic | B001 |
| C06 | Old barrier expires while walking | 8stimerfirstpositivepostmitigationdamage | B001 |
| C07 | All SDK imports in first build | PH01coreonly;PH05commercialSDKs | Latest CORE001 |
| C08 | Selected visual means exactlighting/shadowsapproved | V001styleapproved,P001exactcapture-derivedlater | Latest owner/direction |
| C09 | 100%pixelperfectgeneration promise | Paintoverreference requiresgeometry/textcomparison | Honestproductioncontract |
| C10 | Every lock means validatedgame/compliance | Selecteddesign!=Unitybuild!=playtest!=legalrelease | Evidence separation |
| C11 | 18+chosen for policyavoidance | Actualaudience must honestlymatchart/marketing;IARCseparate | Legal closure |
| C12 | Analytics generic eventexamples replacecatalogue | 35canonicalexistingevents;explicittransportmapping | A001 |
| C13 | No backend because singleplayer | No gameplaybackend;minimalpurchaseverificationonly | Singleplayerservicesboundary |
| C14 | First production5% rollout | Firstcountryrelease;percentageforupdateswhereavailable | Play process |
| C15 | Allclosurepercentages quantifiedcompletion | No percentage claims;file/evidence statesonly | Audit honesty |
| C16 | Missing finaltitle blocks prototype | Developmentonlycom.example.onelanewar.dev;realIDrequiredPH05 | Stage specific inputs |
| C17 | MockUI extra stars/units/orders are gamefeatures | Noextras;functionalstatesandB001authority | Scope law |


## External references

The links support platform/provider facts only. Original mechanics, thresholds and scope are project decisions. Checked/retrieved references are dated; retained prior primary pointers are explicitly marked. Recheck changing rules at the relevant phase, particularly before store submission. These sources do not validate this game.

| ID | Primary source | Supports | Review status |
| --- | --- | --- | --- |
| EXT01 | [Unity editor release](https://unity.com/releases/editor/whats-new/6000.3.21f1) | Selected editor and changeset | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT02 | [Unity Android dependencies](https://docs.unity3d.com/6000.3/Documentation/Manual/android-supported-dependency-versions.html) | Editor-range NDK/JDK/SDK compatibility | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT03 | [Unity Gradle compatibility](https://docs.unity3d.com/6000.3/Documentation/Manual/android-gradle-version-compatibility.html) | 6000.3.17–.25 mapsGradle9.1/AGP9.0 | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT04 | [Firebase Unity release notes](https://firebase.google.com/support/release-notes/unity) | 13.17 and native dependencies | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT05 | [Unity IAP changelog](https://docs.unity3d.com/Packages/com.unity.purchasing@5.4/changelog/CHANGELOG.html) | 5.4.3 and acknowledged-order/telemetry behavior | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT06 | [Google Mobile Ads Unity release](https://github.com/googleads/googleads-mobile-unity/releases/tag/v11.5.0) | Selected ads release | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT07 | [Google Mobile Ads native dependencies](https://raw.githubusercontent.com/googleads/googleads-mobile-unity/v11.5.0/source/plugin/Assets/GoogleMobileAds/Editor/GoogleMobileAdsDependencies.xml) | SelectednativeGMAdependencies | RETAINED_V0_2_PRIMARY_REFERENCE_RECHECK_AT_PHASE; 2026-09-27 |
| EXT08 | [Android Studio updates](https://developer.android.com/latest-updates) | Studio release selection | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT09 | [Android emulator releases](https://developer.android.com/studio/releases/emulator) | Emulator selection and particular ARMtranslationimages | RETAINED_V0_2_PRIMARY_REFERENCE_RECHECK_AT_PHASE; 2026-09-27 |
| EXT10 | [Unity x86_64 target restriction](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/AndroidArchitecture.X86_64.html) | Do notassumenewphoneappx86target | RETAINED_V0_2_PRIMARY_REFERENCE_RECHECK_AT_PHASE; 2026-09-27 |
| EXT11 | [Android page sizes](https://developer.android.com/guide/practices/page-sizes) | 16KBnativecompatibility | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT12 | [Play Billing testing](https://developer.android.com/google/play/billing/test) | Licence-testvsrealcharges,pendingrestoretest | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT13 | [Billing security](https://developer.android.com/google/play/billing/security) | Backendverificationandacknowledgement | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT14 | [Rewarded ads policy](https://support.google.com/admob/answer/7313578?hl=en) | Disclosure,optin,earnedreward | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT15 | [Unity UMP privacy](https://developers.google.com/admob/unity/privacy) | Consentreadiness/options | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT16 | [AdMob impression revenue](https://developers.google.com/admob/unity/impression-level-ad-revenue) | Valuecurrencyandprecision | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT17 | [Play target API](https://support.google.com/googleplay/android-developer/answer/11926878?hl=en) | NewphoneappsupdatesAPI36checked2026-09-27 | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT18 | [Target audience/content](https://support.google.com/googleplay/android-developer/answer/9867159?hl=en) | Actualaudiencepresentationmustmatchdeclaration | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT19 | [Data Safety](https://support.google.com/googleplay/android-developer/answer/10787469) | SDKdatainventoryanddeclarations | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT20 | [Firebase BigQuery export](https://firebase.google.com/docs/projects/bigquery-export) | Exportsetupanddatahandling | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT21 | [Crashlytics Unity setup](https://firebase.google.com/docs/crashlytics/unity/get-started) | UnityIL2CPPsymbols | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT22 | [Developer identity](https://support.google.com/googleplay/android-developer/answer/13628312?hl=en) | Organization/contactverification | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT23 | [Personal account test requirements](https://support.google.com/googleplay/android-developer/answer/14151465?hl=en) | Qualifyingpersonalaccounttestprerequisite | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT24 | [Prepare and roll out release](https://support.google.com/googleplay/android-developer/answer/9859348?hl=en) | Firstreleaseversusupdatestaging | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT25 | [AdMob app readiness](https://support.google.com/admob/answer/14538460?hl=en) | appadsverification/readiness | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT26 | [Cloud budget alerts](https://cloud.google.com/billing/docs/how-to/budgets) | Alertsarenotuniversalautomaticspendcap | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT27 | [Billing deprecation](https://developer.android.com/google/play/billing/deprecation-faq) | SupportedBillingversionsbeforefuturesubmission | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT28 | [Firebase Analytics Unity](https://firebase.google.com/docs/analytics/unity/get-started) | SDKsetup | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT29 | [Codex AGENTS guide](https://developers.openai.com/codex/guides/agents-md) | Repositoryinstructionfilebehavior | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT30 | [Unity Editor terms](https://unity.com/legal/editor-terms-of-service/software) | Actualentitylicenceeligibility | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT31 | [Higgsfield terms](https://higgsfield.ai/terms-of-use-agreement) | Actualoutputcommercialrightsandrestrictions | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT32 | [Suno paid commercial guidance](https://help.suno.com/en/articles/9601665) | Actualpaidoutputcommercialpermissions | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |
| EXT33 | [ElevenLabs SFX terms](https://elevenlabs.io/sound-effects-terms) | Actualoutputpermissionsandterms | OPENED_PRIMARY_SOURCE_DURING_CONSOLIDATION; 2026-09-27 |


## Final proof boundary

The source and reference tools can be verified in this container. Unity/Android executable behavior, full combat outcomes, actual purchased/ad-delivered entitlements, final art/audio, legal publishing declarations and human retention require their own later evidence. All supplied runtime QA cases remain NOT_RUN. Prior source archives preserve history; they are not instructions to restore the old asset-first process.
