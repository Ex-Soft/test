use testdb
go

if object_id(N'TableWithHierarchyII', N'u') is not null
	drop table TableWithHierarchyII
go


create table TableWithHierarchyII
(
	Id int not null constraint pk_TableWithHierarchyII primary key,
	ParentId int constraint fk_TableWithHierarchyII references TableWithHierarchyII (Id),
	Val nvarchar(256)
)
go
