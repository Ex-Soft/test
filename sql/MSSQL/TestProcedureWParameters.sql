use testdb
go

if object_id(N'TestProcedureWParameters', N'p') is not null
	drop procedure TestProcedureWParameters
go

create procedure TestProcedureWParameters
	@input_param int,
	@output_param int output
as
begin
	set nocount on

	set @output_param=@input_param

	return 0
end
go