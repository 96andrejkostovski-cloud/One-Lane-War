# Bible 14 — QA, Balance and Evidence

**Authority:** QA001 consolidated registry and B001. The supplied source/math tools can run now. Unity, Android, SDK, device and human-play checks remain NOT_RUN until Codex produces the corresponding evidence.

## 14.1 Evidence classes

Keep five separate categories: source structural validity, arithmetic/reference validity, executable game correctness, presentation/device correctness, and human/commercial outcomes. A JSON parse is not combat validation. A thousand bots are not a thousand players. A generated picture is not a runtime screenshot. A test that uses a fake ad is not AdMob integration. This package may be source-verified while every game gate remains unexecuted.

`data/qa_cases.json` contains inherited 93 cases, the 12 B001 amendments, and additional migration/workflow/release edge cases. Every case has an ID, category, procedure/expected result or inherited acceptance description, assigned phase and evidence status. Store actual execution in a separate run report with tested commit, command, environment, result, log and artifact links. Never overwrite NOT_RUN with PASS merely because a task says to test it.

## 14.2 Source tests

Run `tools/verify_source.py` to check manifest integrity, JSON structure, IDs/references, source preservation, counts, authority, workflow ordering and required paths. Run `python -m unittest discover -s tests -v` for independent numerical fixtures and transport examples. Run `tools/audit_balance.py` for upgrade arithmetic and funding/economy analysis; it is explicitly not a battle simulator.

The 15 four-unit loadouts each have 18 eligible upgrade definitions initially. Enumerating four selections gives 15 × C(18,4) = 45,900 arithmetic configurations, irrespective of draft-path guarantees. This is an upper-envelope arithmetic audit, not a claim each configuration occurs with equal probability or that it wins any encounter. Distinguish the eligible combination set from reachable draft paths. The tests must not report a reduction formula's output as measured damage delivered through congestion and travel.

## 14.3 Executable model fixtures

Required deterministic scenarios include empty lane, equal melee contact, three-slot engagement turnover, ranged-only armies, melee passing friendly ranged, two opposing fast units approaching, off-front reserve unable to attack, base defense blocking, same-tick death impacts, shooter death after release, swept projectile intersection, grenade target moving away, no friendly splash, secondary hits excluding base, barrier first-hit/timer/absorption and every cost/rate rounding boundary.

For each create minimal input snapshots, tick-stamped commands, expected assertions and seed where relevant. Re-run the same command stream under 30/60 FPS presentation, 1×/2×/4×/10× debug scheduling and headless batch. The authoritative outcome/state hash must match. Accelerated scheduling never changes time-step size. Debug tools may step one tick and inspect targets/slots; they cannot become a player-visible speed-up or sandbox mode.

Every upgrade has unit and interaction tests. Apply selected modifiers to eligible troops only, preserve base/troop distinction and avoid recursive bonus spawning or damage. Test Conscription at cap, lost melee target during windup, three-hit Ram counter per individual Ram, pierce two-target identity, Rally beginning/ending on attack boundaries, oath-style barrier only once and upgrade exclusion after selection. No hot-loop implementation may use dictionary iteration order as a combat rule.

## 14.4 Full balance harness

Once the Unity-independent C# combat assembly exists, use that exact assembly in the batch runner. Exercise all 36 encounters with all 15 loadouts where access restrictions are intentionally bypassed only for analysis. Separately test normal campaign-unlock routes without bypasses. Player-policy families are cheapest spam, costliest spam, role-protected ranged, mixed formation, hoard-then-push, Ram push, ranged-heavy and varying Rally timing. Policies must actually obey costs, caps, global cooldown and visibility rules.

Record encounter, army, upgrade path, seed, policy, source/balance version, result, duration, base fractions, effective/base/barrier damage, Supply spent/wasted, deployment counts, frontline occupancy, stalled time, overtime/cutoff outcomes and performance cost. Include equal-budget isolated matchups and full runs; do not compare units on nominal DPS alone.

Review high-level failure modes: universal dominant strategy, deployment inactivity, high fraction of timeout-fraction wins rather than fortress breakthroughs, mandatory ad/paid reroll for campaign viability, inaccessible upgrades, sudden chapter spike, protected ranged never reachable, siege becoming worse than ordinary ranged in every relevant context, and population limits invalidating intended swarm play. A strong build can be desirable; near-universal dominance that removes decisions is not.

Numerical corrections require B002 with exact changed fields, reasoning, before/after evidence and regression. Do not ask the owner to choose HP or quietly patch B001. Do not promise all 15 armies win all battles: roster constraints and player strategy may legitimately matter. Require at least one demonstrated no-ad/no-purchase full campaign policy and human comprehension of alternatives.

## 14.5 Stateful and failure testing

Test first launch, skip tutorial, replay, later failure preserving previous rewards, draw, explicit abandon, Home/resume, process kill in battle, process kill during draft generation/selection, duplicate result callback, low storage, corrupt latest save, valid backup, both invalid, unknown newer schema and migrations. A pause menu, service overlay and background focus can overlap; removing one must not resume another.

Test transaction boundaries by injecting failure before write, after temporary file flush, before atomic replacement, after replacement but before UI success, and during backup rotation. Verify recovery without double-spending or duplicate banked Medals. A reset retains ownership/privacy/accessibility settings as specified. A reset must not refund money, imply cloud deletion or corrupt a pending verification.

Commercial tests cover all documented ad and purchase states using fakes first and genuine test flows later. A known lost verified purchase, destructive save defect, duplicate charge path, security breach, inaccessible primary control or unresolved required declaration blocks release regardless of average pass rate.

## 14.6 Device and presentation testing

AVD rows record actual ABI loading and system-image details. Unsupported rows remain blocked. Real phone coverage includes installed-through-Play build, cold/warm launch, input, safe areas, both landscape orientations, 20-minute soak, frame-time/memory, audio focus, haptics, consent and ad/store returns. Font/display scaling and tablet-like views must not lose controls. Do not claim every Android device supported based on a single emulator.

After final art, repeat all relevant tests. Atlas size, alpha overdraw, shader compatibility, animation pivots, audio streaming, effect pools, glyph coverage and screenshots can regress even when the model is unchanged. Art replacement is not just copying files and skipping release QA.

## 14.7 Human validation and severity

Closed testers must include people who did not design the game. Observe whether they understand deployment, protection, draft effects and Rally; finish an expedition; choose another army; and voluntarily replay. Do not coach every decision then count success as intuitive onboarding. Collect actionable confusion/abandonment notes with consent. Formal retention targets require mature unbiased-enough cohorts; a few friends are usability evidence, not monetization proof.

P0 includes systemic lost paid ownership, destructive saves or security exposure. P1 includes widespread failure to start, crashes/ANRs or systematic earned-reward loss. P2 covers important bounded balance/UI/isolated defect clusters. P3 is minor polish. Severity relates to user impact, not an arbitrary code-review label. Preserve exact-head review and evidence; avoid days of unrelated refactors while critical work waits.

## 14.8 Release decision

No known critical corruption/payment/security defect, unresolved mandatory policy issue or fake final asset can pass. Minor issues require an explicit accepted-risk record with owner/director disposition. Release evidence cites the exact AAB hash and tested commit; any subsequent code/content change invalidates only the affected evidence through a documented regression map, never silently reuses an old all-green label. A source-validation PASS in this package grants none of these runtime approvals.
