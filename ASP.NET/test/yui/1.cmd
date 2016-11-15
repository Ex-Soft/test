@echo off

if -%1-==-- goto help
if -%2-==-- goto help

d:\arc\7za.exe a -r -mx9 -x@yui.lst "%1" "%2"

goto end

:help
echo.
echo Usage: 1.bat ^<archive_name^> ^<directory^>
echo.
pause > nul
goto end

:end