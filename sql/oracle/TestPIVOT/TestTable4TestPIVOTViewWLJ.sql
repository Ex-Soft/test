create or replace view TestTable4TestPIVOTViewWLJ
as
select 
  p.name product,
  s.name store,
  cnt cnt
from
  TestTable4TestPIVOTList l
  left join TestTable4TestPIVOTProducts p on p.id=l.idproduct
  left join TestTable4TestPIVOTStores s on s.id=l.idstore;
