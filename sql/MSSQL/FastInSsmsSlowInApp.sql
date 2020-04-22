select * from Staff order by BirthDate

exec List_Staff_1
exec List_Staff_2 '20000101'
exec List_Staff_3 '20000101'
exec List_Staff_4
exec List_Staff_5

set dateformat dmy
go
exec List_Staff_6
go
set dateformat mdy
go
exec List_Staff_6
go

SELECT qs.plan_handle, a.attrlist
FROM   sys.dm_exec_query_stats qs
CROSS  APPLY sys.dm_exec_sql_text(qs.sql_handle) est
CROSS  APPLY (SELECT epa.attribute + '=' + convert(nvarchar(127), epa.value) + '   '
              FROM   sys.dm_exec_plan_attributes(qs.plan_handle) epa
              WHERE  epa.is_cache_key = 1
              ORDER  BY epa.attribute
              FOR    XML PATH('')) AS a(attrlist)
WHERE  est.objectid = object_id ('dbo.List_Staff_6')
  AND  est.dbid     = db_id('testdb')

SELECT convert(binary(4), 4347)

/*
create procedure List_Staff_1 as
   select * from Staff where BirthDate > '20000101'
go

create procedure List_Staff_2 @fromdate datetime as
   select * from Staff where BirthDate > @fromdate
go

create procedure List_Staff_3 @fromdate datetime as
   declare @fromdate_copy datetime
   select @fromdate_copy = @fromdate
   select * from Staff where BirthDate > @fromdate_copy
go

create procedure List_Staff_4 @fromdate date = null as
   if @fromdate is null
      select @fromdate = '17000101'
   select * from Staff where BirthDate > @fromdate
go

create procedure List_Staff_5 @fromdate date = null as
   declare @fromdate_copy date
   select @fromdate_copy  = coalesce(@fromdate, '17000101')
   select * from Staff where BirthDate > @fromdate_copy
go

create procedure List_Staff_6 as
   select *
   from   Staff
   where  BirthDate > '12/01/1954'
go
*/

/* http://www.queryprocessor.ru/fast-in-ssms-slow-in-app-part1/ */