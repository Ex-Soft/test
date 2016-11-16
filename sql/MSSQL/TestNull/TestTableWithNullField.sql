use testdb
go

if object_id(N'TestTableWithNullField', N'u') is not null
	drop table TestTableWithNullField
go

create table TestTableWithNullField
(
	id int not null identity constraint pkTestTableWithNullField primary key,
	val int null
)
go
