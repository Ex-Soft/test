use testdb
go

if object_id(N'TestDetailWOFK', N'u') is not null
	drop table TestDetailWOFK
go

create table TestDetailWOFK
(
	Id int constraint "pkTestDetailWOFK" primary key,
	IdMaster int null,
	Val nvarchar(255)
)
go

if exists (select 1 from sys.foreign_keys where parent_object_id = object_id(N'TestDetailWOFK', N'u') and object_id = object_id(N'fkTestMasterWOFKTestDetailWOFK', N'f'))
	alter table TestDetailWOFK drop constraint fkTestMasterWOFKTestDetailWOFK
go

alter table TestDetailWOFK with nocheck add constraint fkTestMasterWOFKTestDetailWOFK foreign key(IdMaster) references TestMasterWOFK (Id)
go

alter table TestDetailWOFK nocheck constraint fkTestMasterWOFKTestDetailWOFK
go