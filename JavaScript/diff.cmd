@echo off
set lng=javascript
set src=test_js.rar
set dest="%~dp0test"
call ..\diff.cmd %lng% %src% %dest%