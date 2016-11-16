use testdb
go

if object_id(N'TestTable4IUDDest', N'u') is not null
  drop table TestTable4IUDDest
go

create table TestTable4IUDDest
(
   Id numeric(18,0) not null,
   Val numeric(18,0) null
)
go
