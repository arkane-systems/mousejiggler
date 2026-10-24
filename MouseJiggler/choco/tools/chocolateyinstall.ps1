$ErrorActionPreference = 'Stop'

$packageName = 'mouse-jiggler'
$installDir = 'C:\ProgramData\mousejiggler'
$checksumType = 'sha256'

# Detect system architecture
$arch = [System.Runtime.InteropServices.RuntimeInformation]::OSArchitecture
$archString = switch ($arch) {
    'X64' { 'x64' }
    'Arm64' { 'arm64' }
    default { throw "Unsupported architecture: $arch. Mouse Jiggler requires x64 or arm64." }
}

Write-Host "Detected system architecture: $archString" -ForegroundColor Cyan

# Set download URL and checksum based on architecture
$url = "https://github.com/arkane-systems/mousejiggler/releases/download/3.1.0/MouseJiggler-mainline-$archString.zip"

# Checksums for release binaries - update these with actual values from the release
$checksums = @{
    'x64' = '4cb8a8134fb3e94afcc535cbae1bd0619d274789d8ab032f6a64ce85e63e807f'
    'arm64' = '199d0904dec8ca4e8905be837dfe9044236993910fc712ffbb4dc828a6a70386'
}

$checksum = $checksums[$archString]

# Create installation directory
if (!(Test-Path $installDir)) {
    New-Item -ItemType Directory -Path $installDir -Force | Out-Null
}

# Download the release
$downloadPath = Join-Path $env:TEMP "$packageName-$archString-$($env:chocolateyPackageVersion).zip"
Write-Host "Downloading Mouse Jiggler ($archString) from $url" -ForegroundColor Cyan

Get-ChocolateyWebFile -PackageName $packageName `
                      -FileFullPath $downloadPath `
                      -Url $url `
                      -ChecksumType $checksumType `
                      -Checksum $checksum

# Extract to installation directory
Write-Host "Extracting files to $installDir" -ForegroundColor Cyan
Get-ChocolateyUnzip -FileFullPath $downloadPath `
                    -Destination $installDir

# Remove the downloaded zip
Remove-Item $downloadPath -ErrorAction SilentlyContinue

Write-Host "Mouse Jiggler ($archString) has been installed to $installDir" -ForegroundColor Green

# Create command-line shim using Chocolatey's built-in shim generator
Write-Host "Creating command-line shim" -ForegroundColor Cyan
$exePath = Join-Path $installDir "MouseJiggler.exe"
Install-BinFile -Name "mousejiggler" -Path $exePath

Write-Host "Command-line shim 'mousejiggler' is now available in PATH" -ForegroundColor Green

# Create Start Menu shortcut
$startMenuDir = "$env:APPDATA\Microsoft\Windows\Start Menu\Programs"
$shortcutPath = Join-Path $startMenuDir "Mouse Jiggler.lnk"

Write-Host "Creating Start Menu shortcut" -ForegroundColor Cyan
Install-ChocolateyShortcut -ShortcutFilePath $shortcutPath `
                           -TargetPath $exePath `
                           -WorkingDirectory $installDir `
                           -Description "Mouse Jiggler - Prevent screensaver activation" `
                           -IconLocation $exePath

Write-Host "A Start Menu shortcut has been created" -ForegroundColor Green

