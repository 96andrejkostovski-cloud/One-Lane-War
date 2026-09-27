# Source handoff validation — v1.0.0

**Scope:** source files, original-input preservation, reference arithmetic, schemas and the HTML reader. **Not tested:** Unity runtime, Android build/installation, actual battles, purchases, advertisements, consent traffic, physical-device performance, human retention, legal compliance or commercial results.

## Executed checks

| Check | Actual result | Evidence |
|---|---|---|
| Portable Python reference unit suite | 35 tests passed | `REFERENCE_TESTS.txt` |
| Formal Draft 2020-12 JSON Schema validation | 29 input/schema pairs passed | `SCHEMA_VALIDATION.json` |
| Four-upgrade arithmetic configurations | 45,900 checked; no arithmetic violations | `BALANCE_ARITHMETIC.json` |
| Unit/Rally numerical states | 367,200 checked | `BALANCE_ARITHMETIC.json` |
| Enemy queue funding, without combat/congestion | 36 schedules checked | `BALANCE_ARITHMETIC.json` |
| Defined full-win earned catalogue route | 12 clears without ads; 10 with all eligible bonuses | `BALANCE_ARITHMETIC.json` |
| Canonical v0.2.0 content records | Ten files retained byte-for-byte | `../records/SOURCE_INPUTS.json` and verifier |
| Source structure and references | Passed at assembly; sealed verification reports its exact final count | `SOURCE_STRUCTURE.json`, `FINAL_VERIFICATION.json` |
| HTML reader | 22 chapters; desktop/mobile widths checked; three reference images loaded; no JavaScript errors | `reader/reader_review.json` and reader captures |
| Historical source archives | Original hashes and ZIP CRC checked | Source verifier and input ledger |

The arithmetic audit enumerates modifier configurations. It is **not** 45,900 battles and does not prove troop counters, difficulty, pacing or fun. The formal schemas verify structure; additional semantic checks live in the verifier and reference suite. Save fixtures are examples to implement and test, not proof of operating-system crash recovery.

## Reproduction

From the extracted package root, with Python 3.10 or newer:

```text
python tools/verify_source.py
python -m unittest discover -s tests -v
python tools/audit_balance.py
```

These three commands use the standard library. The formal-schema report was produced with Python `jsonschema.Draft202012Validator` in the assembly environment; `schemas/SCHEMA_INDEX.json` maps each checked input to its schema. No Unity project or third-party SDK was executed to produce these source reports.

The HTML reader was rendered using Chromium at 1440-pixel desktop and 412-pixel mobile viewport widths. The included screenshots are **documentation reader review**, not game captures. Their image thumbnails are the already-existing conversation references.

## Seal and mutable evidence

`SOURCE_MANIFEST.json` seals all delivered source, documents, references, templates and existing evidence except itself and `evidence/FINAL_VERIFICATION.json`. Those two explicit exclusions avoid self-referential hashes. The final verifier report is derived from the sealed files; rerunning the verifier independently validates them. The distributed ZIP SHA-256 additionally identifies the entire delivered archive.

Do not overwrite original source evidence during development. New game evidence belongs under `ImplementationEvidence/<task>/`. `Game/`, `Services/`, `.git/`, Python cache files and future implementation evidence are not part of the immutable source manifest. A source correction requires a new numbered source release and seal, not manually editing the manifest to conceal a changed design.

## Runtime status

All **155 runtime QA cases** remain `NOT_RUN`; all **11 production phases** remain `NOT_RUN`; all **12 task packets** remain `NOT_STARTED`. No final production images/music/SFX were generated. No source package can itself establish external account ownership, future asset rights, merchant readiness, final privacy declarations or publication approval.
