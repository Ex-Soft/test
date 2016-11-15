@echo on

if -%1-==-- goto noParam

set srcPath=d:\temp\testMVC\lesson%1
if not exist "%srcPath%" goto noSrc
set diffPath=d:\temp\testMVC\diff%1
if not exist "%diffPath%" goto callCC
rd /s /q "%diffPath%"
if errorlevel 1 goto rdError

:callCC
call cc "%srcPath%" "%~dp0*.*" "%diffPath%" -ini:"%~dp0diff.ini"

goto end

:rdError
echo.
echo Can't delete "%diffPath%"
echo.
pause > nul
goto end

:noSrc
echo.
echo "%srcPath%" doesn't exist
echo.
pause > nul
goto end

:noParam
echo.
echo Usage: diff ^<lessonNo^>
echo.
pause > nul
goto end

:end