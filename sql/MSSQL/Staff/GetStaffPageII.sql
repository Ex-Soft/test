use testdb
go

if object_id('GetStaffPageII', N'p') is not null
  drop procedure GetStaffPageII
go

create procedure GetStaffPageII
  @start int,
  @limit int
as
begin

  set nocount on

  set @start=@start+1

  declare
    @FirstId bigint

  set rowcount @start

  select
    @FirstId=ID
  from
    Staff
  order by ID

  set rowcount @limit

  select
    *
  from
    Staff
  where
    (ID >= @FirstId)
  order by ID

  set rowcount 0
end
go