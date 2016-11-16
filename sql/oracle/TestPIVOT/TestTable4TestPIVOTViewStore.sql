create or replace view TestTable4TestPIVOTViewStore
as
select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTStores s
  left join TestTable4TestPIVOTList l on (l.IdStore=s.Id)
  left join TestTable4TestPIVOTProducts p on (p.Id=l.IdProduct);
