use testdb
go

if object_id(N'TestTableWithIndexes4LockI', N'u') is not null
	drop table TestTableWithIndexes4LockI
go

create table TestTableWithIndexes4LockI
(
	id int not null identity constraint pkTestTableWithIndexes4LockI primary key nonclustered,
	idSmthI int not null constraint fkTestTableWithIndexes4LockI_II foreign key references TestTableWithIndexes4LockII(id),
	idSmthII int not null,
	FieldI nvarchar(50) not null,
	FieldII nvarchar(50) not null,
	FieldIII int null,
	FieldIV binary(16) null
)
go

if not exists (select * from sys.indexes where object_id = object_id(N'TestTableWithIndexes4LockI') and name = N'idx_TestTableWithIndexes4LockI_idSmthII_idSmthI')
	create unique clustered index idx_TestTableWithIndexes4LockI_idSmthII_idSmthI on TestTableWithIndexes4LockI
	(
		idSmthII asc,
		idSmthI asc
	)
go
