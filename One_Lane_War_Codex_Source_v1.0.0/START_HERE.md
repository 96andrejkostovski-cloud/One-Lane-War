# One Lane War — Codex source v1.0.0

This is the complete consolidated **source handoff**, not a built Unity game. Start with the game Bibles and canonical registries, not the older conversation's contradictory gate lists.

## Install

Extract the ZIP, then place the contents of its `One_Lane_War_Codex_Source_v1.0.0/` folder in a new dedicated local workspace. Keep this file, `AGENTS.md`, `SOURCE_AUTHORITY.json`, `data/`, `bibles/`, `contracts/`, `tasks/`, `tools/` and `tests/` at the workspace root. Do not put it inside another game's repository. Codex will create `Game/`, later `Services/`, and `ImplementationEvidence/` beside them.

The included `INDEX.html` is an offline readable collection of all Bibles and reference tables. Markdown and JSON are the implementation sources; HTML is generated from them. Historical ZIPs under `references/history/` are not another active authority.

## Verify without Unity

```sh
python tools/verify_source.py
python -m unittest discover -s tests -v
python tools/audit_balance.py
```

Python 3.10+ standard library is enough for these commands. They do not install Unity, mutate accounts, generate art, run a combat simulator or deploy services. Read `evidence/SOURCE_VALIDATION.md` for the checks actually performed during assembly.

## Give Codex the first task

Open Codex in this workspace and issue the bounded prompt in `START_CODEX.md`. The first task is **OLW-CORE-001**: toolchain plus placeholder combat foundation, all six troop mechanics and 24 upgrade operators. It deliberately excludes real commercial SDKs and final art/audio. The later task files cover the full game and release.

## Non-negotiable workflow

Single-player offline/local saves. Full working placeholder game first. Then real screenshots from that build, owner-approved V001-style paintovers, then final Higgsfield/Suno/ElevenLabs generation and polish. No early final asset gate. Image numbers and invented UI features do not override B001. No new gameplay feature systems.

## What remains external

Final name/package/publisher/contacts, actual tool/licence availability, approved service credentials, output-specific rights, final P001 visual selection and release evidence are recorded in `data/deployment_inputs.json`. They are not hidden holes in the troop design. Only the relevant phase is blocked; final artwork and merchant setup do not block offline placeholder code.

Source creation does not authorize public repository changes, new paid spending, live deployment, purchases or publication. Issuing a task authorizes only its defined scope.
