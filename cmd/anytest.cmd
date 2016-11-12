@echo off
cls
set src="anytest.cmd"

echo.
echo %src%
for %%a in (%src%) do echo %%~a

set src=anytest.cmd
echo.
echo %src%
echo.

echo.
echo dp0
echo %~dp0
echo.

echo.
echo fa
for %%a in (%src%) do echo %%~fa
echo.

echo.
echo da
for %%a in (%src%) do echo %%~da
echo.

echo.
echo pa
for %%a in (%src%) do echo %%~pa
echo.

echo.
echo na
for %%a in (%src%) do echo %%~na
echo.

echo.
echo xa
for %%a in (%src%) do echo %%~xa
echo.

for %%a in (%src%) do echo %%~sa
for %%a in (%src%) do echo %%~aa
for %%a in (%src%) do echo %%~ta
for %%a in (%src%) do echo %%~za

for /f "tokens=1,2 delims=." %%a in ("%src%") do (set file_name=%%a & set file_ext=%%b)
echo file_name %file_name%
echo file_ext %file_ext%

set src=4.0.7
for /f "tokens=1 delims=." %%a in ("%src%") do (set version=%%a)
echo %version%