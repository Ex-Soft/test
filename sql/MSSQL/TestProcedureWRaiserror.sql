use testdb
go

if object_id('TestProcedureWRaiserror', 'p') is not null
  drop procedure TestProcedureWRaiserror
go

create procedure TestProcedureWRaiserror
  @input_param int,
  @output_param int output
as
begin

  set nocount on

  set @output_param=@input_param

  raiserror ('TestProcedureWRaiserror', 16, 1) with nowait

  return(0)
end
go