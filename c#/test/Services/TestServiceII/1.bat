@echo off
if -%1-==-- goto no_param
if %1==on goto on_on
if %1==off goto off_off
goto no_param

:on_on
"%WINDIR%\Microsoft.NET\Framework\v1.1.4322\InstallUtil.exe" "E:\Soft.src\C#\Test\System\TestService\bin\Debug\TestService.exe"
goto end

:off_off
"%WINDIR%\Microsoft.NET\Framework\v1.1.4322\InstallUtil.exe" /u "E:\Soft.src\C#\Test\System\TestService\bin\Debug\TestService.exe"
goto end

:no_param
echo.
echo Usage: 1 ^<on^|off^>
echo.
pause

:end