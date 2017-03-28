@echo off

set mainbatvar=mainbatvarvalue

echo main.cmd before
echo mainbatvar = %mainbatvar%
echo.
call child.cmd
echo.
echo main.cmd after
echo mainbatvar = %mainbatvar%
echo childbatvar = %childbatvar%

pause > nul