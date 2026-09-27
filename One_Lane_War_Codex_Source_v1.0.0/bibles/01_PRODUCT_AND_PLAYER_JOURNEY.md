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
