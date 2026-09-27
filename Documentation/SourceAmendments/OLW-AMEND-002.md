# OLW-AMEND-002 — Source navigation and Windows verifier correction

**Status:** ACTIVE DIRECTOR TECHNICAL CORRECTION, 2026-09-27
**Base source:** OLW-SOURCE-1.0.0 plus OLW-AMEND-001.
**Scope:** Source-reading and validation tooling only. No game, balance,
toolchain pin, phase, or acceptance value changes.

## Decision log path

Bible 00 section “Authority hierarchy” refers to
`records/DECISION_LOG.jsonl`. The sealed package contains
`records/DECISIONS.jsonl`, which is also referenced by its coverage
matrix. Read the existing `records/DECISIONS.jsonl`. Do not create a
second decision log or infer a missing decision history.

## Source verifier on Windows

The package's `tools/verify_source.py` builds filesystem-relative paths
with Windows `\` separators, then compares them directly with manifest
paths using `/`. On this Windows host, with UTF-8 mode enabled, its only
failed check was `manifest complete source coverage` (1135/1136 passed).
The 147 listed manifest files had 147 exact path matches after separator
normalization and 147 matching byte sizes and SHA-256 hashes. The source
package itself remains sealed and unedited.

For the first task, run the package verifier with UTF-8 mode and preserve
its actual result. Add a small, reviewed, root-level validation helper
that normalizes path separators and checks full manifest coverage and
every sealed hash, then run it. Do not describe the original verifier as
PASS until its defect is corrected in a numbered future source release.
`python tools/verify_source.py --no-manifest` can additionally check the
other semantic invariants, with its reduced scope labeled explicitly.
Source validity remains separate from Unity/runtime proof.
