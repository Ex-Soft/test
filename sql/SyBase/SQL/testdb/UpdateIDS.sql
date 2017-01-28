use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('UpdateIDS')
             and type='P')
   drop procedure UpdateIDS
go

create procedure UpdateIDS 
  @TABLE_ID int, 
  @VALUE_ID numeric(18,0), 
  @TABLE_NAME D_SYSNAME, 
  @SLEEP char(8)=null 
as 
begin 
 
  declare 
    @ReturnValue int,
    @tmpStr varchar(1024) 
 
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') started @ '||convert(varchar(64),getdate(),109) 
  print @tmpStr 
 
  if exists (select 1 
             from IDS 
             where 
               TABLE_ID=@TABLE_ID) 
    begin 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE started @ '||convert(varchar(64),getdate(),109) 
      print @tmpStr 
 
      update 
        IDS 
      set 
        VALUE_ID=@VALUE_ID, 
        TABLE_NAME=@TABLE_NAME 
      where 
        TABLE_ID=@TABLE_ID 
      set @ReturnValue=@@error

      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') UPDATE finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')'
      print @tmpStr 
    end 
  else 
    begin 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT started @ '||convert(varchar(64),getdate(),109) 
      print @tmpStr 
 
      insert into IDS 
      (TABLE_ID, VALUE_ID, TABLE_NAME) 
      values 
      (@TABLE_ID, @VALUE_ID, @TABLE_NAME) 
      set @ReturnValue=@@error

      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') INSERT finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')'
      print @tmpStr 
    end 
  if @SLEEP is not null 
    begin 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR started @ '||convert(varchar(64),getdate(),109) 
      print @tmpStr 
 
      waitfor delay @SLEEP 
 
      set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') WAITFOR finished @ '||convert(varchar(64),getdate(),109) 
      print @tmpStr 
    end 
 
  set @tmpStr='UpdateIDS (@@spid='||convert(varchar(64),@@spid)||') finished @ '||convert(varchar(64),getdate(),109)||' (ReturnValue='||convert(varchar(64),@ReturnValue)||')' 
  print @tmpStr

  return(@ReturnValue)
end
go
