if object_id('TestTable4TestPIVOTProducts',N'u') is not null
  drop table TestTable4TestPIVOTProducts
go

create table TestTable4TestPIVOTProducts
(
   Id int not null constraint pkTestTable4TestPIVOTProducts primary key,
   Name nvarchar(256)
)
go
