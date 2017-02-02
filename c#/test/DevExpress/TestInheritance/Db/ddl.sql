use testdb
go

if object_id(N'Entity3', N'u') is not null
  drop table Entity3
go

if object_id(N'Entity2', N'u') is not null
  drop table Entity2
go

if object_id(N'Entity1', N'u') is not null
  drop table Entity1
go

create table Entity1
(
   Id int not null constraint pkEntity1 primary key,
   Value varchar(255) null
)
go

create table Entity2
(
   Id int not null constraint pkEntity2 primary key,
   Value varchar(255) null
)
go

create table Entity3
(
   Id int not null identity constraint pkEntity3 primary key,
   Value varchar(255) null,
   ElementId int null
)
go

if exists (select 1 from sys.foreign_keys where parent_object_id = object_id(N'Entity3', N'u') and object_id = object_id(N'fk_Entity1_Entity3', N'f'))
	alter table Entity3 drop constraint fk_Entity1_Entity3
go

alter table Entity3 with nocheck add constraint fk_Entity1_Entity3 foreign key(ElementId) references Entity1 (Id)
go

alter table Entity3 nocheck constraint fk_Entity1_Entity3
go

if exists (select 1 from sys.foreign_keys where parent_object_id = object_id(N'Entity3', N'u') and object_id = object_id(N'fk_Entity2_Entity3', N'f'))
	alter table Entity3 drop constraint fk_Entity2_Entity3
go

alter table Entity3 with nocheck add constraint fk_Entity2_Entity3 foreign key(ElementId) references Entity2 (Id)
go

alter table Entity3 nocheck constraint fk_Entity2_Entity3
go

if object_id(N'TestDETableLeft', N'u') is not null
  drop table TestDETableLeft
go

create table TestDETableLeft
(
   Id int not null identity constraint pkTestDETableLeft primary key,
   Val varchar(255) null,
   ValLeft varchar(255) null
)
go

if object_id(N'TestDETableRight', N'u') is not null
  drop table TestDETableRight
go

create table TestDETableRight
(
   Id int not null identity constraint pkTestDETableRight primary key,
   Val varchar(255) null,
   ValRight varchar(255) null
)
go

if object_id(N'TestDEDetailTableWithInheritance', N'u') is not null
  drop table TestDEDetailTableWithInheritance
go

if object_id(N'TestDEMasterTableWithInheritance', N'u') is not null
  drop table TestDEMasterTableWithInheritance
go

create table TestDEMasterTableWithInheritance
(
	id int not null identity constraint pkTestDEMasterTableWithInheritance primary key,
	valueLite nvarchar(255) null,
	[value] nvarchar(255) null,
	OptimisticLockField int null,
	ObjectType int null constraint fkTestDEMasterTableWithInheritance_ObjectType foreign key references XPObjectType (OID) not for replication
)
go

create table TestDEDetailTableWithInheritance
(
	id int not null identity constraint pkTestDEDetailTableWithInheritance primary key,
	idMaster int null constraint fkTestDEDetailTableWithInheritance_TestDEMasterTableWithInheritance references TestDEMasterTableWithInheritance(id),
	valueLite nvarchar(255) null,
	[value] nvarchar(255) null,
	OptimisticLockField int null,
	ObjectType int null constraint fkTestDEDetailTableWithInheritance_ObjectType foreign key references XPObjectType (OID) not for replication
)
go

if object_id(N'TestDEReference', N'u') is not null
	drop table TestDEReference
go

create table TestDEReference
(
	Id int not null identity constraint pkTestDEReference primary key,
	[Value] nvarchar(255) null
)
go

if object_id(N'TestDEForTestInheritanceI', N'u') is not null
	drop table TestDEForTestInheritanceI
go

create table TestDEForTestInheritanceI
(
	Id int not null identity constraint pkTestDEForTestInheritanceI primary key,
	[Value] nvarchar(255) null,
	LeftId int not null constraint fk_TestDEReference_Id_TestDEForTestInheritanceI_LeftId references TestDEReference(Id),
	RightId int not null constraint fk_TestDEReference_Id_TestDEForTestInheritanceI_RightId references TestDEReference(Id)
)
go

if object_id(N'TestDEForTestInheritanceII', N'u') is not null
	drop table TestDEForTestInheritanceII
go

create table TestDEForTestInheritanceII
(
	Id int not null identity constraint pkTestDEForTestInheritanceII primary key,
	[Value] nvarchar(255) null,
	LeftId int not null constraint fk_TestDEReference_Id_TestDEForTestInheritanceII_LeftId references TestDEReference(Id),
	RightId int not null constraint fk_TestDEReference_Id_TestDEForTestInheritanceII_RightId references TestDEReference(Id)
)
go

if object_id(N'refGoods', N'u') is not null
	drop table refGoods
go

create table refGoods
(
	id int not null identity constraint pkRefGoods primary key,
	FullName nvarchar(255) null,
	IsCompetitor bit not null constraint dfIsCompetitor default(0)
)
go

if object_id(N'refGoodsCompetitors', N'u') is not null
	drop table refGoodsCompetitors
go

create table refGoodsCompetitors
(
	id int not null identity constraint pkRefGoodsCompetitors primary key,
	[Value] nvarchar(255) null,
	idGoods int not null constraint fk_refGoods_id_refGoodsCompetitors_idGoods references refGoods(id),
	idGoodsCompetitor int not null constraint fk_refGoods_id_refGoodsCompetitors_idGoodsCompetitor references refGoods(Id)
)
go
