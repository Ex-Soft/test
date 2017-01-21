@echo off

set ib_server=localhost
set src_path=e:\Soft.src\CBuilder\Tests\IB\TestIB.#1\bak\
set dest_path=e:\Soft.src\CBuilder\Tests\IB\TestIB.#1\
set gbak_path=c:\program files\firebird\firebird_2_0\bin\
set user_name=sysdba
set pwd=masterkey

set database=Test
set databaseext=.gdb
set backupext=.gbk

if exist %dest_path%%database%.log del /q %dest_path%%database%.log
if errorlevel 1 goto end

if exist %dest_path%%database%%databaseext% del /q %dest_path%%database%%databaseext%
if errorlevel 1 goto end

echo "%gbak_path%gbak.exe" -r -user %user_name% -password %pwd% -v -y %dest_path%%database%.log %src_path%%database%%backupext% %ib_server%:%dest_path%%database%%databaseext%
"%gbak_path%gbak.exe" -r -user %user_name% -password %pwd% -v -y %dest_path%%database%.log %src_path%%database%%backupext% %ib_server%:%dest_path%%database%%databaseext%

:end