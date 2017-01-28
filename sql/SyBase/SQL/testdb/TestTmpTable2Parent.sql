use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TestTmpTable2Parent'))
             and (type = 'P'))
   drop procedure TestTmpTable2Parent
go

create procedure TestTmpTable2Parent
as
begin
  set nocount on

  declare
    @SPName varchar(254),
    @tmpString varchar(254)

  set @SPName='TestTmpTable2Parent'

  set @tmpString=@SPName||' create table # (begin)'
  print @tmpString
  create table #TestTmpTable2(
    Id numeric(18,0),
    Val varchar(254)
  )
  set @tmpString=@SPName||' create table # (end)'
  print @tmpString

  set @tmpString=@SPName||' exec SP (begin)'
  print @tmpString
  execute TestTmpTable2Child
  set @tmpString=@SPName||' exec SP (end)'
  print @tmpString

  set @tmpString=@SPName||' select * from # (begin)'
  print @tmpString
  select
    *
  from
    #TestTmpTable2
  set @tmpString=@SPName||' select * from # (end)'
  print @tmpString

  drop table #TestTmpTable2
end
go
