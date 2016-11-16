use testdb
go

if object_id(N't1', N'u') is not null
  drop table t1
go

create table t1
(
   fint int
)
go

