@echo off

echo child.cmd

echo %mainbatvar%
set mainbatvar=mainbatvarfromchild
echo %mainbatvar%

set childbatvar=childbatvar
echo %childbatvar%