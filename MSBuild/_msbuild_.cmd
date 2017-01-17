@echo off

set full_path_2_app="c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
if exist %full_path_2_app% goto DoIt

set full_path_2_app="c:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"
if exist %full_path_2_app% goto DoIt

goto err

:DoIt
echo %full_path_2_app% %1 %2 %3 %4 %5 %6 %7 %8 %9
%full_path_2_app% %1 %2 %3 %4 %5 %6 %7 %8 %9
goto end

:err
echo.
echo msbuild.exe doesn't exist
echo.
goto end

:end
