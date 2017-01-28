use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('sp_WithDefaultParam')
             and type='P')
   drop procedure sp_WithDefaultParam
go

create procedure sp_WithDefaultParam
  @Param1 int=null,  
  @Param2 int=null,  
  @Param3 int=null
as   
begin  
  declare  
    @RetVal int

  set @RetVal=0   

  select @Param1, @Param2, @Param3
   
  return(@RetVal)  
end
go