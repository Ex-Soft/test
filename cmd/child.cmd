@echo off

echo child.cmd starting...

echo mainbatvar = %mainbatvar%
set mainbatvar=mainbatvarfromchildvalue
echo mainbatvar = %mainbatvar%

set childbatvar=childbatvarvalue
echo childbatvar = %childbatvar%

echo child.cmd finished
