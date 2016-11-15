@echo off

set BIN_NAME=bin
set WEB_APP_NAME=Calc
rem set CSC=c:\winnt\micros~1.net\framew~1\v11~1.432\csc
set CSC=c:\windows\micros~1.net\framew~1\v11~1.432\csc.exe

if not exist %BIN_NAME% md %BIN_NAME%
if not exist %BIN_NAME% goto no_dir

if not exist %CSC% goto no_csc
%CSC% /target:library %WEB_APP_NAME%.cs
if errorlevel 1 goto c_error
if exist %WEB_APP_NAME%.dll move /y %WEB_APP_NAME%.dll bin\%WEB_APP_NAME%.dll
goto end

:no_dir
echo.
echo Can't create %BIN_NAME%
echo.
pause > nul
goto end

:no_csc
echo.
echo %CSC% doesn't exist
echo.
pause > nul
goto end

:c_error
echo.
echo Compiler error
echo.
pause > nul
goto end

:end