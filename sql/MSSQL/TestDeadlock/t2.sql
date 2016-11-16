use testdb
go

if object_id(N't2', N'u') is not null
  drop table t2
go

create table t2
(
   fint int
)
go

