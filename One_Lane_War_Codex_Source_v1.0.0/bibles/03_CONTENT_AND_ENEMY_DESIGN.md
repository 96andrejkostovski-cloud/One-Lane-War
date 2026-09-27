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
