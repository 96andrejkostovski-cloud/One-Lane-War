# OLW-AMEND-005 — Spawn contact under fortress pressure

**Status:** ACTIVE DIRECTOR DESIGN DECISION, 2026-09-27.
**Base:** OLW-SOURCE-1.0.0 and OLW-AMEND-001 through OLW-AMEND-004.
**Authority:** The owner's Director brief delegates ordinary game-design and
source-conflict decisions to the Game Director. This amendment resolves the
reproducible OLW-CORE-001 spawn conflict recorded in
`ImplementationEvidence/OLW-CORE-001/DIRECTOR_BLOCKER.md`.
**Scope:** The creation, targeting and separation of actors whose fixed spawn
footprint is occupied by an opposing living actor. No B001 value, troop,
upgrade, encounter, deployment position or WF002 gate changes.

## Decision

A deployment that passes the existing battle, pause, loadout, Supply,
cooldown and population checks succeeds at the side's exact B001 spawn
position. It spends Supply and creates the actor atomically as before. The
enemy queue and an owed Conscription bonus use the same fixed-position rule
when they create an actor. There is no new paid rejection, purchase queue,
spawn delay, displaced spawn point, knockback or teleport.

**Spawn contact** is the sole exception to Bible 02's hostile non-overlap
rule: if the newly created actor's collision footprint intersects a living
opponent at that fixed point, the intersecting bodies may overlap while
contact persists. This exception is created only by spawning. It cannot be
used by ordinary movement to enter or deepen an overlap. Each involved actor
holds its current X while it overlaps any opposing body. No actor may cross
an opposing body; when the contact ends through a death or another ordinary
state change, movement resumes under the normal simultaneous collision
rules on the next tick. Never move an actor backward to repair contact.

Actors in spawn contact remain living, targetable, damageable and counted
against their side's cap. At attack selection, an overlapping opponent is
a reachable troop target at zero edge gap even when the centres are in the
reverse order for ordinary forward targeting. Choose among overlapping
opponents by absolute centre distance, then stable actor ID. This contact
priority applies before ordinary forward targets or a fortress. All normal
slot eligibility, attack timing, range, damage, barrier, projectile and
death rules still apply; contact does not give a reserve melee actor an
attack slot or deal automatic damage. A living defender in contact blocks
new attacks on its fortress. An already committed base attack retains its
normal impact recheck; if the new defender blocks the base at impact, that
impact misses rather than retargeting or passing through the defender.

The exception is symmetric for player and enemy fixed spawns. It preserves
the ability to reinforce a fortress already under attack without making a
paid tap fail or allowing bodies to pass through one another. The chosen
behavior supersedes only the blanket hostile-overlap sentence and the
ordinary forward-centre target rule for these spawn-contact pairs in
Bible 02. All other B001 and Bible 02 rules remain active.

## Implementation and evidence gate

Continue **the existing OLW-CORE-001 Goal and branch**. Replace the known
failing canonical `c01_e01_b01` spawn-pressure fixture with assertions for
the above behavior. Add focused fixtures for reverse-centre contact,
multiple overlapping targets and stable ID tie-break, movement/crossing,
base shielding including an in-flight committed impact, the enemy-side
case, and cap/Supply/Conscription accounting under contact. Run the affected
model fixtures and required PH01 Unity/Android/native checks; record the
tested exact HEAD and each evidence class separately in `TASK_RESULT.md`.
Do not mark PH01 PASS until the full task's acceptance evidence exists.

OLW-CORE-002, B002, T002, commercial services, final media and publication
are not issued by this amendment. If tests reveal another genuine source
conflict, retain its reproduction and return it for a separate Director
decision; do not broaden this exception silently.
