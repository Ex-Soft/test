@echo off
set lng=c#
set src=test_cs.7z
set dest="%~dp0test"
call ..\diff.cmd %lng% %src% %dest% -ini:cc_c#.ini