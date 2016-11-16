use testdb
go

if object_id(N'TestMaster', N'u') is not null
	drop table TestMaster
go

create table TestMaster
(
	Id int identity constraint "pkTestMaster" primary key,
	Val nvarchar(255)
)
go
