use testdb;
go

if object_id(N'TestDetail', N'u') is not null
	drop table TestDetail;
go

create table TestDetail
(
	Id int identity constraint "pkTestDetail" primary key,
	IdMaster int constraint "TestDetailIdMasterNotNull" not null,
	Val nvarchar(255),
	FBit bit null,
	constraint "fkTestMasterTestDetail" foreign key (IdMaster) references TestMaster(Id)
);
go

if col_length(N'dbo.TestDetail', N'FBit') is null
	alter table TestDetail add FBit bit null;
go
