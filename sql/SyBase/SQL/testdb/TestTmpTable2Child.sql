use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TestTmpTable2Child'))
             and (type = 'P'))
   drop procedure TestTmpTable2Child
go

create procedure TestTmpTable2Child
as
begin
  set nocount on

  declare
    @SPName varchar(254),
    @tmpString varchar(254)

  set @SPName='TestTmpTable2Child'

  set @tmpString=@SPName||' insert into # (begin)'
  print @tmpString
  insert into #TestTmpTable2 (Id, Val) values (1, 'A')
  insert into #TestTmpTable2 (Id, Val) values (2, 'B')
  insert into #TestTmpTable2 (Id, Val) values (3, 'C')
  set @tmpString=@SPName||' insert into # (end)'
  print @tmpString
end
go
