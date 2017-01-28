use testdb
go

if exists (select 1
           from  sysobjects
           where
             id=object_id('TestDisconnect')
             and type='P')
   drop procedure TestDisconnect
go

create procedure TestDisconnect
  @SLEEP char(8)=null,
  @WITH_TRANSACTION tinyint=null
as
begin
  declare 
    @ReturnValue int,
    @tmpStr varchar(1024) 
 
  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') started @ '||convert(varchar(64),getdate(),109) 
  insert into TableLog
  (FDateTime, spid, Message)
  values
  (getdate(), @@spid, @tmpStr)

  set @ReturnValue=@@error
  if(@ReturnValue!=0)
    return(@ReturnValue)

  if @WITH_TRANSACTION is not null
    begin
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') attempting to start transaction @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        return(@ReturnValue)

      begin transaction TestDisconnect

      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') transaction started @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        begin
          rollback transaction TestDisconnect
          return(@ReturnValue)
        end
    end

  if @SLEEP is not null 
    begin 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') WAITFOR started @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        begin
          if @WITH_TRANSACTION is not null
            rollback transaction TestDisconnect
          return(@ReturnValue)
        end

       waitfor delay @SLEEP 
 
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') WAITFOR finished @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        begin
          if @WITH_TRANSACTION is not null
            rollback transaction TestDisconnect
          return(@ReturnValue)
        end
    end 

  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') select started @ '||convert(varchar(64),getdate(),109) 
  insert into TableLog
  (FDateTime, spid, Message)
  values
  (getdate(), @@spid, @tmpStr)

  set @ReturnValue=@@error
  if(@ReturnValue!=0)
    begin
      if @WITH_TRANSACTION is not null
        rollback transaction TestDisconnect
      return(@ReturnValue)
    end

  select * from Staff

  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') select finished @ '||convert(varchar(64),getdate(),109) 
  insert into TableLog
  (FDateTime, spid, Message)
  values
  (getdate(), @@spid, @tmpStr)

  set @ReturnValue=@@error
  if(@ReturnValue!=0)
    begin
      if @WITH_TRANSACTION is not null
        rollback transaction TestDisconnect
      return(@ReturnValue)
    end

  if @WITH_TRANSACTION is not null
    begin
      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') attempting to commit transaction @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        begin
          rollback transaction TestDisconnect
          return(@ReturnValue)
        end

      commit transaction TestDisconnect

      set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') transaction commited @ '||convert(varchar(64),getdate(),109) 
      insert into TableLog
      (FDateTime, spid, Message)
      values
      (getdate(), @@spid, @tmpStr)

      set @ReturnValue=@@error
      if(@ReturnValue!=0)
        return(@ReturnValue)
    end

  set @tmpStr='TestDisconnect (@@spid='||convert(varchar(64),@@spid)||') finished @ '||convert(varchar(64),getdate(),109) 
  insert into TableLog
  (FDateTime, spid, Message)
  values
  (getdate(), @@spid, @tmpStr)

  set @ReturnValue=@@error

  return(@ReturnValue)
end
go