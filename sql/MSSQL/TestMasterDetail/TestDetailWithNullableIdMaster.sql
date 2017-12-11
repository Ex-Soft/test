use testdb
go

if object_id(N'TestDetailWithNullableIdMaster', N'u') is not null
	drop table TestDetailWithNullableIdMaster
go

create table TestDetailWithNullableIdMaster
(
	Id int identity constraint "pkTestDetailWithNullableIdMaster" primary key,
	IdMaster int constraint "fkTestMasterTestDetailWithNullableIdMaster" foreign key (IdMaster) references TestMaster(Id),
	Val nvarchar(255),
	FBit bit
)
go
