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
