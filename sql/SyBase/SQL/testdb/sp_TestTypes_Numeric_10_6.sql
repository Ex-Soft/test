use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('sp_TestTypes_Numeric_10_6')
             and type='P')
   drop procedure sp_TestTypes_Numeric_10_6
go

create procedure sp_TestTypes_Numeric_10_6
  @FNumeric_10_6 numeric(10,6),  
  @FNumeric_10_6_out numeric(10,6) output  
as   
begin  
  declare  
    @RetVal int,
    @tmpStr varchar(1024)

  set @tmpStr='sp_TestTypes_Numeric_10_6: @FNumeric_10_6='||convert(varchar(64),@FNumeric_10_6)
  print @tmpStr
  dbcc logprint(@tmpStr)
  set @FNumeric_10_6_out =@FNumeric_10_6  
  set @tmpStr='sp_TestTypes_Numeric_10_6: @FNumeric_10_6='||convert(varchar(64),@FNumeric_10_6)||' @FNumeric_10_6_out='||convert(varchar(64),@FNumeric_10_6_out)
  print @tmpStr
  dbcc logprint(@tmpStr)

  select @RetVal=65535   
   
  return(@RetVal)  
end
go