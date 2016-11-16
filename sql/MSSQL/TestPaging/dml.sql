with Entries as
(
select
  row_number() over(order by Val) as RowNum,
  Id,
  Val
from
  TableForPaging
)
select
  *
from
  Entries
where
  (RowNum>=1) and (RowNum<=7);
  /* (RowNum>=8) and (RowNum<=14); */
  /* (RowNum>=15) and (RowNum<=21); */
  /* (RowNum>=22) and (RowNum<=28); */
  /* (RowNum >= (PageNo-1)*PageSize+1) and (RowNum <= PageNo*PageSize); */

  RowNum between 1 and 7
  /* RowNum between 8 and 14 */
  /* RowNum between 15 and 21 */
  /* RowNum between 22 and 28 */
  /* RowNum between (PageNo-1)*PageSize+1 and PageNo*PageSize */
go

exec GetPage 2, 7
go

with Entries as
(
select
  row_number() over(order by Val) as RowNum,
  Id,
  Val
from
  TableForPaging
)
select
  *
from
  Entries
where
  (RowNum>0) and (RowNum<8)
  /* (RowNum>7) and (RowNum<15) */
  /* (RowNum>14) and (RowNum<22) */
  /* (RowNum>21) and (RowNum<29) */
  /* (RowNum > (PageNo-1)*PageSize) and (RowNum < PageNo*PageSize+1) */
go

select
  *
from
(
   select
     row_number() over(order by Id) as RowNum,
     Id,
     Val
   from
     TableForPaging
) p
where
  p.RowNum between 1 and 7
order by p.Id
