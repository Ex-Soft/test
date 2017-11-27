use testdb
go

if object_id(N'TestDetailWithPolymorphicAssociations', N'u') is not null
	drop table TestDetailWithPolymorphicAssociations
go

if object_id(N'TestMasterX', N'u') is not null
	drop table TestMasterX
go

if object_id(N'TestMasterY', N'u') is not null
	drop table TestMasterY
go

create table TestMasterX
(
	Id int identity not null constraint pkTestMasterX primary key,
	Val nvarchar(255) null
)
go

create table TestMasterY
(
	Id int identity not null constraint pkTestMasterY primary key,
	Val nvarchar(255) null
)
go

create table TestDetailWithPolymorphicAssociations
(
	Id int identity not null constraint pkTestDetailWithPolymorphicAssociations primary key,
	MasterType char(1) null,
	MasterId int null,
	Val nvarchar(255) null
)
go

alter table TestDetailWithPolymorphicAssociations with nocheck add constraint fkTestMasterXTestDetailWithPolymorphicAssociations foreign key (MasterId) references TestMasterX (Id)
go

alter table TestDetailWithPolymorphicAssociations nocheck constraint fkTestMasterXTestDetailWithPolymorphicAssociations
go

alter table TestDetailWithPolymorphicAssociations with nocheck add constraint fkTestMasterYTestDetailWithPolymorphicAssociations foreign key (MasterId) references TestMasterY (Id)
go

alter table TestDetailWithPolymorphicAssociations nocheck constraint fkTestMasterYTestDetailWithPolymorphicAssociations
go
