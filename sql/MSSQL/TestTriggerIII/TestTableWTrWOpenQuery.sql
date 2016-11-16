if object_id('TestTableWTrWOpenQuery', 'u') is not null
  drop table TestTableWTrWOpenQuery
go

create table TestTableWTrWOpenQuery
(
   Id int identity,
   Val int
)
go

if object_id('tr_TestTableWTrWOpenQuery', 'tr') is not null
  drop trigger tr_TestTableWTrWOpenQuery
go

create trigger tr_TestTableWTrWOpenQuery
on TestTableWTrWOpenQuery
for insert, update, delete
as
begin

  set nocount on

  exec SendToTyphoonCreator 22023, 'Test', 4, 'Test'
end
go

/* update openquery(typhoon, 'select fsmallint, fint from aspnetuser.testtabletypes where id=1') set fsmallint=null, fint=null */