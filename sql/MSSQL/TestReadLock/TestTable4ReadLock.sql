use testdb
go

if object_id(N'TestTable4ReadLock', N'u') is not null
	drop table TestTable4ReadLock
go

create table TestTable4ReadLock
(
	Id int not null,
	Value int not null,
	Placeholder nvarchar(200) not null constraint Def_TestTable4ReadLock_Placeholder default N'a',
	constraint PK_TestTable4ReadLock primary key clustered (Id)
)
go

