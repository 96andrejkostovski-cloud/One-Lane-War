param(
    [ValidateSet('Prepare','EditMode','PlayMode','Android','Desktop')][string]$Mode,
    [string]$Evidence = 'ImplementationEvidence/OLW-CORE-001/resume005',
    [string]$Label = ''
)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$editor = 'C:\Program Files\Unity\Hub\Editor\6000.3.21f1\Editor\Unity.exe'
if ((Get-Item -LiteralPath $editor).VersionInfo.ProductVersion -ne '6000.3.21f1_c02631ffc030') { throw 'T001 editor mismatch' }
$directory = Join-Path $root $Evidence
New-Item -ItemType Directory -Force $directory | Out-Null
if (!$Label) { $Label = $Mode.ToLowerInvariant() }
$log = Join-Path $directory ($Label + '.log')
$receipt = Join-Path $directory ($Label + '-command.txt')
$arguments = '-batchmode -projectPath "' + $root + '" -logFile "' + $log + '"'
if ($Mode -in @('EditMode','PlayMode')) {
    $arguments += ' -runTests -testPlatform ' + $Mode + ' -testResults "' + (Join-Path $directory ($Label + '.xml')) + '"'
} else {
    $arguments += ' -quit -executeMethod OneLaneWar.Editor.BuildTools.' + $Mode
}
@(('UTC=' + [DateTime]::UtcNow.ToString('o')), ('HEAD=' + (git -C $root rev-parse HEAD)), ('COMMAND=' + $editor + ' ' + $arguments)) | Set-Content $receipt
git -C $root status --short | Add-Content $receipt
$process = Start-Process -FilePath $editor -ArgumentList $arguments -WindowStyle Hidden -PassThru
"PID=$($process.Id)" | Tee-Object -FilePath $receipt -Append
$process.WaitForExit()
"EXIT=$($process.ExitCode)" | Tee-Object -FilePath $receipt -Append
exit $process.ExitCode
