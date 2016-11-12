@echo off

if -%1-==-- goto help
if -%2-==-- goto help
if -%3-==-- goto help

set src_drive=%1
set dest_drive=%2

set base_dir=soft.src

set src="%src_drive%:\%base_dir%\%3"
set dest="%dest_drive%:\%base_dir%\%3"
set diff="d:\temp\diff_%1_%2_%3"

if %3==html goto cc_base_dir
if %3==sql goto cc_base_dir
if %3==vb goto cc_base_dir
if %3==pics goto cc_base_dir
if %3==js goto cc_base_dir
if %3==cmd goto cc_base_dir

set src="%src_drive%:\%base_dir%\%3\test"
set dest="%dest_drive%:\%base_dir%\%3\test"

:cc_base_dir

if %3==html goto cc_without_ini
if %3==vb goto cc_without_ini
if %3==pics goto cc_without_ini
if %3==js goto cc_without_ini
if %3==cmd goto cc_without_ini

set ini_file="cc_%3.ini"

:cc_without_ini

echo call "%~dp0sync_base" %src% %dest% %diff% %ini_file%
call "%~dp0sync_base" %src% %dest% %diff% %ini_file%

set diff="d:\temp\diff_%2_%1_%3"
echo call "%~dp0sync_base" %dest% %src% %diff% %ini_file%
call "%~dp0sync_base" %dest% %src% %diff% %ini_file%

goto end

:help
echo.
echo Usage: sync ^<source_drive^> ^<destination_drive^> ^<language^>
echo.
pause > nul
goto end

:end
