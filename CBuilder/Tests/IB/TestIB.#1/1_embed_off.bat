@echo off
if exist gds32.dll del /q gds32.dll
if exist firebird.msg del /q firebird.msg
if exist icudt30.dll del /q icudt30.dll
if exist icuin30.dll del /q icuin30.dll
if exist icuuc30.dll del /q icuuc30.dll
if exist intl\nul rd /s /q intl
rem pause