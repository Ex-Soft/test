if object_id('TestTable4TableValuedFunction','u') is not null
  drop table TestTable4TableValuedFunction
go

create table TestTable4TableValuedFunction
(
   Id int identity,
   FInt int
)
go
