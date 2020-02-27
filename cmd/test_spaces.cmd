@echo off
cls
set src=1st 2nd 3rd

echo.
echo %src%
echo.

echo.
echo "%src% blah-blah-blah"
echo.

set src="1st 2nd 3rd"
echo.
echo %src%
echo.

set src=anytest.cmd
for %%a in (%src%) do if %%~za gtr 0 echo %%a length: %%~za
for %%a in (%src%) do if %%~za gtr 0 (echo copy %%a blah-blah-blah.txt & copy %%a blah-blah-blah.txt > nul)
