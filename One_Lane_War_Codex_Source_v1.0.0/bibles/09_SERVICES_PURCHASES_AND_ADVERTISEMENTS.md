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
