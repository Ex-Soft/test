use testdb
go

if object_id(N'TableWithTrigger1WD', N'u') is not null
	drop table TableWithTrigger1WD
go

create table TableWithTrigger1WD
(
	id bigint not null constraint pkTableWithTrigger1WD primary key,
	value1 nvarchar(256) null,
	value2 nvarchar(256) null,
	value3 nvarchar(256) null,
	deleted bit not null default 0
)
go
