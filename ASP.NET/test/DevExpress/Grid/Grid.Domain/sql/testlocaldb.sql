if exists (select 1 from sys.databases where name = N'testlocaldb')
	drop database testlocaldb
go

create database testlocaldb on (name = testlocaldb, filename = N'd:\db\testlocaldb.mdf') log on (name = testlocaldb_log, filename = N'd:\db\testlocaldb_log.ldf')
go

use testlocaldb
go

create table Staff
(
	Id int not null identity constraint pkStaff primary key,
	Name nvarchar(255) null,
	Salary money null,
	Dep int null,
	BirthDate date null
)
go
