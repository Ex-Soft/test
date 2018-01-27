@echo off

set PARAM=%1

if -%PARAM%-==-- set PARAM=5

set APP=%~dp0bin\Debug\TestAsyncAwaitConApp.exe
if not exist %APP% goto end

%APP% %PARAM%

if errorlevel 5 echo errorlevel 5
if errorlevel 4 echo errorlevel 4
if errorlevel 3 echo errorlevel 3
if errorlevel 2 echo errorlevel 2
if errorlevel 1 echo errorlevel 1
if errorlevel 0 echo errorlevel 0

:end
