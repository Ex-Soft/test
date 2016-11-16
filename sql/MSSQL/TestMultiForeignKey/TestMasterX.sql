use testdb
go

if object_id(N'TestMasterX', N'u') is not null
	drop table TestMasterX
go

create table TestMasterX
(
	Id int identity constraint "pkTestMasterX" primary key,
	Val nvarchar(255)
)
go
