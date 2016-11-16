use testdb
go

if object_id(N'vTestTables4TestPIVOT', N'v') is not null
	drop view vTestTables4TestPIVOT
go

create view vTestTables4TestPIVOT
as
select
	products.Id as ProductId,
	products.Name as ProductName,
	stores.Id as StoreId,
	stores.Name as StoreName,
	list.Cnt as [Count]
from
	TestTable4TestPIVOTProducts products
	left join TestTable4TestPIVOTList list on (list.IdProduct = products.Id)
	left join TestTable4TestPIVOTStores stores on (stores.Id = list.IdStore)
go
