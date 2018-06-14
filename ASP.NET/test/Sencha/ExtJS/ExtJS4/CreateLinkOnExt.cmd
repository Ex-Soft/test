@echo off

if -%1-==-- goto end
if -%2-==-- goto end

for /f "tokens=2 delims=[]" %%G in ('ver') do (set _version=%%G)
echo %_version%
for /f "tokens=2,3,4 delims=. " %%G in ('echo %_version%') do (set _major=%%G& set _minor=%%H& set _build=%%I) 

if %_major%==5 goto xp

set linkmaker=mklink
set opt=/d /j
goto create

:xp
set linkmaker="d:\Program Files\junction\junction.exe"
set opt=-s

:create
set src="..\..\..\..\..\..\..\JavaScript\Sencha\ExtJS\ExtJS4\ExtJS%2"
echo %linkmaker% %opt% %1 %src%
%linkmaker% %opt% %1 %src%

:end
