# Bible 12 — Assets, Animation and VFX Production

**Authority:** animation mechanics AM001, asset catalogue 148 planned families, V001 style, later P001 execution. External production begins PH08 after placeholder completion and screenshot-based targets. No font binaries or finished production artwork are distributed in this source pack.

## 12.1 Asset catalogue and replacement boundary

`data/assets.json` is the complete inherited launch catalogue: six troop masters, two derived bosses, two fortress families, three environments, six portraits, 36 animation bindings, 24 upgrade icons, six main UI views, earned/paid cosmetics, 12 VFX families, 25 SFX families, two music loops, three stings and marketing families. A record is a family or binding, not necessarily one file. A six-state character can require multiple parts, clips, atlases and exports. Every current production record remains PLANNED_NOT_GENERATED with no invented source path, approval or rights proof.

Use an asset binding layer from stable IDs to placeholder or final presentation. Runtime content refers to IDs, not hand-entered file names in combat code. A missing final binding is visible in development and fails final readiness; it must not silently ship a gray rectangle. Placeholders remain available for diagnosis but are excluded from advertised final capture fixtures.

## 12.2 Production order after the gate

Begin with Militia, Crossbowman and Ram to prove humanoid melee, two-hand projectile use and mechanical movement. These production proofs happen **after** the complete placeholder game, not before it. Then produce Shieldguard, Grenadier and Brute; derive boss equipment/scale while retaining mechanics; produce environments/fortresses, UI/icon families, cosmetics and remaining effects. Shared style sheets and approved target screens govern every generation batch.

Generate a small reviewed batch, not the entire catalogue blindly. Keep source prompt/model/provider/date and revision. Rejected alternatives remain history with a rejection reason, not active master candidates. No overwrite of an approved original during a repair. Output acceptance has separate visual, technical, rights and integration statuses.

## 12.3 Cutout source specification

Use Unity-native transform cutouts: separated transparent PNG parts, a shared biped hierarchy for five humanoids, and a separate Ram hierarchy. No root motion, external skeletal-software licence, 3D model requirement, or generated-video animation dependency. The source reference canvas is 1024×1024 at 512 pixels/world metre with a feet-root convention. Actual part bounds/pivots depend on approved drawings and are stored in metadata.

Required humanoid components include head, torso, near/far upper/lower arms, hands, upper/lower legs, feet, weapon and any shield/accessory. Use view-relative near/far names internally to avoid confusing mirrored screen direction with anatomical left/right. Include concealed overlap beneath joints, neck, hips and grips. A flattened attractive soldier lacks the hidden pixels needed to bend its elbow; it is not a completed rig source.

Define parent, local pivot, draw order, attachment socket and allowed transform range per part. Weapon grip must remain stable; a crossbow release socket follows its muzzle, not the torso center. Feet contacts and weapon reach are visual calibration against the model, not replacement collision geometry. Mirroring must not invert text/heraldry incorrectly or produce a contradictory light source; separate approved facing variants are permitted within the same unit family when necessary.

The Ram includes frame/body, wheels, moving strike beam, recoil connection and decorative parts. Wheel angle is actual distance divided by 0.25m radius. No unrelated spinning wheels while stationary. Its mechanical body does not imply hidden operator units, extra health pools or new attack logic.

## 12.4 Animation synchronization

All six required states are Idle, Move, Attack, Hit, Death and Victory. Exact attack/windup/follow-through/recovery/death times and movement-cycle targets are in `data/animation_contract.json` and the generated catalogue. Idle loops are 2.4 seconds, victory 1.6 seconds, blend 0.08 seconds, additive hit 0.10 seconds without stun, fade after death 0.25 seconds. A hit reaction cannot reset an attack or postpone simulation damage.

The model publishes attack-start/release/impact/death events with tick IDs. Visual playback follows the quantized snapshot; Rally changes new attack intervals rather than speeding an in-progress animation arbitrarily. Clip import and Animator transitions must preserve release/impact correspondence. Animation events can request visual/sound cues but never award damage. If presentation drops a frame, model impact still occurs once.

Use precedence death > committed attack > movement > idle, with additive hit feedback where compatible. No simulation-wide hit stop. Presentation-only shake/recoil is bounded and disabled/reduced by the accessibility setting. Corpses stop blocking immediately at model death and their finite fade returns views to pools. Victory visuals begin only after the model/result transaction has resolved.

## 12.5 Texture/import rules

Preserve lossless original sources and export processed runtime copies. Use sprite atlases separated into UI, troops, environments and effects, maximum 4096 per atlas under this baseline, avoiding an enormous combined texture loaded everywhere. ETC2 is the initial compression baseline for the selected OpenGL ES 3 target; inspect alpha edges and memory. Bilinear filtering is default. Character/UI sprite mipmaps are off; environment mipmaps are evaluated where minification requires them. Premultiplication/alpha conventions are consistent throughout import and shaders.

Do not embed changing text, prices, counters, health numbers, buttons or entire menus into images. UI labels use licensed runtime fonts. Preferred typography is Roboto Slab ExtraBold for display, Inter for function and Noto Sans fallback, subject to actual licence acquisition and readability in P001. The package includes names and licence obligations, not font files. Glyph atlases must cover every shipped English string and store-returned prices without missing-currency boxes.

Linear color-space selection and material consistency must be tested against the actual art and low-tier renderer. No unapproved post-processing stack or realtime light/shadow system is introduced to imitate a paintover. Exact tints, grading and shadows are P001 parameters.

## 12.6 VFX families and behavior

The 12 families cover spawn dust, slash, generic hit, block, bolt trail/impact, grenade, barrier, Rally, hit flash, death, reward and fortress destruction. Use short readable silhouettes rather than unlimited bloom/smoke. A grenade is the largest ordinary troop effect, a Ram/fortress impact the strongest standard hit, and fortress destruction the main terminal spectacle. Militia attacks do not shake the whole screen.

Default limits are 64 active effects and 400 particles across the effect manager, with priorities favoring gameplay communication. When saturated, reduce decorative dust/trails first. The model still resolves every projectile/damage event. An exhausted VFX pool may omit a low-priority spark, never the damage itself or essential barrier/Rally state indicator. `audio_vfx_contract.json` contains baseline timing/shake settings; P001 chooses the sprites and final material treatment without changing those gameplay events.

Effects clear on transition; late callbacks cannot attach to a recycled unit ID. Shake is presentation-only, accumulated and clamped rather than stacking indefinitely. Haptics and reduced-motion controls are honored across every trigger. Smoke cannot cover deployment buttons or become a simulated obstacle. Explosions do not fling units as a new knockback mechanic; any decorative debris has no collision authority.

## 12.7 Rights and acceptance record

For every production item record asset ID, provider/model, account/licence holder, applicable terms date/reference, generation/download dates, prompt, supplied references and their rights, original/checksum, edits, exported files, technical settings, visual approval, integration evidence and replacement history. Provider account access alone is not a licence audit. Generated output is not necessarily unique or free of third-party similarity.

Technical acceptance includes exact canvas/import settings, clean alpha, no edge halos, hidden joint coverage, both facings, grip/pivot integrity, coherent scale, readable phone-size silhouette, no baked live text and complete ID mapping. Integration acceptance includes same-state screenshot comparison, six animation states, active speed buffs, 24-vs-24 readability, pool reset, memory/performance and source-hash traceability. Approval of a style reference does not mark all future generated assets approved.
