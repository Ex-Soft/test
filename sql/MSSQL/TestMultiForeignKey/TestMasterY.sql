use testdb
go

if object_id(N'TestMasterY', N'u') is not null
	drop table TestMasterY
go

create table TestMasterY
(
	Id int identity constraint "pkTestMasterY" primary key,
	Val nvarchar(255)
)
go
