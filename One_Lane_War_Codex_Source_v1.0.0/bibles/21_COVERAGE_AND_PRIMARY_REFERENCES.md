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
