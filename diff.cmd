@echo off
for %%a in (%2) do (set ext=%%~xa) 
set arc_path=d:\arc
if %ext%==.rar set arc=rar.exe
if %ext%==.7z set arc=7za.exe
set arc_full=%arc_path%\%arc%
set dir_tmp=d:\temp
set arc_name=%dir_tmp%\%2
set dir_dest=%dir_tmp%\%1

if not -%5-==-- goto cc

if exist %dir_dest%\nul rd /s /q %dir_dest%
if not exist %arc_name% goto end
if %ext%==.rar %arc_full% x -v -y %arc_name% %dir_dest%\
if %ext%==.7z %arc_full% x %arc_name% -o%dir_dest%
if errorlevel 1 goto end

:cc
set dir_diff=%dir_tmp%\diff
if exist %dir_diff%\nul rd /s /q %dir_diff%
call cc %dir_dest%\test %3 %dir_diff% %4

:end
