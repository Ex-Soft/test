if object_id('TestMasterInsert','p') is not null
  drop procedure TestMasterInsert
go

create procedure TestMasterInsert
  @Val varchar(255),
  @IsInsert bit=0
as
begin

  set nocount on
  
  if @IsInsert=1
    begin
      print 'insert'
      insert into pretensions..TestMaster (Val) values (@Val)
    end
end
go

grant execute on TestMasterInsert to TestIgor
go
