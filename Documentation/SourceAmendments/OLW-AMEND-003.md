# OLW-AMEND-003 — Designated GitHub repository

**Status:** ACTIVE OWNER DIRECTION, 2026-09-27
**Base source:** OLW-SOURCE-1.0.0 plus OLW-AMEND-001 and OLW-AMEND-002.
**Scope:** Remote repository identity and bounded Git handoff only.

The owner supplied this existing GitHub repository for One Lane War:

`https://github.com/96andrejkostovski-cloud/One-Lane-War.git`

This is the only designated remote for the main local project root
`C:\Users\Andrej\Downloads\One Lane War`. Do not clone it to create
another authoritative working project. Do not create a replacement
repository. Use `origin` for this URL after confirming the exact owner,
repository, authenticated write access, visibility, default branch,
protection rules, and current refs. The owner described it as blank;
that state was not independently verifiable during Director intake
because GitHub access from this session failed. Treat emptiness as a
condition to check, not an established fact.

For OLW-CORE-001, local Git initialization and a normal push of the
verified initial baseline and scoped implementation branch to this
repository are authorized after source/package and changed-file review.
Never force-push, overwrite an existing history, publish secrets or
private keys, change repository settings, merge a PR, or push to another
remote. If the remote is not empty or its identity/visibility cannot be
confirmed, stop the remote step and report the exact state while
preserving local work. A later PR and merge remain separate review gates.

This amendment changes no gameplay, balance, T001 pin, Unity path,
WF002 gate, or source-package bytes.
