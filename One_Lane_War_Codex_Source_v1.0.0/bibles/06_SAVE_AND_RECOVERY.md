# 06 — Local state, saving and recovery Bible

## Storage promise

The whole campaign, army choices, Medals, unlocks, draft state and settings are local. No player account, cloud sync, server save or cross-device progression exists. Uninstalling, clearing app storage or changing device can lose campaign progress. Play purchases are separately restorable through verified ownership. A backup in the same app sandbox protects some corruption cases, not uninstall or device loss.

The source chooses schema S1, a UTF-8 JSON envelope with an explicitly hashed payload, active file, temporary write file and last-known-good backup. PlayerPrefs may hold noncritical preferences but is not authoritative campaign storage. Android backup/device-transfer exclusions must match this local-only promise and exclude entitlement material.

## Required logical payload

Persist schema, revision, content/balance version, settings, privacy choice, wallet, owned troop IDs, owned banner IDs, selected cosmetics, cleared expedition IDs, tutorial flags, preferred loadout, active run, last unsettled result/claim, settled grant identities and cached signed entitlements. Store only data, never serialized Unity scene objects or provider callbacks.

An active run includes run ID, expedition ID, four troop IDs, selected upgrades, battle index, phase, initial seed, PRNG state, current three offers, offer ordinal, free/additional-reroll allowance state, banked battle-win total, completed battle IDs and prebattle checkpoint. Content hash is pinned for the run. The prebattle state contains what is needed to start the same authored battle; it is not a frame-by-frame snapshot of actors.

`templates/SAVE_S1_EXAMPLE.json` is a synthetic schema fixture, not a real player's save or entitlement. Runtime must validate every content reference, wallet bound, uniqueness constraint and phase relationship before accepting a payload. Reject unsupported newer schema non-destructively.

## Encoding and integrity

Use an envelope containing schema, payload JSON as an exact UTF-8 string, and SHA-256 over that string's exact UTF-8 bytes. The payload string removes cross-language ambiguity about property-order canonicalization of a parsed object. When writing, serialize payload once, hash those bytes, then embed it safely in the envelope. A new schema may choose another encoding through an explicit migration.

The checksum detects corruption, not local cheating or purchase ownership. An attacker can edit both payload and checksum; this is acceptable for offline Medals. Purchased benefits are enabled only by valid signed server receipts, never a boolean plus checksum.

## Atomic write protocol

Build the entire new payload in memory, validate it, serialize/hash, write to a temporary sibling, flush as supported and read back to verify. Preserve the last valid active copy as backup, replace active using the platform's safe file operation, and verify the resulting active envelope. Never erase the only valid copy first.

A process kill between any two file steps must leave at least one recoverable valid state. Tests simulate every interruption, low disk space, permission failure and corrupted active/backup combinations. Ignore or quarantine a partial temp file unless it is explicitly validated and newer by the defined revision policy. Keep recoverable corrupt files only for local diagnosis; do not upload them by default.

On save failure, retain the last valid state and show the affected transaction as not completed. Block only conflicting further mutations until recovery, not unrelated offline navigation. Do not continue accepting wallet spends into unpersisted memory and hope that quitting saves them later.

## Idempotent reward transactions

Use deterministic grant keys, for example run ID plus battle index and reward type, and a separate expedition-first-clear identity. Bank the battle result, wallet delta, completed-battle marker and next phase in one revision. Duplicate callbacks, repeated Results entry and process restart reapply no settled grant.

Completion/first-clear/campaign advancement form one atomic transaction. Reroll allowance and new RNG state/offers form another. Unlock spend and ownership are another. An entitlement refresh and local signed-receipt journal are another. Do not split an operation across independent PlayerPrefs and JSON files.

Keep active-run grant identities until no interrupted callback can legitimately refer to the run. Retain enough settled results for recovery without unbounded logs; prune only fully settled old run records at safe Home checkpoints. First-clear IDs remain permanently because they constrain rewards. Retain the most recent32 fully settled closed-run summaries; prune only at a safe Home commit. Never prune permanent first-clear identities or unresolved earned receipts. The1MiB envelope limit and nonnegative signed64-bit wallet limit are in `contracts/save_constraints.json`; reject overflow before commit rather than wrapping.

## State transitions and recovery

A saved phase is explicit: Home/NoRun, DraftPending, BattleReady, BattleActiveWithPrebattleCheckpoint, RewardCommitting, NextDraftReady or ExpeditionResult. The source state graph prevents illegal transitions such as a fifth draft, a battle without its preceding upgrade or starting a new run while the old one has an uncommitted reward.

When a battle is active at process termination, restore its saved prebattle state and start that same encounter on Resume. Do not carry partial damage, elapsed time, current Supply or newly spawned actors. Previously banked rewards and previously chosen upgrades remain. A player can replay a battle's execution by restarting, but cannot reroll the draft or multiply a reward; anti-restart punishment is not added.

A draft reload restores offers and allowances exactly. A won battle whose reward was committed before a kill resumes after the win. A reward whose commit did not complete resumes from the last valid revision with no fabricated wallet change. A normal lose/draw result preserves earlier grants. Abandon preserves banked rewards and removes the active run after confirmation.

## Settings, reset and backup

Settings apply immediately to the current presentation and persist separately within the same envelope. Reset removes wallet, earned unlocks, campaign and run data, but retains purchased entitlements, privacy choice and accessibility/audio settings. Reset never requests a refund. Show two clear confirmations and the distinction from Restore Purchases.

Restore Purchases queries actual Play ownership online and verifies returned tokens. It does not claim to reconstruct the player's Medals or cleared campaign. A failed network request retains last verified ownership. A known authoritative revocation updates benefits at the next safe boundary; no retroactive Medal debt or deleted campaign is imposed.

No time-based currency, daily reward or offline income exists, so no anti-clock-cheat subsystem is required. Server signed receipt timestamps are for security/diagnostics, not advancing gameplay. Offline entitlement continuity and refund-recognition limitations are documented in the services Bible.

## Updates and migration

Every public save schema is retained as a fixture for future updates. Migrations are deterministic, reversible through backup where possible, and preserve earned value. An active run pins its old content version. Ship compatible data or safely end only that incompatible run while preserving banked rewards and explaining the interruption. Never reinterpret an old unit ID as a different unit silently.

Test previous public build → next build, interrupted migration, downgrade attempt with newer schema, old cached entitlement keys, privacy-state migration and restored ownership. A new app version does not automatically require a save-schema increment. A balance version change does not permit wiping progression.

## Acceptance

Pass requires recovery from deliberate active-file corruption; no loss/duplication at each transactional kill point; no grant on pending purchases; no consumption of rerolls on cancelled ads; same draft after restart; first-clear once; reset preserving verified purchases; non-destructive newer-schema handling; and working offline boot. The included source checks validate synthetic examples only. Real filesystem and Unity lifecycle tests remain implementation work.
