use testdb
go

if object_id(N'TestTableWOIdentity', N'u') is not null
	drop table TestTableWOIdentity
go

create table TestTableWOIdentity
(
	Id int not null constraint "pkTestTableWOIdentity" primary key,
	Val nvarchar(255)
)
go

