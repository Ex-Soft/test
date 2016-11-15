@echo off
set lng=c#
set ext=7z
set src=test_%lng%.%ext%
set dest="%~dp0test"
call ..\diff.cmd %lng% %src% %dest% -ini:cc_%lng%.ini %1