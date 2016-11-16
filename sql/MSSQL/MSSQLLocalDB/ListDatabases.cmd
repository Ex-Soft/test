@echo off

if -%1-==-- goto help

sqlcmd -S "(localdb)\%1" -E -i ListDatabases.sql -o ListDatabases%1.txt
if errorlevel 1 goto wait
goto end

:wait
pause > nul
goto end

:help
echo.
echo Usage: ListDatabases ^<instance-name^>
echo.
goto end

:end