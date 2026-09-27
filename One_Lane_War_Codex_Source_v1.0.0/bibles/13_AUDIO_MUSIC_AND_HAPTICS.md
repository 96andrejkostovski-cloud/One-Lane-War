# Bible 13 — Audio, Music and Haptics

**Authority:** AU001 mechanical/mix targets. The chosen providers are Suno for music and ElevenLabs for SFX. Actual generation occurs PH08, not during placeholder development. Silence or small locally synthesized test cues are acceptable until then.

## 13.1 Catalogue and musical direction

Two instrumental loops are sufficient: Menu/Army at 96 BPM, 40 seconds, sixteen 4/4 bars; Battle at 120 BPM, 32 seconds, sixteen 4/4 bars. Three short stings cover victory, defeat and expedition completion at approximately 2/2/3 seconds. These are generation/edit targets and not a claim the provider will output seamless bar-perfect files directly. Trim, crossfade and measure the final exports.

Musical identity should match bright comic medieval tactics: rhythmic acoustic/percussive character, melodic restraint, no vocals, no imitation of a named copyrighted game's signature tune. Battle music supports deployment decisions rather than escalating so densely that impacts disappear. No five-era soundtrack, adaptive music-composition system or voice actor is added.

Maintain 48 kHz/24-bit lossless masters. Music mastering target is −16 LUFS integrated and at most −1 dBTP; final playback mix is validated on headphones and phone speakers. Record measurement tool/settings. Runtime encoding, streaming/decompression and loop boundaries are verified on the selected Unity/audio backend. Never loop an MP3 by hoping its encoder delay is inaudible without testing it.

## 13.2 Sound design

The 25 sound families in `data/assets.json` cover interface, deployment, each weapon/impact family, barrier/block, grenade, Ram movement/contact, Rally, deaths, fortress damage/destruction, rewards/unlocks, draft and purchases. Family variations are permitted to avoid repetition but do not expand gameplay. Generate dry isolated effects without speech, unrelated ambient beds or hidden music. Use short tails appropriate to repeated attacks.

Auditory hierarchy follows gameplay: interface/deploy acknowledgement is clear and brief; light impacts stay light; shield block is distinct; crossbow release/impact is precise; grenade is spatially readable; Brute/Ram convey heavier mass; fortress destruction resolves the battle. Avoid a purchase-success sound implying a pending payment already granted ownership. Error/pending states have neutral feedback, not repeated alarms.

Use separate Music, SFX and UI mixer groups. Initial normalized levels are 0.55/0.80/0.65. Player settings persist locally; the UI can expose Music and Effects while the internal UI bus retains its mix relationship. Overall silence must leave the game fully understandable. No gameplay information is audio-only.

## 13.3 Runtime budget and scheduling

The default pool permits sixteen concurrent voices, at most three of one family. Rank critical UI/fortress/Rally above ambient or repeated light hits. A crowded army must not play forty-eight equally loud simultaneous impact files. Voice stealing fades/removes a lower-priority sound and never changes combat timing. Keep bounded volume/pitch variation within approved ranges and deterministic debug options for comparison; audio randomization is not combat RNG.

Trigger audio from the model's committed presentation events. A missed melee swing may use a swing without a hit. A projectile hitting a shield uses the correct impact family. Pool reuse and scene transitions clear obsolete scheduled sounds. Death clips do not leave loops running on a despawned Ram. Music loop owners have one active instance; reopening Army cannot layer identical tracks.

## 13.4 Focus, advertisements and lifecycle

Loss of focus/background follows platform audio focus and the game's pause policy. A store/ad overlay acquires the correct mixer duck/mute state. Restoration releases only its own reason; it must not override the user's volume choice or another active focus loss. Incoming calls, headphones unplugging, Bluetooth changes and repeated suspend/resume require device tests. Respect Android media-volume behavior; do not promise that a ringer switch universally controls game media volume.

On return, restore the previous loop position where the implementation supports it cleanly; avoid abrupt restarts after every short overlay. Never leave the app permanently muted after an advertisement, or resume two loops after a callback race. A denied audio/haptic preference must remain denied after save reset if the specified reset retains settings.

## 13.5 Haptics and motion

Light feedback may confirm deployment or a deliberate UI action; medium feedback marks Rally; stronger bounded feedback marks Ram/fortress impact. No continuous buzzing on every light attack. Platform support varies: unsupported haptics is a no-op, not an error. A persistent toggle disables every haptic route. Reduced motion suppresses heavy screen impulses and flashes; it does not change damage or attack periods.

Haptic timings are calibrated in the final device pass. An emulator screenshot or vibration API call does not prove perceived strength. Limit repeated triggers with a minimum interval and a priority policy; detailed values live in the presentation contract when measured. Do not advertise universal accessibility compliance from having a toggle.

## 13.6 Rights, delivery and approval

Retain the provider plan/licence holder, creation/download dates, relevant terms, prompt and source audio hash. Suno's commercial-use permissions and ElevenLabs' SFX terms must cover the actual output and intended game distribution; do not assume upgrading later retroactively clears older material. [EXT31–EXT33]

Deliver lossless source masters, edited loop/effect masters, runtime encodes, loop metadata, loudness/peak report and the binding manifest. Review clipping, noise, click-free boundaries, consistency, silence/focus behavior and crowded battle intelligibility. The owner approves the final set after listening in the actual game. Final audio acceptance is separate from source catalogue completeness.
