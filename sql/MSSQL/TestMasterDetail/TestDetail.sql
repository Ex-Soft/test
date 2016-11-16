use testdb
go

if object_id(N'TestDetail', N'u') is not null
	drop table TestDetail
go

create table TestDetail
(
	Id int identity constraint "pkTestDetail" primary key,
	IdMaster int constraint "TestDetailIdMasterNotNull" not null,
	Val nvarchar(255),
	constraint "fkTestMasterTestDetail" foreign key (IdMaster) references TestMaster(Id)
)
go
