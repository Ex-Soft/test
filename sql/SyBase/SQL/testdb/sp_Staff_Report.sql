use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_Staff_Report')
            and    type = 'P')
   drop procedure sp_Staff_Report
go

create procedure sp_Staff_Report
as 
begin
  declare
    @ReportNo int,
    @ReportDate date,
    @ReportName varchar(1024)

  set @ReportNo=13
  set @ReportDate=getdate()
  set @ReportName='Report'

  select
    @ReportNo as ReportNo,
    @ReportDate as ReportDate,
    @ReportName as ReportName

  select
    *
  from
    Staff
  order by Dep asc, Salary desc
end
go
