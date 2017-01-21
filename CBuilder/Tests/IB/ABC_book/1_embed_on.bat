@echo off
if not exist embedded\nul goto end
if exist embedded\gds32.dll copy /y embedded\gds32.dll gds32.dll
if exist embedded\firebird.msg copy /y embedded\firebird.msg firebird.msg
if exist embedded\icudt30.dll copy /y embedded\icudt30.dll icudt30.dll
if exist embedded\icuin30.dll copy /y embedded\icuin30.dll icuin30.dll
if exist embedded\icuuc30.dll copy /y embedded\icuuc30.dll icuuc30.dll
if not exist embedded\intl\nul goto end
xcopy embedded\intl\*.* intl /S /I /F /H /R /Y
:end
rem pause