select
  *
from
  TestTableCustomPermissionMain m
where
  ((m.Id_2 in (select Allow from TestTableCustomPermissionRight))
  or (m.Id_2 is null));

select
  m.Id,
  m.Id_1,
  m.Id_2,
  p.Id,
  p.Allow
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_2) or (m.Id_2 is null);

select
  m.Id,
  m.Id_1,
  m.Id_2,
  p.Id,
  p.Allow
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_2)
union
select
  m.Id,
  m.Id_1,
  m.Id_2,
  null,
  null
from
  TestTableCustomPermissionMain m
where
  (m.Id_2 is null);