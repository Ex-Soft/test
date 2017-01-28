use testdb
go

if exists (select 1
           from sysobjects
           where id=object_id('TestExec')
                 and type='P')
   drop procedure TestExec
go

/*==============================================================*/
/* Stored procedure: TestExec                                   */
/*==============================================================*/
create procedure TestExec
  @SLEEP char(8)=null
as
begin
  declare
    @rc int,
    @tmpString varchar(1024),
    @max int

  set @max=5

  set @tmpString='select * from Staff order by ID'
  exec (@tmpString)
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set @tmpString='set rowcount 5'
  exec (@tmpString)
  select * from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set @tmpString='set rowcount 0'
  exec (@tmpString)
  select * from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  set rowcount @max
  select * from Staff order by ID
  set @rc=@@rowcount
  set @tmpString='@@rowcount='||convert(varchar(32),@rc)
  print @tmpString

  if @SLEEP is not null
    begin
      set @tmpString='begin waitfor delay '''||@SLEEP||''''
      print @tmpString
      waitfor delay @SLEEP
      print 'end waitfor'
    end

  set rowcount 0
end
go