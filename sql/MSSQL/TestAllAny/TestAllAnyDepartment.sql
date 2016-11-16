use testdb
go

if object_id(N'TestAllAnyDepartment', N'u') is not null
	drop table TestAllAnyDepartment
go

create table TestAllAnyDepartment
(
	id int not null constraint pkTestAllAnyDepartment primary key,
	name nvarchar(255)
)
go
