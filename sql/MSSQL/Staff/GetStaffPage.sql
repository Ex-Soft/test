use testdb
go

if object_id('GetStaffPage', N'p') is not null
  drop procedure GetStaffPage
go

create procedure GetStaffPage
  @start int,
  @limit int
as
begin

  set nocount on

  create table #tmpStaff
  (
     tmpId bigint identity,
     ID bigint null,
     Name nvarchar(255) null,
     Salary money null,
     Dep int null,
     BirthDate date null,
     NullField numeric(18,0) null
  )

  insert into #tmpStaff
  (ID, Name, Salary, Dep, BirthDate, NullField)
  select
    ID,
    Name,
    Salary,
    Dep,
    BirthDate,
    NullField
  from
    Staff
  order by ID

  select
    *
  from
    #tmpStaff
  where
    (tmpId>@start) and (tmpId<=(@start+@limit))

  drop table #tmpStaff
end
go