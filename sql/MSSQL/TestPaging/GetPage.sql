/* http://www.4guysfromrolla.com/webtech/062899-1.shtml */

create procedure GetPage
  @Page int,
  @RecsPerPage int
as
begin
  set nocount on

  declare
    @FirstRec int,
    @LastRec int

  set @FirstRec = (@Page - 1) * @RecsPerPage
  set @LastRec = (@Page * @RecsPerPage + 1)

  create table #TempTable
  (
     tmpId int identity,
     Id int,
     Val int
  )

  insert into #TempTable
  (Id, Val)
  select
    Id,
    Val
  from
    TableForPaging
  order by Val

  select
    *
  from
    #TempTable
  where
    (tmpId > @FirstRec)
    and (tmpId < @LastRec)
end