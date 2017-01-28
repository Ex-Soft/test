@echo off
set SQL_FILE=Test_TestDBCCLogprint
set SRV_NAME=DEVELOPER1

d:
cd \My_Doc\Work\PowerD~1\SQL\testdb

if not exist %SYBASE%\%SYBASE_OCS%\bin\isql.exe goto no_isql
if not exist %SQL_FILE%.sql goto no_sql

set CDATE=A
goto DoDo

date /t >%~n0.tmp
rem !!!Achtung!!!!
rem 4 Win98/ME/W2K
rem for /F "tokens=2*" %%i in (%~n0.tmp) do set CDATE=%%i
rem 4 W2K3
rem for /F "tokens=1*" %%i in (%~n0.tmp) do set CDATE=%%i

for /F "tokens=2*" %%i in (%~n0.tmp) do set CDATE=%%i

del %~n0.tmp
time /t >%~n1.tmp
for /F %%j in (%~n1.tmp) do set CDATE1=%%j
del %~n1.tmp
set CDATE=%CDATE:~6,5%_%CDATE:~3,2%_%CDATE:~0,2%_%CDATE1:~0,2%_%CDATE1:~3,5%

echo %SQL_FILE%_%CDATE%.log
pause

:DoDo

echo %SYBASE%\%SYBASE_OCS%\bin\isql.exe -S%SRV_NAME% -Usa -P -i%SQL_FILE%.sql -o%SQL_FILE%_%CDATE%.log
%SYBASE%\%SYBASE_OCS%\bin\isql.exe -S%SRV_NAME% -Usa -P -i%SQL_FILE%.sql -o%SQL_FILE%_%CDATE%.log

goto end

:no_isql
echo.
echo File %SYBASE%\%SYBASE_OCS%\bin\isql.exe doesn't exist
echo.
pause > nul
goto end

:no_sql
echo.
echo File %SQL_FILE%.sql doesn't exist
echo.
pause > nul
goto end

:end
