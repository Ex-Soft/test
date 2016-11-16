use testdb
go

if object_id(N'TestTable4Apply2', N'u') is not null
	drop table TestTable4Apply2
go

create table TestTable4Apply2
(
	id int not null constraint pkTestTable4Apply2 primary key,
	value nvarchar(20) not null
)
go
