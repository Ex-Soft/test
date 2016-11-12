@echo off
For /f "tokens=2 delims=[]" %%G in ('ver') Do (set _version=%%G)
echo %_version%
For /f "tokens=2,3,4 delims=. " %%G in ('echo %_version%') Do (set _major=%%G& set _minor=%%H& set _build=%%I) 

Echo Major version: %_major%  Minor Version: %_minor%.%_build%
pause > nul