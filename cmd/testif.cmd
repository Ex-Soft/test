@echo off
cls

if -%1-==-- set str=empty
if not -%1-==-- set str="!empty: %1"

echo.
echo %str%
echo.

pause>nul