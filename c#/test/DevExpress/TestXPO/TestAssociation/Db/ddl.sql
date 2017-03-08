if object_id(N'AssociativeTable', N'u') is not null
	drop table AssociativeTable;

if object_id(N'TableLeft', N'u') is not null
	drop table TableLeft;

create table TableLeft
(
	Id int not null constraint pkTableLeft primary key,
	Val nvarchar(256) null
);

if object_id(N'TableRight', N'u') is not null
	drop table TableRight;

create table TableRight
(
	Id int not null constraint pkTableRight primary key,
	Val nvarchar(256) null
);

create table AssociativeTable
(
	Id int not null identity constraint pkAssociativeTable primary key,
	LeftId int not null constraint fk_TableLeft_AssociativeTable references TableLeft(Id),
	RightId int not null constraint fk_TableRight_AssociativeTable references TableRight(Id)
);

/*
if not exists (select 1 from sys.indexes where object_id = object_id(N'AssociativeTable', N'u') and name = N'IX_AssociativeTable_Left_Right')
	create index IX_AssociativeTable_Left_Right on AssociativeTable(LeftId, RightId)

if not exists (select 1 from sys.indexes where object_id = object_id(N'AssociativeTable', N'u') and name = N'IX_AssociativeTable_Right_Left')
	create index IX_AssociativeTable_Right_Left on AssociativeTable(RightId, LeftId)

if not exists (select 1 from sys.indexes where object_id = object_id(N'AssociativeTable', N'u') and name = N'IX_AssociativeTable_Left')
	create index IX_AssociativeTable_Left on AssociativeTable(LeftId)

if not exists (select 1 from sys.indexes where object_id = object_id(N'AssociativeTable', N'u') and name = N'IX_AssociativeTable_Right')
	create index IX_AssociativeTable_Right on AssociativeTable(RightId)
*/