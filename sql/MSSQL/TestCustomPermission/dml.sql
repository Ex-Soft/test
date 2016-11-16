select
  *
from
  TestTableCustomPermissionMain m
where
  ((m.Id_2 in (select Allow from TestTableCustomPermissionRight))
  or (m.Id_2 is null))

select
  m.Id,
  m.Id_1,
  m.Id_2,
  p.Id,
  p.Allow
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_2) or (m.Id_2 is null)

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
  (m.Id_2 is null)

/*
SET STATISTICS PROFILE ON 
SET STATISTICS TIME ON  

SET SHOWPLAN_ALL OFF
go

SET SHOWPLAN_TEXT OFF
go

SET STATISTICS IO OFF
go
*/
/*
select
  m.*
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_1) or (p.Allow=m.Id_2)

select
  m.*
from
  TestTableCustomPermissionMain m
where
  (m.Id_1 in (select Allow from TestTableCustomPermissionRight))
  or (m.Id_2 in (select Allow from TestTableCustomPermissionRight))
*/

select
  m.*
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_1)
union
select
  m.*
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p on (p.Allow=m.Id_2)
order by 1
------------------------------------------------------------

select
  m.*
from
  TestTableCustomPermissionMain m
where
  m.Id_1 in (select Allow from TestTableCustomPermissionRight)
union
select
  m.*
from
  TestTableCustomPermissionMain m
where
  m.Id_2 in (select Allow from TestTableCustomPermissionRight)
order by 1

------------------------------------------------------------
wrong!!!

select
  m.*
from
  TestTableCustomPermissionMain m
  join TestTableCustomPermissionRight p1 on (p1.Allow=m.Id_1)
  join TestTableCustomPermissionRight p2 on (p2.Allow=m.Id_2)