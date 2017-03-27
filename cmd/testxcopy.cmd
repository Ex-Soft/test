@echo on
set src=d:\temp\src
set dest=d:\temp\dest
xcopy %src% %dest% /d /s /i /y
pause > nul