use testdb
go

if object_id(N'TableWithTrigger2WD', N'u') is not null
	drop table TableWithTrigger2WD
go

create table TableWithTrigger2WD
(
	id bigint not null constraint pkTableWithTrigger2WD primary key,
	value1 nvarchar(256) null,
	value2 nvarchar(256) null,
	value3 nvarchar(256) null,
	deleted bit not null default 0
)
go
