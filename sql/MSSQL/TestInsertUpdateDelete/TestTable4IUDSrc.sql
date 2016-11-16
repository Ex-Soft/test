use testdb
go

if object_id(N'TestTable4IUDSrc', N'u') is not null
  drop table TestTable4IUDSrc
go

create table TestTable4IUDSrc
(
   Id numeric(18,0) not null,
   Val numeric(18,0) null
)
go
