echo off

if -%1-==-- goto help
if -%2-==-- goto help
if -%3-==-- goto help

set dir_src=%1
set dir_dest=%2
set dir_diff=%3
set ini_file=%4

if not exist %dir_src% goto dir_src_doesnt_exist
if not exist %dir_dest% goto dir_dest_doesnt_exist
if exist %dir_diff% rd /s /q %dir_diff%

if -%ini_file%-==-- goto without_ini
echo cc %dir_src% %dir_dest% %dir_diff% -ini:%ini_file%
cc %dir_src% %dir_dest% %dir_diff% -ini:%ini_file%
goto end

:without_ini
echo cc %dir_src% %dir_dest% %dir_diff%
cc %dir_src% %dir_dest% %dir_diff%
goto end

:help
echo.
echo Usage: sync_base ^<source_directory^> ^<destination_directory^> ^<diff_directory^> [ini_file]
echo.
goto end

:dir_src_doesnt_exist
echo.
echo %dir_src% doesn't exist
echo.
pause > nul
goto end

:dir_dest_doesnt_exist
echo.
echo %dir_dest% doesn't exist
echo.
pause > nul
goto end

:end
