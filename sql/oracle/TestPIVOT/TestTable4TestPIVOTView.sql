create or replace view TestTable4TestPIVOTView
as
select 
  p.name product,
  s.name store,
  cnt cnt
from
  TestTable4TestPIVOTList l
  join TestTable4TestPIVOTProducts p on p.id=l.idproduct
  join TestTable4TestPIVOTStores s on s.id=l.idstore;
