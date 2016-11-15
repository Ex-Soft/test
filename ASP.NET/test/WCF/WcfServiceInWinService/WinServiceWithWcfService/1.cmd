@echo on

set _InstallUtil_="%WINDIR%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe"
set _Service_="%~dp0bin\Debug\WinServiceWithWcfService.exe"

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

:no_param
echo.
echo Usage: 1 ^<on^|off^>
echo.
pause

:end