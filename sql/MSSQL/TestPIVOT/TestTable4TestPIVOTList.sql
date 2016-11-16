if object_id('TestTable4TestPIVOTList',N'u') is not null
  drop table TestTable4TestPIVOTList
go

create table TestTable4TestPIVOTList
(
   Id int not null constraint pkTestTable4TestPIVOTList primary key,
   IdProduct int constraint fkTestTable4TestPIVOTList_Products foreign key references TestTable4TestPIVOTProducts(id),
   IdStore int constraint fkTestTable4TestPIVOTList_Stores foreign key references TestTable4TestPIVOTStores(Id),
   Cnt int
)
go
