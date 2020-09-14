<<<<<<< HEAD
@echo off
cd /D "%~dp0"
if not exist "%ProgramFiles(x86)%" (
  set "ProgramFiles(x86)=%ProgramFiles%"
)
set "VSWhere=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
=======
>>>>>>> 6c8311c... Create build.bat
echo Looking for MSBuild
for /f "usebackq delims=" %%i in (`^""%VSWhere%" -latest -prerelease -version "[16.0,17.0)" -products * -requires "Microsoft.Component.MSBuild" -property "installationPath"^"`) do (
  set InstallDir=%%i
)
<<<<<<< HEAD
set "MSBuild=%InstallDir%\MSBuild\Current\Bin\MSBuild.exe"
if not exist "%MSBuild%" (
  echo MSBuild not found. Please make sure Visual Studio 16.0+ is installed.
  pause
  goto:eof
)
echo Building TextEdit.sln
"%MSBuild%" TextEdit.sln /nologo /maxcpucount /nodeReuse:false /verbosity:minimal /t:Restore;Build
start "TextEdit" bin\Debug\TextEdit.exe
=======

set "MSBuild=%InstallDir%\MSBuild\Current\Bin\MSBuild.exe"

if not exist "%MSBuild%" (
  echo MSBuild not found. Please make sure Visual Studio 2019 16.0+ is installed.
  pause
  goto:eof
)

echo Building TextEdit.sln
"%MSBuild%" TextEdit.sln
start "TextEdit" "TextEdit.exe"
>>>>>>> 6c8311c... Create build.bat
