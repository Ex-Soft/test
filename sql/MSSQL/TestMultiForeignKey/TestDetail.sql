use testdb
go

if object_id(N'TestDetailMulti', N'u') is not null
	drop table TestDetailMulti
go

create table TestDetailMulti
(
	Id int identity constraint "pkTestDetailMulti" primary key,
	IdMaster int constraint "TestDetailMultiIdMasterNotNull" not null,
	Val nvarchar(255),
	constraint "fkTestMasterXTestDetailMulti" foreign key (IdMaster) references TestMasterX(Id),
	constraint "fkTestMasterYTestDetailMulti" foreign key (IdMaster) references TestMasterY(Id)
)
go

alter table TestDetailMulti nocheck constraint "fkTestMasterXTestDetailMulti"
go

alter table TestDetailMulti nocheck constraint "fkTestMasterYTestDetailMulti"
go
