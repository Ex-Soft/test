@echo off

set mainbatvar=mainbatvar

echo main.bat before
echo %mainbatvar%
call child.bat
echo main.bat after
echo %mainbatvar%
echo %childbatvar%

pause > nul