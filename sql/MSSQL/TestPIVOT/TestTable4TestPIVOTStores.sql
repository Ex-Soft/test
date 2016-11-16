if object_id('TestTable4TestPIVOTStores',N'u') is not null
  drop table TestTable4TestPIVOTStores
go

create table TestTable4TestPIVOTStores
(
   Id int not null constraint pkTestTable4TestPIVOTStores primary key,
   Name nvarchar(256)
)
go
