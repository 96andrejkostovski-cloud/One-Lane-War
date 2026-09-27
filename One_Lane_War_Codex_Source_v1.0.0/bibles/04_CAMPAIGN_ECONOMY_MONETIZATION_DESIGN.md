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
