if object_id(N'TestTable4Output', N'u') is not null
	drop table TestTable4Output
go

create table TestTable4Output
(
	id int not null identity constraint pkTestTable4TOutput primary key,
	f1 int null,
	f2 int null,
	f3 int null,
	f4 int null
)
go
