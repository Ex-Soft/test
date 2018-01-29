@echo off

set DE_VERSION=17.2
set PATH_2_DE=c:\Program Files (x86)\DevExpress %DE_VERSION%\Components\Bin\Framework

if not exist "%PATH_2_DE%" goto no_de
7za a "%~dp0de" @de.lst
goto end

:no_de
echo.
echo "%PATH_2_DE%" doesn't exist
echo.
goto end

:end
