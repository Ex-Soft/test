for /f "tokens=2 delims=[]" %%g in ('ver') do (set _version=%%g)

for /f "tokens=* delims=. " %%g in ('echo %_version%') do @echo %%g
for /f "tokens=2,3,4 delims=. " %%g in ('echo %_version%') do @echo %%g

for /f "tokens=*" %%g in ("html sql asp.net c#") do @echo %%g

for %%i in (html sql asp.net c#) do echo %%i

pause > nul