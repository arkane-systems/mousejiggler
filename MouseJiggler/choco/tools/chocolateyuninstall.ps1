$ErrorActionPreference = 'Stop'

$installDir = 'C:\ProgramData\mousejiggler'

# Detect system architecture for informational purposes
$arch = [System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture
$archString = switch ($arch) {
    'X64' { 'x64' }
    'Arm64' { 'arm64' }
    default { 'unknown architecture' }
}

Write-Host "Uninstalling Mouse Jiggler ($archString)" -ForegroundColor Cyan

# Remove the command-line shim
Write-Host "Removing command-line shim" -ForegroundColor Cyan
Uninstall-BinFile -Name "mousejiggler"

# Remove Start Menu shortcut
$startMenuDir = "$env:APPDATA\Microsoft\Windows\Start Menu\Programs"
$shortcutPath = Join-Path $startMenuDir "Mouse Jiggler.lnk"
if (Test-Path $shortcutPath) {
    Remove-Item $shortcutPath -Force -ErrorAction SilentlyContinue
    Write-Host "Removed Start Menu shortcut" -ForegroundColor Cyan
}

# Remove installation directory
if (Test-Path $installDir) {
    Remove-Item $installDir -Recurse -Force -ErrorAction SilentlyContinue
    Write-Host "Removed installation directory: $installDir" -ForegroundColor Cyan
}

Write-Host "Mouse Jiggler has been uninstalled" -ForegroundColor Green
