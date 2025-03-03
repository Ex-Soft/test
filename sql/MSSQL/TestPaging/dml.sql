declare
  @pageNumber int = 2,
  @pageSize int = 5,
  @sortingCol sysname = null,
  @sortType varchar(4) = 'desc',
  @withDetail bit = 1;

;with cte as (
	select
		*,
		null as DetailId,
		null as DetailVal,
		null as DetailFBit
	from
		dbo.TestMaster [master]
	where
		(@withDetail is null) or (@withDetail = 0)

	union all

	select
		[master].*,
		[detail].Id as DetailId,
		[detail].Val as DetailVal,
		[detail].FBit as DetailFBit
	from
		dbo.TestMaster [master]
		left join dbo.TestDetail [detail] on [detail].IdMaster = [master].Id
	where
		@withDetail = 1
)
select
	count(*) over() as TotalCount,
	*
from
	cte
order by
	case when coalesce(@sortingCol, 'Id') = 'Id' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'asc' collate SQL_Latin1_General_CP1_CI_AS then Id end,
	case when coalesce(@sortingCol, 'Id') = 'Id' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'desc' collate SQL_Latin1_General_CP1_CI_AS then Id end desc,
	case when @sortingCol = 'Val' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'asc' collate SQL_Latin1_General_CP1_CI_AS then Val end,
	case when @sortingCol = 'Val' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'desc' collate SQL_Latin1_General_CP1_CI_AS then Val end desc
offset (@pageNumber - 1) * @pageSize rows
fetch next @pageSize rows only;

select
  count(*) over() as TotalCount,
  Id,
  Val
from
  TableForPaging
order by
  case when coalesce(@sortingCol, 'Id') = 'Id' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'asc' collate SQL_Latin1_General_CP1_CI_AS then Id end,
  case when coalesce(@sortingCol, 'Id') = 'Id' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'desc' collate SQL_Latin1_General_CP1_CI_AS then Id end desc,
  case when @sortingCol = 'Val' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'asc' collate SQL_Latin1_General_CP1_CI_AS then Val end,
  case when @sortingCol = 'Val' collate SQL_Latin1_General_CP1_CI_AS and @sortType = 'desc' collate SQL_Latin1_General_CP1_CI_AS then Val end desc
 offset (@pageNumber - 1) * @pageSize rows
 fetch next @pageSize rows only;

;with Entries as
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