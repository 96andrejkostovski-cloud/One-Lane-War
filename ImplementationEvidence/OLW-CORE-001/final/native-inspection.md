# Final installed-player inspection

Tested implementation: `f41126d87e77a534da977715224cf9d8ce7999ce`.
APK SHA-256: `18d8c724a21b30fc8dcd6e1d636331edb62f08e7d21581c1058eb2df42feee30`.
Date: 2026-09-27. Dedicated emulator: `emulator-5556`, OLW_PH01_API36.
All commands below used the exact editor's `AndroidPlayer/SDK/platform-tools/adb.exe`
and `-s emulator-5556`. No input was sent to the pre-existing emulator-5554.

## Native proof

Installation and cold launch exit 0 are in native-commands.txt. PID 8485
completed eight cases with the expected hash, tick 1152 and PlayerWin.
`logcat -d -v threadtime --pid=8485` is native-logcat.txt. Actual process maps
from `shell run-as com.example.onelanewar.dev cat /proc/8485/maps` are in
native-loaded-maps.txt, including ARM64 libunity/libil2cpp and bridge mappings.
No final proof timeout/hash mismatch, screenshot failure, DllNotFoundException,
NullReferenceException or FATAL EXCEPTION was found in that process log.
The log is not warning-free: an initial `liblibswappywrapper.so` lookup fails,
then the actual `libswappywrapper.so` path loads and initialization succeeds.
SwappyDisplayManager also logs a class-loader `libgame.so` lookup warning,
and HWUI logs a 101010-2-format fallback. Those lines remain visible; the
player continues through all eight rendered replays and subsequent input.
Missing `il2cpp.usym` is recorded, without claiming symbolized native debugging.

`pull /sdcard/Android/data/com.example.onelanewar.dev/files/PH01 .../final/native-captures`
succeeded: 18 files, 17 PNGs plus replay.txt. native-validation.json checks all
eight unique combinations of requested FPS 30/60 and speed 1/2/4/10.
Measured FPS range is 24.33–32.77. This is not physical-device performance.

Fresh environment queries returned:

- `shell getprop ro.build.fingerprint`: `google/sdk_gphone64_x86_64/emu64xa:16/BE2A.250530.026.D1/13818094:user/release-keys`.
- `shell getprop ro.product.cpu.abilist`: `x86_64,arm64-v8a`.
- `shell getprop ro.dalvik.vm.native.bridge`: `libndk_translation.so`.
- `shell getconf PAGE_SIZE`: `4096`.
- Google Play API36 x86_64 image revision 7; emulator 37.1.11.0/build15917651.

## Actual controls and lifecycle

Screenshots used `shell screencap -p /sdcard/olw-<name>.png`, then `pull` to
this folder. Screen coordinates are the original 2400x1080 pixels. Each
observed result below was inspected from the actual pulled image.

1. `shell input tap 1415 942` opens Configure; `input tap 970 862` starts a
   fresh manual battle. An immediate batched speed tap was not processed;
   manual-before.png shows tick32, 10x, actors0/0, Supply111, PAUSED.
2. With 600ms between native taps: `(825,942)` selects1x, `(405,942)` resumes,
   `(442,820)` deploys Militia, `(405,942)` pauses. manual-deployed.png shows
   tick63,1x, one player Militia70HP and Supply101. The 20 Supply purchase
   and intervening regeneration are consistent with the model; exact atomic
   cooldown/cost assertions are in the model and PlayMode fixtures.
3. `(405,942)` resumes; after700ms `input keyevent 3` backgrounds. After3s,
   `shell am start -W -n com.example.onelanewar.dev/com.unity3d.player.UnityPlayerGameActivity`
   reports HOT/ok. After2s, manual-return-paused.png shows PAUSED,tick91,4.55s.
   A second capture3s later, manual-return-still.png, is byte-identical:
   no background or foreground elapsed-time credit. Explicit resume then
   advances to tick125 and144 in subsequent captures.
4. The first Rally tap was before the canonical initial cooldown and was
   correctly ignored (manual-rally-active.png, despite its early provisional
   filename, shows Rally4.8s, not ACTIVE). After a further5s of running,
   `(1900,820)` activates Rally. manual-rally-confirmed.png shows tick288,
   Rally ACTIVE, real enemy actors and no error overlay. Then paused again.

Configuration, battle-30-1 and clean-30-1 captures were visually inspected.
Configuration controls, paid unit labels, base/Supply/time and individual
actor role/HP are readable. Clean captures hide harness debug controls,
title and diagnostics; Unity's Development Build watermark remains.
Crowded friendly actors may overlap labels near battle end. These are
developer placeholders, not approved production UI/artwork.

## Supplementary orientation investigation: limited result

The committed project allows only landscape left/right, with AutoRotation;
the APK manifest contains USER_LANDSCAPE. Actual initial gameplay ran with
Android rotation1 (90 degrees), established by rotation1.txt and native captures.

`shell settings put system accelerometer_rotation 0` plus `user_rotation 3`
changed the user preference but did not rotate the active Unity player.
After enabling `accelerometer_rotation 1`, these emulator console commands
were tried with2–3s settling time:

```
emu sensor set acceleration -9.81:0:0
emu sensor set acceleration-uncalibrated -9.81:0:0:0:0:0
emu sensor set orientation 0:0:90
```

Android proposed rotation3, while the running activity stayed LANDSCAPE/1.
`sensor get gravity` returned unknown sensor; the failed diagnostic is not
used as proof. `dumpsys sensorservice` is retained as sensor-service.txt.
The application did not follow live sensor changes in this emulator run.

After saving PID8485 logs, `shell am force-stop com.example.onelanewar.dev`
and a fresh `am start -W ... --ez olwProof false` (exit0) loaded reverse
landscape, rotation3. rotation-relaunch.txt and landscape-right-verified.png
prove the reversed orientation and rendered gameplay. Switching sensors to
positive9.81/roll-90 did not change the active orientation; therefore
landscape-left-verified.png's provisional filename is **not proof of left**
(its paired dumpsys still says3). A second cold launch selected LANDSCAPE/1
(rotation-left-cold.txt), but its screenshot was taken before scene painting
and is retained as a dark/premature capture, not gameplay proof. The original
left-landscape gameplay captures already prove rendering in that orientation.

Result: both landscape orientations load on separate cold launches. Live
180-degree switching is NOT PROVEN here; no claim of passing that interaction.
No code or T001 pin was changed to hide this supplementary observation.
Unity documents the User/Sensor preference distinction at
[Android Player settings](https://docs.unity.com/en-us/engine/6000.0/manual/platform-specific/android/getting-started/class-player-settings).
That documentation does not establish the cause of this emulator observation.

## Shutdown

After collecting captures/logs, `emu kill` acknowledged shutdown of only5556.
The original5554 remained available. emulator-stop.txt records the immediate
readback (5556 can appear briefly while shutdown completes). Install remains
on the dedicated local AVD for review; no store publication or phone testing.
