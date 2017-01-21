@echo off

if exist AnyTest.mak del AnyTest.mak
bpr2mak AnyTest.bpr
if errorlevel 1 goto error

if not exist AnyTest.mak goto error
if not exist obj\nul md obj
echo y|del obj\*.* > nul
if exist AnyTest.exe del AnyTest.exe
make -fAnyTest.mak
if errorlevel 1 goto error
goto end

:error
echo.
echo Error!!!
echo.
pause

:end