@echo off

if -%1-==-- goto help
if -%2-==-- goto help

7za.exe a -r -mx9 -xr@typescript.lst "%1" "%2"

goto end

:help
echo.
echo Usage: 1 ^<archive_name^> ^<directory^>
echo.
pause > nul
goto end

:end