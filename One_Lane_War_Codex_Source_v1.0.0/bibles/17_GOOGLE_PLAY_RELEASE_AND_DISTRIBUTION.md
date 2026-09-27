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
