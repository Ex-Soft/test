@echo off

set ib_server=localhost
set src_path=e:\Soft.src\CBuilder\Tests\IB\TestIB.#1\
set dest_path=e:\Soft.src\CBuilder\Tests\IB\TestIB.#1\bak\
set gbak_path=c:\program files\firebird\bin\
set user_name=sysdba
set pwd=masterkey

set database=Test
set databaseext=.gdb
if exist %dest_path%%database%.log del /q %dest_path%%database%.log
if exist %dest_path%%database%.gbk del /q %dest_path%%database%.gbk
echo "%gbak_path%gbak.exe" -b -user %user_name% -password %pwd% -v -z -y %dest_path%%database%.log %ib_server%:%src_path%%database%%databaseext% %dest_path%%database%.gbk
"%gbak_path%gbak.exe" -b -user %user_name% -password %pwd% -v -z -y %dest_path%%database%.log %ib_server%:%src_path%%database%%databaseext% %dest_path%%database%.gbk
