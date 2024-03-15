use testdb;
go

if object_id(N'TableForPaging', N'u') is not null
	drop table TableForPaging;
go

create table TableForPaging
(
	Id int not null constraint pk_TableForPaging primary key,
	Val int
);
go
