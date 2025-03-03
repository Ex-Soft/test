use testdb;
go

if object_id(N'TestMaster', N'u') is not null
	drop table TestMaster;
go

create table TestMaster
(
	Id int identity constraint "pkTestMaster" primary key,
	Val nvarchar(255),
	FBit bit null,
	IdForView as (Id)
);
go

if col_length(N'dbo.TestMaster', N'FBit') is null
	alter table TestMaster add FBit bit null;
go

if col_length(N'TestMaster', N'IdForView') is null
	alter table TestMaster add IdForView as (Id);
go