/* http://habrahabr.ru/post/43955/ */
/* http://www.osp.ru/pcworld/2007/03/4199032/ */

select
  t.*
from
  TableWithHierarchy t
order by t.id;

select
  t.id,
  t.parentid,
  t.val,
  level as l,
  sys_connect_by_path(t.val, '/') as path,
  prior val as parent,
  connect_by_root val as root,
  connect_by_isleaf as isleaf
from
  TableWithHierarchy t
start with
  t.parentid is null
connect by
  prior t.id=t.parentid;

select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.parentid is null
connect by
  prior t.id=t.parentid
order siblings by t.val;

select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.id=9
connect by
  prior t.id=t.parentid;

select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.id=9
connect by
  prior t.parentid=t.id;

select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.id=14
connect by
  prior t.id=t.parentid;

select
  t.id,
  t.parentid,
  t.val,
  level as l
from
  TableWithHierarchy t
start with
  t.id=14
connect by
  prior t.parentid=t.id;

select
  *
from (select
        t.id,
        t.parentid,
        t.val,
        level as l
      from
        TableWithHierarchy t
      start with
        t.id=14
      connect by
        prior t.parentid=t.id
     ) r
where
  r.parentid<9
order by l desc;

select
  t.id,
  t.parentid,
  t.val,
  level as l,
  connect_by_iscycle iscycle
from
  TableWithHierarchy t
start with
  t.parentid is null
connect by nocycle
  prior t.id=t.parentid;

select
  rownum as rn,
  level as l
from
  dual
connect by
  level <= (select max(id) from TableWithHierarchy);

select
  sq.rn
from
  (select
     rownum as rn
   from
     dual
   connect by
     level <= (select max(id) from TableWithHierarchy)
  ) sq
where
  sq.rn not in (select id from TableWithHierarchy)
order by rn;