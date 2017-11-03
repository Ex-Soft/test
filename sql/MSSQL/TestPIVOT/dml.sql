select * from TestTable4TestPIVOTProducts
select * from TestTable4TestPIVOTList
select * from TestTable4TestPIVOTStores

select
	*
from
	TestTable4TestPIVOTProducts products
	left join TestTable4TestPIVOTList list on list.IdProduct = products.id

-- http://www.kodyaz.com/articles/t-sql-pivot-tables-in-sql-server-tutorial-with-examples.aspx
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTList l
  join TestTable4TestPIVOTProducts p on (p.Id=l.IdProduct)
  join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
order by l.IdProduct

select
  s.Name,
  p.Name,
  l.Cnt
from
  TestTable4TestPIVOTStores s
  join TestTable4TestPIVOTList l on (l.IdStore=s.Id)
  join TestTable4TestPIVOTProducts p on (p.Id=l.IdProduct)
order by s.Id

select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
order by p.Id

select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
order by p.Name

select
  *
from
(
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
) as DataTable
pivot
(
  sum(cnt)
  for Store in ([джинсы], [рубашка], [балкон], [холодильник])
) as PivotTable
order by Product

select
  *
from
(
select
  p.Id as ProductId,
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
) as DataTable
pivot
(
  sum(cnt)
  for Store in ([джинсы], [рубашка], [балкон], [холодильник])
) as PivotTable
order by ProductId

select
  *
from
(
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from (
	select ROW_NUMBER() over (order by Id) as num, *
	from TestTable4TestPIVOTProducts
) p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
where p.num between 1 and 2
) as DataTable
pivot
(
  sum(cnt)
  for Store in ([джинсы], [рубашка], [балкон], [холодильник])
) as PivotTable

select
  Product, [джинсы], [рубашка], [балкон], [холодильник]
from
(
select
  p.Id as ProductId,
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
) as DataTable
pivot
(
  sum(cnt)
  for Store in ([джинсы], [рубашка], [балкон], [холодильник])
) as PivotTable
order by ProductId

------------------------------------------------------------
declare
  @PivotColumnHeaders nvarchar(max)

select
  @PivotColumnHeaders = coalesce(@PivotColumnHeaders + ',[' + cast(Name as nvarchar) + ']', '[' + cast(Name as nvarchar)+ ']')
from
  TestTable4TestPIVOTStores

print @PivotColumnHeaders

declare
  @PivotTableSQL nvarchar(max)

set @PivotTableSQL = N'
select
  *
from
(
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
) as DataTable
pivot
(
  sum(cnt)
  for Store in (' + @PivotColumnHeaders + ')
) as PivotTable
order by Product
'

print @PivotTableSQL

execute(@PivotTableSQL)
