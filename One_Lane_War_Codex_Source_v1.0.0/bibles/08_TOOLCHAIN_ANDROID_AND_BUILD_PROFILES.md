# Bible 08 — Toolchain, Android and Build Profiles

**Authority:** T001 is a selected version set. `data/toolchain_lock.json` is the exact table. Joint compatibility is NOT_BUILT. Version selection is not reopened as an owner question; a demonstrated conflict requires a numbered amendment.

## 8.1 Selection and sequencing

Use Unity **6000.3.21f1**, changeset `c02631ffc030`. Use its Android module and compatible bundled tooling. Android minimum/compile/target are **28/36/36**, IL2CPP, production **arm64-v8a**, OpenGL ES 3, built-in 2D and landscape-left/right only. The locked build tools are 36.0.0, NDK r27c / 27.2.12479018, Gradle 9.1.0, Android Gradle Plugin 9.0.0 and editor-bundled OpenJDK 17. Never substitute Android Studio's JBR casually. Capture the actual Java patch and binary hash during proof rather than inventing a separate patch here. [EXT01–EXT03]

The selected editor provides the editor-bound uGUI/Test Framework versions. Record the actual manifest and lock. Input System is 1.20.0 and Newtonsoft JSON 3.2.2. PH01 installs only what is needed for a clean offline project, import and tests. The selected commercial SDKs are reserved for PH05: Unity IAP 5.4.3 / Billing 9.0.0, Firebase Unity 13.17.0 / C++ 13.13.0 / Android BoM 34.19.0, one EDM4U 1.2.189, Google Mobile Ads Unity 11.5.0 / Android 25.4.0, and UMP 4.0.0. This corrects earlier instructions to force every SDK into the first placeholder foundation. [EXT04–EXT07]

Do not enable mediation, next-generation GMA, Unity Analytics, Unity D2C, a web shop, Firebase Auth/Firestore client/FCM/AI, or remote catalogues. Review the IAP package's own telemetry rather than assuming absence of Unity Analytics means absence of Unity data collection. Preserve a single dependency resolver.

## 8.2 Local tooling evidence

Android Studio is Quail 4 / 2026.1.4 Patch 1; the selected Emulator is 37.1.11. Host hardware, OS, virtualization and system images are not supplied by this package. Codex must inventory the actual workstation first. If a required executable or licensed editor is missing, report the exact requirement, detection command and blocked task. Do not manufacture an APK, emulator screenshot or test pass from source inspection. [EXT08–EXT09]

Record editor path/version/changeset; Unity licence availability without copying a licence secret; Android SDK package revisions; NDK source properties; Java version/hash; device/emulator list; ABI support; graphics mode; disk availability; and repository baseline. Record the commands and exit codes. The owner’s aggregate Unity licence eligibility is a separate business check, not an assumption based on this game's current revenue. [EXT30]

Use bounded installation requests only within the execution permissions of the issued task. This handoff does not authorize buying a Unity licence, provisioning paid cloud machines or changing another project's tools. Avoid machine-global changes when project-local/bundled tooling is available.

## 8.3 Android ABI and emulator reality

The primary development environment is Android Studio Emulator. Do not equate an x86_64 AVD with automatic ARM64 library support. Unity's x86_64 Android restriction and the particular system image's translation support must be checked. Google documents ARM translation for particular Android 11 images; that is not a blanket guarantee across newer/custom images, hosts, or every IL2CPP/SDK binary. [EXT09–EXT10]

Capture `adb shell getprop ro.product.cpu.abilist`, the system-image revision/fingerprint and actual native library load. The matrix includes API 28, 30 fallback, 33, 36 and a 16 KB environment. Mark incompatible rows **BLOCKED**, not PASS or silently removed. Do not disguise a new phone game as Magic Leap to access a restricted target. A compatible ARM64 device/image may be needed for a blocked row. That evidence is distinct from the owner's emulator-first development choice.

At least one actual ARM64 Android phone must receive a Play-installed release-candidate smoke test before publication. No new hardware purchase is authorized. Emulation can prove many OS/UI behaviors but does not establish real touch feel, heat, sustained battery use, haptics or every device driver interaction.

## 8.4 Build profiles

**Local development:** development identifier, Development Build on when useful, debug logging without secrets, test fixtures, fake/unavailable services, no real purchases or production analytics. Save data uses a development sandbox. Automated capture records whether the scene is a diagnostic fixture.

**Internal integration:** real SDKs configured against explicitly approved test identities, test ad units or registered test devices, licence-testing Google accounts, separate diagnostics environment, production-like IL2CPP stripping and signing path. A Play testing track by itself does not make purchases free; licence testers and actual test purchase dialogs must be verified. [EXT12]

**Release candidate:** final production identifier, Development Build and Script Debugging off, no debug entry points, ARM64 IL2CPP, conservative managed stripping initially, audited permissions, actual production service mapping, symbols/mapping retained, test credentials/fixtures disabled. Use LZ4HC where applicable and verify real download size rather than equating source ZIP size with the delivered app. Debug overlays may not be hidden only by an easily reachable menu flag.

Managed stripping, engine stripping, reflection and SDK/linker preservation must be tested together. Do not enable aggressive stripping simply to hit a size target. A symbolicated test crash and successful purchase/ad flow in a production-like build are stronger evidence than a debug-editor success.

## 8.5 Manifest and native compliance

Inspect the merged Android manifest, exported components, network-security configuration, permissions, billing dependency, advertising settings, backup/device-transfer exclusions and installed application ID. HTTPS is required for custom service calls. No certificate pinning at launch. Disable unnecessary exported components and cleartext traffic, subject to legitimate SDK requirements verified at integration.

Every native library in the shipped bundle participates in page-size compatibility, not just Unity's own library. Check ELF alignment, packaging and a suitable runtime environment. A selected NDK/editor does not prove third-party binaries comply. Inspect the actual AAB-generated APKs and Play pre-launch findings. API 36 is the project's target and matches the published requirement checked for this source; recheck the rule at real submission. [EXT11, EXT17]

## 8.6 Performance evidence

Targets are 60 FPS on the primary mid-range phone, stable 30 FPS fallback on the agreed lower tier, unchanged 20 Hz simulation, under 500 MiB steady-state process memory and under 150 MiB delivered download. Cold-start targets are four seconds mid-range/seven seconds low tier; warm Home-to-battle two seconds. These are internal goals and all remain unmeasured.

Measure frame-time percentiles, not just average FPS; cold/warm launches, repeated scene loads, 20-minute play, 24-vs-24 density, effects, ads and background cycles. Enable optimized frame pacing where supported and verify it. No background simulation or progression. No game-owned wake lock. Inspect SDK behavior separately. A no-growth memory result requires repeated measurements after comparable loads and garbage collection conditions, not one screenshot.

## 8.7 Reproducibility and amendments

A reproducible release record includes source commit, source manifest hash, editor/module identity, package/native locks, settings/build profile, imported asset hashes, environment mapping, versionCode, symbols and resulting AAB hash. A byte-identical rebuild is a separate reproducibility property affected by signing/timestamps; do not claim it merely because both builds launch.

On incompatibility preserve the failed dependency graph/log and minimal reproduction, identify the narrow affected pin, propose T002 with primary-source justification, run the relevant regressions, and obtain the required task/director approval. Do not quietly use 'latest'. Conversely, a security or store requirement may require an amendment; source lock is not permission to ship an obsolete or vulnerable dependency.
