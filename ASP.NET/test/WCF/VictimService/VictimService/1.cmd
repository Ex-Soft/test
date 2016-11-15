@echo off

set _InstallUtilExe_=InstallUtil.exe
set _InstallUtil_="%WINDIR%\Microsoft.NET\Framework\v4.0.30319\%_InstallUtilExe_%"
if exist %_InstallUtil_% goto checkExe
set _InstallUtil_="%WINDIR%\Microsoft.NET\Framework\v2.0.50727\%_InstallUtilExe_%"
if not exist %_InstallUtil_% goto noInstallUtil

:checkExe
set _Exe_=VictimService.exe
set _Service_="%~dp0bin\Debug\%_Exe_%"
if exist %_Service_% goto checkParam
set _Service_="%~dp0%_Exe_%"
if not exist %_Service_% goto noService

:checkParam
if -%1-==-- goto no_param
if %1==on goto on_on
if %1==off goto off_off
goto no_param

:on_on
%_InstallUtil_% %_Service_%
goto end

:off_off
%_InstallUtil_% /u %_Service_%
goto end

:noInstallUtil
echo.
echo %_InstallUtil_% doesn't exist
echo.
pause > nul
goto end

:noService
echo.
echo %_Service_% doesn't exist
echo.
pause > nul
goto end

:no_param
echo.
echo Usage: 1 ^<on^|off^>
echo.
pause > nul
goto end

:end
