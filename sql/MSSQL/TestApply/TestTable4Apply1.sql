use testdb;
go

if object_id(N'TestTable4Apply1', N'u') is not null
	drop table TestTable4Apply1;
go

create table TestTable4Apply1
(
	id int not null constraint pkTestTable4Apply1 primary key,
	row_count int not null
);
go
