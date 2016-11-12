@echo off

set mainbatvar=mainbatvar

echo main.cmd before
echo %mainbatvar%
child.cmd
echo main.cmd after
echo %mainbatvar%
echo %childbatvar%

pause > nul