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
