use testdb
go

if object_id(N'TestTableVictim', N'u') is not null
  drop table TestTableVictim
go

create table TestTableVictim
(
   Id int identity,
   F_Int1 int,
   F_Int2 int,
   F_Int3 int
)
go
