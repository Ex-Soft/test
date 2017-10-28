if object_id(N'TestDetailWOFK', N'u') is not null
	drop table TestDetailWOFK
go

if object_id(N'TestMasterWOFK', N'u') is not null
	drop table TestMasterWOFK
go

create table TestMasterWOFK
(
	Id int not null constraint pkTestMasterWOFK primary key,
	Val nvarchar(255) null
)
go

create table TestDetailWOFK
(
	Id int not null constraint pkTestDetailWOFK primary key,
	IdMaster int null,
	Val nvarchar(255) null
)
go

alter table TestDetailWOFK with nocheck add constraint fkTestMasterWOFKTestDetailWOFK foreign key (IdMaster) references TestMasterWOFK (Id)
go

alter table TestDetailWOFK nocheck constraint fkTestMasterWOFKTestDetailWOFK
go

if object_id(N'EntityC', N'u') is not null
	drop table EntityC
go

if object_id(N'EntityB', N'u') is not null
	drop table EntityB
go

if object_id(N'EntityA', N'u') is not null
	drop table EntityA
go

create table EntityA
(
	Id int not null constraint pkEntityA primary key,
	MainId int not null constraint fk_EntityA_MainId_EntityA_Id foreign key references EntityA(Id),
	Value nvarchar(255) null
)
go

create table EntityB
(
	Id int not null constraint pkEntityB primary key,
	Value nvarchar(255) null
)
go

create table EntityC
(
	Id int not null constraint pkEntityC primary key,
	EntityAId int not null constraint fk_EntityC_EntityAId_EntityA_Id foreign key references EntityA(Id),
	EntityBId int not null constraint fk_EntityC_EntityBId_EntityB_Id foreign key references EntityB(Id),
	Value nvarchar(255) null
)
go
