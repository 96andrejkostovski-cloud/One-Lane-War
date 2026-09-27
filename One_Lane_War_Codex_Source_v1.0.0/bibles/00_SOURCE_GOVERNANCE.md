# 00 — Source governance and migration Bible

**Authority:** OLW-SOURCE-1.0.0. **Assembled:** 27 September 2026. **Scope:** One Lane War only. **Runtime status:** not implemented in this package.

## Purpose

This is the complete consolidated implementation source for a deliberately small Android single-player strategy game. It turns the selected design and later corrections into one operating package for Codex. It is not a slide pitch, another brainstorming document, a Unity project, or evidence that the game is already built.

The owner delegates gameplay numbers, engineering design, toolchain selection and implementation planning to the Game Director. The owner retains final visual selection, external expenditure, account and legal identity, credentials, publication and expansion approvals. Codex implements the current task, tests it, reports defects, and preserves evidence; it does not silently change the product.

## Latest decisions take effect here

The latest workflow is **placeholder-first, entire game before final asset generation**. The previous sequence that required final visual/animation assets before the game is superseded. Build all content and functional screens with simple shapes. Integrate commercial services using controlled test accounts and no public sales. Reach the complete placeholder acceptance gate. Capture the actual game. Generate final-look targets from those captures. The owner chooses, then production art/music/SFX are generated, integrated, polished and regression-tested.

Single-player means local player versus deterministic enemy queues. There is no multiplayer, asynchronous opponent, co-op, account, leaderboard, network simulation, cloud progression or shared economy. The purchase service is not a game server.

V001 is an approved **style**, not an approved set of numeric values or a shipped screenshot. B001 remains the first-build numerical source. T001 is a selected toolchain, not a completed build proof. Source assembly does not grant permission to spend, deploy public services, publish, or mass-generate assets.

## Authority hierarchy

1. This package's explicit owner decisions and numbered scoped amendments, recorded in `records/DECISION_LOG.jsonl`.
2. Machine-readable current contracts in `data/`, their schemas, and `SOURCE_AUTHORITY.json`.
3. The numbered Bibles, which explain behavior and implementation requirements.
4. Task packets, which authorize a bounded subset of that source when the owner issues the task.
5. Approved visual references, for style only and never for rules, rewards, prices or text.
6. Historical packages and rejected examples: provenance only, never a second live source.

If current prose and current data disagree, report both paths and fields. The applicable current registry supplies numeric facts, but a genuine behavior contradiction is not permission to invent a rule. Record a narrow amendment; preserve unaffected records. A typo fix is not a reason to rebalance. A performance optimization must not change the replay result.

## Status vocabulary

`LOCKED_DESIGN` means selected instructions. `NOT_RUN` means a required test has not executed. `PASS` requires actual evidence for the exact tested source/build. `BLOCKED` identifies an external dependency or unsupported test environment. `DEFERRED_BY_WORKFLOW` is deliberate later work, not a forgotten field. `STYLE_APPROVED` does not mean production asset approval. `PRODUCTION_APPROVED` requires the actual final binary, metadata, rights and visual review.

Do not use closure percentages such as “98% finished.” The useful state is the named task, concrete outputs, unresolved defects and evidence. Earlier percentage estimates are not carried forward as measurements.

## What is preserved

The six troop records, 24 upgrades, 36 encounter queues, nine expeditions, two boss variants, Medal economy, two products, 35 custom events, 184 English strings and 148 planned asset families are inherited from the actual v0.2.0 package. Selected B001 registry files are retained byte-for-byte; their hashes are in `records/SOURCE_INPUTS.json`. Later additions specify workflow, capture contracts, test criteria, production and operational boundaries without increasing gameplay scope.

The v0.1.0 and v0.2.0 ZIPs are retained under `references/history/`. Do not extract either into a live runtime-content directory. The current Bibles and data are self-contained; the game must not depend on access to old ChatGPT conversations, memory, signed file URLs or another game's repository.

## Ownership and change control

Use a dedicated project. Do not modify Roman Legacy, Bad Boots Good Loot, Reactorfall, their asset registries or their source locks. Generic tooling may be reused only after a dependency/licence review; no cross-game content inheritance is assumed.

Every task records source package ID, source manifest hash, task ID, branch, starting HEAD, ending HEAD, configuration versions and outputs. Prefer branch `task/<TASK-ID>-<description>`, PR `[<TASK-ID>] <description>`, and descriptive commits containing the task ID. Those are local conventions, not instructions to create a remote repository without authorization.

Changes to gameplay values require a B002+ amendment and new balance evidence. Tool changes require T002+. Event meanings change through A002+. Save migrations change S1 to S2. Approved visual production changes create a new presentation revision without changing B001. Source revisions are cumulative: never leave multiple “current” source packs in the task prompt.

## Exact-head review

Review the actual final commit. A review on commit A does not approve B. After corrections, rerun affected tests, source validation and the review required by the task. Native Codex review is used when available; record its exact head and result. If unavailable, record that limitation and perform a clearly labeled alternative review rather than pretending a native check ran.

Technical correctness, gameplay quality, final visual quality, licence clearance and publication approval are different gates. One cannot substitute for another. A test count without command, environment and result logs is not sufficient evidence.

## Migration procedure

Extract this package into the chosen new local project directory. Keep `AGENTS.md`, `START_CODEX.md`, `SOURCE_AUTHORITY.json`, `data/`, `bibles/`, `tasks/` and `tools/` together. Read `START_HERE.md`, then run `python tools/verify_source.py` and the reference tests. These commands inspect source; they do not generate game assets, install Unity, deploy services or make purchases.

The first executable task is `OLW-CORE-001`. Issuing its prompt authorizes only its stated local implementation. It does not authorize automatic execution of every later task. The one-shot attempt records the owner's chosen model/reasoning setting and actual results without pretending one response can bypass build verification.

## Evidence boundaries

This handoff can verify files, links, identifiers, numeric arithmetic, queue funding and reference utilities. It cannot report Unity, Android, live billing, ad delivery, physical performance or human retention as passed because none ran here. The included game QA register therefore starts `NOT_RUN` throughout. External release inputs are recorded with owners and blocking stages rather than invented values.

The safe stopping condition is precise: complete the current authorized task and its evidence, or report the reproducible blocker. Do not end a task after scaffolding while describing it as a finished game; do not continue into unapproved production after a task passes.
