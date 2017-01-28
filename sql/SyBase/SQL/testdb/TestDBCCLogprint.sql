use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('TestDBCCLogprint')
             and type='P')
   drop procedure TestDBCCLogprint
go

create procedure TestDBCCLogprint   
  @Message varchar(255)   
as   
begin   
  declare   
    @tmpStr varchar(1023),   
    @RetValue int   
   
  set @tmpStr=convert(varchar(64),getdate(),109)||' TestDBCCLogprint: '''||coalesce(@Message,'NULL')||''''   
  
  print @tmpStr  
   
  dbcc logprint(@tmpStr)   
     
  set @RetValue=@@error   
   
  return(@RetValue)   
end
go
