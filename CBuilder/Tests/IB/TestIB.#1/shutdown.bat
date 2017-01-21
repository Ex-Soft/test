@echo off
set ib_server=localhost
set src_path=e:\Soft.src\CBuilder\Tests\IB\TestIB.#1\
set gfix_path=c:\program files\firebird\bin\
set user_name=sysdba
set pwd=masterkey
set database=Test
set databaseext=.gdb

echo "%gfix_path%gfix.exe" -shut -at 5 -user %user_name% -password %pwd% %ib_server%:%src_path%%database%%databaseext%
"%gfix_path%gfix.exe" -shut -at 5 -user %user_name% -password %pwd% %ib_server%:%src_path%%database%%databaseext%
if errorlevel 1 goto err
goto end

:err
pause
goto end

:end