select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTList l
  join TestTable4TestPIVOTProducts p on (p.Id=l.IdProduct)
  join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
order by l.IdProduct;

select
  s.Name,
  p.Name,
  l.Cnt
from
  TestTable4TestPIVOTStores s
  join TestTable4TestPIVOTList l on (l.IdStore=s.Id)
  join TestTable4TestPIVOTProducts p on (p.Id=l.IdProduct)
order by s.Id;

select
  p.Name as Product,
  s.Name as Store,
  l.Cnt
from
  TestTable4TestPIVOTProducts p
  left join TestTable4TestPIVOTList l on (l.IdProduct=p.Id)
  left join TestTable4TestPIVOTStores s on (s.Id=l.IdStore)
order by p.Id;

select
  typhoon.XT_PIVOT.pivot_ref('select count(distinct product) from aspnetuser.TestTable4TestPIVOTView',
  'select
     product,
     store,
     sum(cnt) SUM_CNT,
     dense_rank() over(order by store) rn
   from
     aspnetuser.TestTable4TestPIVOTView
   group by product, store',
   typhoon.varchar2_table('PRODUCT'),
   typhoon.varchar2_table('SUM_CNT'),
   typhoon.varchar2_table('select distinct store from aspnetuser.TestTable4TestPIVOTView order by 1'))
from dual;
