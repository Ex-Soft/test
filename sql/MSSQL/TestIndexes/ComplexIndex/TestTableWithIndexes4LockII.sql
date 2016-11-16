use testdb
go

if object_id(N'TestTableWithIndexes4LockII', N'u') is not null
	drop table TestTableWithIndexes4LockII
go

create table TestTableWithIndexes4LockII
(
	id int not null identity constraint pkTestTableWithIndexes4LockII primary key,
	FieldI int null
)
go
