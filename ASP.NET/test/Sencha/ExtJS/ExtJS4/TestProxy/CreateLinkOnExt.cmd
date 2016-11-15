@echo off
set dest="%~dp0ext%1"
call ..\CreateLinkOnExt.cmd %dest% %1
