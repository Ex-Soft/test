use testdb
go

if object_id(N'TestMasterWOFK', N'u') is not null
	drop table TestMasterWOFK
go

create table TestMasterWOFK
(
	Id int constraint "pkTestMasterWOFK" primary key,
	Val nvarchar(255)
)
go
