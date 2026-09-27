$ErrorActionPreference = 'Continue'
$root = Split-Path $PSScriptRoot -Parent
$log = Join-Path $root 'ImplementationEvidence\OLW-CORE-001\logs\environment.txt'
& {
    'COMMAND: host and disk inventory'
    [System.Runtime.InteropServices.RuntimeInformation]::OSDescription
    [System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture
    Get-PSDrive C | Format-List Name,Used,Free
    'COMMAND: installed editor paths and binary identity'
    foreach ($editor in @('C:\Program Files\Unity\Hub\Editor\6000.3.21f1', 'C:\Program Files\Unity\Hub\Editor\6000.3.25f1', 'C:\Unity\Hub\Editor\6000.3.18f1')) {
        $exe = Join-Path $editor 'Editor\Unity.exe'
        "PATH=$exe EXISTS=$(Test-Path -LiteralPath $exe)"
        if (Test-Path -LiteralPath $exe) { (Get-Item -LiteralPath $exe).VersionInfo | Format-List FileVersion,ProductVersion }
        foreach ($relative in @('Editor\Data\PlaybackEngines\AndroidPlayer\OpenJDK\bin\java.exe', 'Editor\Data\PlaybackEngines\AndroidPlayer\NDK\source.properties', 'Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platforms\android-36\source.properties', 'Editor\Data\PlaybackEngines\AndroidPlayer\SDK\build-tools\36.0.0\source.properties')) {
            $path = Join-Path $editor $relative
            "PATH=$path EXISTS=$(Test-Path -LiteralPath $path)"
            if ($path.EndsWith('source.properties') -and (Test-Path -LiteralPath $path)) { Get-Content -LiteralPath $path }
        }
    }
    'License availability for exact editor: NOT_RUN; no license secrets read.'
    $sdk = Join-Path $env:LOCALAPPDATA 'Android\Sdk'
    $adb = Join-Path $sdk 'platform-tools\adb.exe'
    "COMMAND: $adb version"; & $adb version; "EXIT=$LASTEXITCODE"
    "COMMAND: $adb devices -l"; & $adb devices -l; "EXIT=$LASTEXITCODE"
    foreach ($property in @('ro.product.cpu.abilist','ro.build.fingerprint','ro.build.version.sdk','ro.dalvik.vm.native.bridge')) {
        "COMMAND: adb -s emulator-5554 shell getprop $property"; & $adb -s emulator-5554 shell getprop $property; "EXIT=$LASTEXITCODE"
    }
    'COMMAND: adb -s emulator-5554 shell getconf PAGE_SIZE'; & $adb -s emulator-5554 shell getconf PAGE_SIZE; "EXIT=$LASTEXITCODE"
    'COMMAND: adb -s emulator-5554 emu avd name'; & $adb -s emulator-5554 emu avd name; "EXIT=$LASTEXITCODE"
    Get-ChildItem (Join-Path $sdk 'system-images') -Recurse -Filter source.properties | ForEach-Object { $_.FullName; Get-Content -LiteralPath $_.FullName }
    'COMMAND: emulator -version'; & (Join-Path $sdk 'emulator\emulator.exe') -version; "EXIT=$LASTEXITCODE"
    'Actual native library load: NOT_RUN; no APK produced or installed by this task.'
} *> $log
Get-Content $log
