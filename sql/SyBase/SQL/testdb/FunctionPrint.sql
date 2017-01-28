use testdb
go

if exists (select
             1
           from
             sysobjects
           where
             id=object_id('FunctionPrint')
             and type = 'SF')
  drop function FunctionPrint
go

create function FunctionPrint(@SmthString varchar(254))
returns varchar(254)
as
begin
  /*
  insert into TableLog
  (FDateTime, spid, Message)
  values
  (getdate(), @@spid, @SmthString)
  */

  print @SmthString

  /* dbcc logprint() */

  return(@SmthString)
end
go
