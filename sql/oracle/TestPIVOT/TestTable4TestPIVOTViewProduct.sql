create or replace view TestTable4TestPIVOTViewProduct
as
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore);
