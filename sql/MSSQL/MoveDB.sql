--create database testdb;
--alter database testdb set offline;

--select * from sys.databases
--select * from sys.database_files
--select * from sys.master_files
select * from sys.master_files where database_id = db_id(N'testdb') order by name

/*
alter database testdb modify file (name = testdb, filename = N'c:\db\mssql\testdb.mdf');
alter database testdb modify file (name = testdb_log, filename = N'c:\db\mssql\testdb_log.ldf');
*/

--alter database testdb set online;

--NT SERVICE\MSSQLSERVER
--NETWORK SERVICE

--create database testdb on (filename = N'd:\db\testdb.mdf'), (filename = 'd:\db\testdb_log.ldf') for attach;
--create database testlocaldb on (filename = N'd:\db\testlocaldb.mdf'), (filename = 'd:\db\testlocaldb_log.ldf') for attach;