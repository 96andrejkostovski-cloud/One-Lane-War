# OLW-AMEND-004 — Astra task batching without gate removal

**Status:** ACTIVE DIRECTOR WORKFLOW DECISION FOR FUTURE ISSUED GOALS,
2026-09-27. Creating this amendment does not issue or start a build Goal.

**Base:** OLW-SOURCE-1.0.0 and OLW-AMEND-001 through OLW-AMEND-003.
**Owner direction:** Build the complete game with GPT-6 Astra High using
as few practical prompts as quality permits.

The existing twelve task packets remain the scope and acceptance
checklists. WF002 PH01–PH11 order and all owner approval boundaries
remain in force. To reduce repeated handoffs, an explicitly issued
Astra Goal may contain these sequential task packets:

| Goal | Included packets | Required sequence |
|---|---|---|
| 01 | OLW-CORE-001 | PH01 |
| 02 | OLW-CORE-002, 003, 004 | PH02 → PH03 → PH04 |
| 03 | OLW-INT-001, OLW-CAP-001 | PH05 → PH06 |
| Director gate | OLW-PRES-001 | PH07, owner-selected P001 |
| 04 | OLW-ART-001, OLW-PRES-002 | PH08 → PH09 |
| 05 | OLW-REL-001 | PH10 |
| 06 | OLW-REL-002 | PH11, after exact owner publication approval |
| Later operation | OLW-OPS-001 | Specific authorized operation only |

Within a multi-packet Goal, the individual packet's instruction to
stop before the next packet is replaced by this rule: finish its
acceptance evidence, commit and review that exact head, then proceed
to the next packet only when its dependencies are actually satisfied
and no Director or owner decision is pending. Keep a separate
`ImplementationEvidence/<task>/TASK_RESULT.md` for each packet. Do not
mark a phase PASS solely because the same prompt covered it. An
issued multi-packet Goal may use one scoped Goal branch with distinct
commits and evidence at each task boundary. This replaces the source's
per-task branch preference only for that Goal; the exact-head review
requirement remains. An unresolved failure, absent toolchain, required B002/T002 decision,
service credential/spend authorization, P001 selection, or publication
approval still stops dependent work. Continue independent in-scope
work where possible and report exact blockers.

Each Goal has one clearly defined finish line in
`Documentation/Director/ASTRA_BUILD_PLAN.md`. Issuing Goal 01 does not
authorize Goal 02 or later work. The Director reviews each completed
Goal's exact source, tests, build, captures and outstanding findings
before issuing the next. The owner retains final visual, substantial
spend, service activation, signing, legal identity and publication
decisions. This amendment neither creates credentials nor authorizes
provider calls, public deployment, purchases or Google Play release.

This batching decision changes prompt/stop choreography only. It does
not alter B001 numbers, T001 pins, game scope, source-package bytes,
or runtime QA standards.
