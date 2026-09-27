# Bible 07 — Technical Architecture

**Authority:** implementation architecture ARC001. Gameplay remains B001; workflow WF002. This is a Unity application specification, not existing executable code.

## 7.1 Project boundaries

Create one dedicated repository/workspace, not a branch inside Roman Legacy, BBGL, or Reactorfall. Extract the handoff contents into the new workspace root, retaining its `bibles/`, `data/`, `contracts/`, `tasks/`, `tools/` and root instructions. Codex later creates `Game/` for Unity, `Services/Entitlements/` for the backend, and `ImplementationEvidence/` for its own results beside those source folders. The included `evidence/` remains the source-package audit, not runtime proof. Do not nest a second competing source copy. Do not copy another game's databases, legal identities, platform credentials, scenes, or monetization code without a separate reviewed reuse decision.

Use `OneLaneWar` as the C# namespace. During local proof use the explicitly development-only application identifier `com.example.onelanewar.dev`. That identifier is not commercial clearance, must never be registered as the production app, and is a release-validation failure. The owner’s final package ID is a deployment input, not a reason to block offline placeholder work. Keep environment identities in an explicit build profile rather than scattered string replacements.

Runtime module responsibilities are deliberately limited:

| Module | Owns | Must not own |
|---|---|---|
| CombatModel | fixed-point state, commands, movement, attacks, outcomes | Unity objects, money, network |
| Content | typed validated registries and immutable configuration | mutable player inventory |
| RunProgression | expedition/draft/campaign/reward transitions | effects that award damage |
| Save | atomic persistence, recovery, migrations | balance decisions |
| Presentation | unit views, camera, animation, HUD, audio/VFX | authoritative HP/Supply/Medals |
| PlatformServices | consent, ads, purchases, diagnostics adapters | mandatory online gameplay |
| EditorValidation | import, build, capture, developer harness | release-only secret storage |
| Tests | pure model, Unity, integration and regression fixtures | fake production PASS reports |

Assemblies should express these dependency directions. Do not introduce ECS, a general-purpose dependency-injection framework, a custom scripting language, a networking layer for combat, or microservices. Plain C# classes and small interfaces are sufficient. No core combat class inherits MonoBehaviour. A scene disappearing must not destroy the only authoritative record of a reward.

## 7.2 Scenes and lifetime

Use one bootstrap/menu scene and one reusable battle scene. The bootstrap lifetime owns content, settings, save, run coordinator and adapters. Battle lifetime owns the model instance, presentation pools and subscriptions. All six main screens are views within these two scene responsibilities, not six separate world scenes. Game initialization orders local settings and save before network work. Invalid core content is a clear local fatal error with a diagnostic code; unavailable optional services are not fatal.

Every event subscription has a matching disposal path. Scene transitions cancel outstanding view requests, not earned transactions. At the end of battle freeze model input, settle the result once, commit the new checkpoint, then show the next screen. A failed commit holds a recoverable state rather than silently advancing. Re-entering the same scene does not initialize a second Firebase instance, duplicate music loops, purchase listener, or analytics session.

## 7.3 Adapter contracts

The detailed operation/state contracts are in `contracts/platform_interfaces.json` and `contracts/service_api.json`. Required abstractions are `ISaveStore`, `IAnalytics`, `IDiagnostics`, `IConsentState`, `IRewardedAds`, `IPurchases`, `IEntitlements`, `IRemoteSettings`, `IAudioOutput`, `IHaptics`, and `IPlatformLifecycle`. Fake, unavailable and real adapters implement the same contracts. Fake adapters expose explicit scenario controls in developer builds. They are never called a live integration.

Commands return explicit accepted/rejected/pending results with stable reason codes. UI presents those results; it does not infer success from a sound or button animation. Main-thread presentation consumes model events after a completed tick. A network callback arrives through a main-thread dispatcher before touching Unity objects. Durable grants and backend idempotency do not depend on which thread rendered a toast.

Every asynchronous operation carries an operation ID, originating run/draft/product where applicable, cancellation scope, and terminal status. Cancelling a screen request does not cancel a completed store purchase or erase an earned ad reward. Timeouts mean unknown/retryable when the remote system may already have committed; they do not prove payment failure.

