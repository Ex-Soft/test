@echo off
set lng=vc
set src=test_vc.7z
set dest="%~dp0test"
call ..\diff.cmd %lng% %src% %dest% -ini:cc_vc.ini