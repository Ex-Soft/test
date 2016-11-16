--alter database [TestPlanogram] set offline;

--select * from sys.databases
--select * from sys.database_files
--select * from sys.master_files
select * from sys.master_files where database_id = db_id(N'TestPlanogram') order by name

/*
alter database [TestPlanogram] modify file (name = [TestPlanogram], filename = N'd:\db\TestPlanogram.mdf');
alter database [TestPlanogram] modify file (name = [TestPlanogram_log], filename = N'd:\db\TestPlanogram_log.ldf');
*/

--alter database [TestPlanogram] set online;

--NT SERVICE\MSSQLSERVER 
--create database ch on (filename = N'd:\db\ch.mdf'), (filename = 'd:\db\ch_log.ldf') for attach;