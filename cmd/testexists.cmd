@echo off
cls

set src="C:\Program Files\Internet Explorer"

if exist %src% echo %src% exist
if not exist %src% echo %src% !exist

set src="C:\Program Files\Internet Explorer"\nul

if exist %src% echo %src% exist
if not exist %src% echo %src% !exist

set src="C:\Program Files\Internet Explorer\nul"

if exist %src% echo %src% exist
if not exist %src% echo %src% !exist

pause>nul