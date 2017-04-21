@echo off

for /R %1 %%i in (*.*) do echo %%i %%~pi %%~ni %%~xi

pause > nul