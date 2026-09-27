# Bible 11 — Visual Direction and Screenshot-Based Presentation

**Authority:** V001 is approved style direction; WF002 defers final production until a working placeholder game. Lighting/shadow/UI exact execution becomes P001 only after owner review of paintovers based on real build captures.

## 11.1 What the references mean

Three prior conversation images are included under `references/visual/` with verified file hashes. V001_A is the owner's chosen direction; V001_B is the polished battle finish target; V001_C is a multi-screen style sheet. They are generated references, not screenshots from a Unity implementation and not already-ready commercial assets. No new images were generated for this handoff.

Preserve the shared character of these references: bright sunlit comic medieval world, illustrated 2D/2.5D depth, scenic valley/mountains/river, chunky readable soldiers/equipment, blue player and red enemy supported by symbols, dark metallic panels, gold accents and a legible action hierarchy. No photorealism, gritty realism, painterly sketch finish, gore or child-directed marketing assumption.

Do **not** adopt the mock images' mechanics. Examples of non-authoritative content include 4,000 fortress HP, 1,000 Supply capacity, 150/300/250/350 unit prices, extra star/power progression, invented rewards or units, inaccurate upgrade percentages, altered currencies and a logo implying trademark clearance. Actual B001 values are 900 default player HP, Supply cap 200 and starter costs 20/45/50/65. `data/visual_references.json` records these differences. The style sheet is not permission to add a screen or feature.

## 11.2 Placeholder first, including presentation interfaces

Use flat colored shapes with role labels and distinct geometry. Unit size represents the intended relative category; model half-width remains independent. A simple ellipse contact shadow, colored projectile and expanding explosion ring are sufficient to verify layering, timing and readability. Placeholder animation can articulate primitive parts so the same sockets and timing events are exercised before final art. This is allowed local development, not final asset generation.

Do not spend weeks matching V001 before PH06. However, do implement real responsive layout, safe areas, input states, animation/VFX interfaces and capture hooks. Deferring artwork does not mean postponing readable troop roles or touchable controls. Gameplay logic must be entirely separate so replacing a sprite cannot change damage or a paid entitlement.

## 11.3 Camera and composition contract

The battlefield is one fixed horizontal simulation lane, both fortresses visible, no camera panning or zoom during ordinary combat. Reference canvas is 1920×1080. A fit-to-safe-gameplay-rect algorithm calculates orthographic size at screen/layout changes; it does not invent different attack ranges for wider phones. Fit the entire logical lane and fortress art extents. At wider ratios, decorative scenery may extend; at narrower supported ratios the view fits the required horizontal extent and keeps controls outside the gameplay viewport. Portrait is not a supported mode.

The camera's world-to-screen mapping and unit root bounds are captured as metadata. Horizon height, final unit pixel height, fortress artwork width and exact lane vertical placement are evaluated on the actual placeholder layout; they are P001 decisions, not numbers silently derived from a generated image. UI safe-area changes may move anchors; they cannot crop fortress health or hide troop buttons. Depth offsets and parallax are visual only and never create selectable lanes.

## 11.4 Lighting and shadows without changing the engine

T001 uses built-in 2D, not a 3D scene with physically simulated sun shadows. V001's lighting can be implemented through illustrated shading, sprite tint/material treatment, atmosphere layers and contact-shadow sprites. A paintover may depict warm upper-left light; it does not prove that Unity needs a Directional Light component or a URP renderer. Implement only the effect needed to match the chosen screen within the performance contract.

For the placeholder use neutral flat materials, no bloom/post-processing dependency, and simple soft ground-shadow shapes. At P001 lock key-light apparent direction, ambient contrast, shadow tint/opacity/softness/offset, atmospheric depth, foreground/background saturation, UI shading and any material parameters with actual scene tests. Ground shadows follow unit feet, are removed with the unit view, and do not become gameplay colliders. Avoid baking contradictory left/right lighting into mirrored characters; the chosen art/rig production must handle the two facings coherently.

## 11.5 Capture pack

`data/screenshot_pack.json` enumerates the required captures. Codex exports **raw real render captures** with correct HUD, no debug overlay and no external retouching. A separate annotated copy may show bounds; never overwrite the raw image. The capture sidecar records source/app/balance version, scene, screen state, dimensions, safe area, camera matrix or fit values, run/encounter/attempt, loadout, upgrades, tick, device/AVD and whether the state is a developer fixture.

Capture Home/Campaign, Army, all relevant battle densities and outcomes, Draft, Results, Shop, Settings, Pause and important error/consent states. Include early engagement, 24-vs-24 readability, Rally, barrier, grenade explosion, protected Crossbow line, Ram-to-fortress contact, overtime, victory/defeat/draw. Dense artificial fixtures are valid engineering references but must not be advertised as ordinary attainable gameplay without proving that route.

The main review pack uses 1920×1080; actual supported-aspect captures supplement it. Do not stretch a phone screenshot to fake that aspect. Keep a real capture at the native rendered size and identify any separately re-rendered reference-size capture. Animation and VFX also need short real recordings; a paused screenshot cannot prove timing or motion.

## 11.6 Paintover loop

The owner supplies or identifies a real placeholder capture. Generate alternative final-look targets using that image as the layout reference and V001 as style reference. Maintain the same screen, camera, unit roles, current numeric values and controls. An image generator can still drift in typography, geometry or counts; therefore the target is reviewed against the source capture and cannot be treated as a pixel-exact conversion by assertion.

The owner approves a particular target, with the approval scope recorded. Extract implementable parameters and required modular assets, not a flattened screenshot installed as the game. Codex applies UI styles, sprite assets, shadows, materials and VFX, then captures the same state again. Compare source capture → approved target → actual implementation. Changes to layout or gameplay discovered during this review need explicit source amendments, not hidden visual reinterpretation.

The template prompt and acceptance checklist are included under `templates/`. They are instructions for a later authorized generation task, not executed work. No final artwork, music or effects are purchased/generated merely because this package contains prompts.

## 11.7 Presentation acceptance

At full density a player must distinguish categories and sides, locate the frontline, read fortress HP/Supply/Rally and use all four deployment controls. Smoke, bursts, foreground grass, shadows and particles cannot obscure essential controls. Do not convey ownership, blocked buttons or teams by color alone. Test both landscape orientations and the narrowest supported safe viewport.

Approve final visual states for normal/pressed/disabled/focused controls, all Rally states, unit affordability/cap/cooldown, draft selected/reroll-used/ad-unavailable, Shop owned/pending/unavailable, and result types. A beautiful normal-state mock does not cover the state machine.

P001 records actual values, font licences, texture/atlas settings, approved screenshots, asset mappings and profile results. Store screenshots/trailer gameplay are captured from the final executable, not generated paintovers. They must show attainable implemented mechanics and correct prices/benefits.
