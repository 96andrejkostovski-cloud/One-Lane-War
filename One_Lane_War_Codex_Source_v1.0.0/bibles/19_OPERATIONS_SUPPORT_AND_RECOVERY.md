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
