param([string]$ToolEditor = 'C:\Program Files\Unity\Hub\Editor\6000.3.21f1')
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$out = Join-Path $root 'Temp\PureTests'
New-Item -ItemType Directory -Force $out | Out-Null
$mono = Join-Path $ToolEditor 'Editor\Data\MonoBleedingEdge\bin\mono.exe'
$csc = Join-Path $ToolEditor 'Editor\Data\MonoBleedingEdge\lib\mono\4.5\csc.exe'
$json = Join-Path $ToolEditor 'Editor\Data\Managed\Newtonsoft.Json.dll'
$netstandard = Join-Path $ToolEditor 'Editor\Data\MonoBleedingEdge\lib\mono\4.5\Facades\netstandard.dll'
Write-Output "Pure C# compiler/runtime only. NOT Unity/T001 editor proof. ToolEditor=$ToolEditor"
Write-Output ('UTC=' + [DateTime]::UtcNow.ToString('o'))
Write-Output ('TESTED_HEAD=' + (git -C $root rev-parse HEAD))
git -C $root status --short
& $mono --version
Get-FileHash $mono,$csc,$json -Algorithm SHA256 | Format-List
$files = @(Get-ChildItem (Join-Path $root 'Assets\OneLaneWar\Core') -Filter *.cs | ForEach-Object FullName)
$files += Join-Path $root 'Assets\OneLaneWar\Tests\Fixtures\ModelFixtures.cs'
$files += Join-Path $PSScriptRoot 'PureTestRunner.cs'
& $mono $csc /nologo /checked+ /langversion:8 /target:exe "/out:$out\OneLaneWar.PureTests.exe" "/reference:$json" "/reference:$netstandard" $files
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
Copy-Item -LiteralPath $json -Destination $out
Get-FileHash (Join-Path $out 'OneLaneWar.PureTests.exe') -Algorithm SHA256 | Format-List
& $mono (Join-Path $out 'OneLaneWar.PureTests.exe') (Join-Path $root 'One_Lane_War_Codex_Source_v1.0.0')
exit $LASTEXITCODE