## 7.4 Clocks, input and suspension

Combat uses its own integer tick, not wall-clock time, Animator speed or arbitrary deltaTime accumulation. Render interpolation observes neighboring simulation states. A frame accumulator may process multiple fixed steps when rendering is slow; the developer speed control schedules more identical steps, never changes the 0.05-second step size. A hard per-frame step budget should yield to rendering without skipping or coalescing authoritative impacts. Report severe backlog in development.

Pause is a set of reasons: player menu, focus/background, system overlay, consent/store/ad overlay, and blocking save/error state. Releasing one reason cannot resume while another remains. Background entry clears held input and the accumulator's suspended elapsed time. Returning from background presents an explicit paused state; no catch-up Supply, enemy purchases or Rally time is credited. The phone date has no progression use: there are no daily rewards, energy, or offline-income calculations.

Use the Input System for touch and editor pointer tests. Pointer-up inside the original enabled control is a single command; dragging outside cancels. Multitouch cannot bypass deployment cooldown. Keyboard shortcuts are developer harness conveniences only, not a marketed PC/controller mode. Inputs behind a modal are blocked. Changing application focus during a press cancels that press.

## 7.5 Content and representation

Import canonical JSON through a typed, deterministic importer. Generate runtime data from the current source hash; do not hand-edit a second set of ScriptableObjects and leave the JSON stale. Development can read JSON directly; release can use a validated bundled representation generated from the same bytes. Include an internal source/balance/content ID. Unknown IDs and missing references fail import; they never silently fall back to Militia or zero damage.

Model units, attacks, projectiles, damage events, barriers and command sequences use stable IDs. Unit views are pooled and bound to model IDs. Returning a view to a pool removes previous side, material, HP, animation, listeners, timers and cosmetic bindings. Cosmetic changes must not mutate combat configuration or hitboxes. A corpse is a presentation object, never a living actor.

At 48 living actors there is no need for speculative distributed processing. Prefer bounded arrays/lists and stable sorting to an elaborate scheduler. Avoid routine allocations in hot ticks and cache immutable lookups. If an actual valid battle exceeds a provisional projectile/VFX capacity, preserve gameplay and record the violation; never silently discard a damage-bearing projectile to satisfy a visual budget.

## 7.6 Rendering architecture

T001 selects built-in 2D rendering and OpenGL ES 3. The placeholder uses flat shapes, readable labels, primitive shadows and simple projectile/explosion cues. Final polish uses illustrated sprites, transform cutouts, materials and bounded particles. Do not import URP solely because a paintover says 'lighting'. A URP 2D Light or ShadowCaster prescription is not compatible by assumption with this baseline.

The default final implementation path is baked directional shading in artwork plus simple composited contact shadows and restrained material tinting. The precise light/shadow appearance is selected from captures after PH06. A need for a different renderer becomes a documented toolchain/presentation amendment with device and art cost evidence, not an implicit style change.

## 7.7 Offline and security posture

No network call is on the critical path to start, continue, or finish a battle. The application has no account authentication or cloud progression. It intentionally does not defend local Medals from a determined file editor. SHA-256 in saves detects corruption, not hostile manipulation. Protect real-money ownership through store verification and signed receipts; accept that a modified offline binary remains an anti-tamper risk in this small, noncompetitive game.

No runtime provider generation, reasoning-model calls, microphone, camera, contacts, location or notification feature. The intended runtime permission budget is zero prompts; inspect the merged manifest and any SDK permissions. A SDK-level normal permission is not automatically a gameplay permission. Unexpected wake/background behavior must be investigated rather than excused by the offline label.

## 7.8 Build observability and acceptance

Developer HUD shows source and model versions, tick, active pause reasons, Supply, base HP, alive counts, pending bonus, current enemy queue index, projectile count and result. It may show formation slots, ranges and hitboxes. It must be compiled out of release routes. Headless runs use the same combat assembly as Unity. Reference Python math in this handoff is an independent oracle for arithmetic, not a replacement combat engine.

Architecture acceptance requires a clean-checkout build, no assembly cycles, no network dependency for offline scenarios, no presentation-owned damage or currency, scene-reload subscription tests, and identical model outcomes across rendering speeds. Inspect the actual final commit; a diagram does not establish any of those properties.
