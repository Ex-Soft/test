select
  o.*
from (select
        rownum rw,
        o.*
      from (select
              o.*
            from
              TableForPaging o
            order by Val) o
      where rownum < 8) o
where
  o.rw > 0;
oB!
----------------------

select
  o.*
from (select
        o.*,
        row_number() over (order by o.Val) as rn
      from
        TableForPaging o
     ) o
where
  (o.rn>=1) and (o.rn<=7);
  /* (o.rn>=8) and (o.rn<=14); */
  /* (o.rn>=15) and (o.rn<=21); */
  /* (o.rn>=22) and (o.rn<=28); */
  /* (o.rn >= (PageNo-1)*PageSize+1) and (o.rn <= PageNo*PageSize); */

  o.rn between 1 and 7;
  /* o.rn between 8 and 14; */
  /* o.rn between 15 and 21; */
  /* o.rn between 22 and 28; */
  /* o.rn between (PageNo-1)*PageSize+1 and PageNo*PageSize */

  (o.rn>0) and (o.rn<8)
  /* (o.rn>7) and (o.rn<15) */
  /* (o.rn>14) and (o.rn<22) */
  /* (o.rn>21) and (o.rn<29) */
  /* (o.rn > (PageNo-1)*PageSize) and (o.rn < PageNo*PageSize+1) */
oB!
-----------------------

select
  o.*
from (select
        o.*,
        row_number() over (order by o.Val) as rn
      from
        TableForPaging o
     ) o
where
  (o.rn>0 /* start */) and (o.rn<=(0 /* start */ + 2 /* limit */));
oB!
-----------------------

with Entries as
(
   select
     t.*,
     rownum as rn
   from
     TableForPaging t
   order by t.Val
)
select
  *
from
  Entries
where
  rn between 1 and 7;
Wrong!!!
----------------------

select
  *
from (select
        t.*,
        rownum rn
      from
        TableForPaging t
      order by Val)
where rn between 1 and 7;
Wrong!!!