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
