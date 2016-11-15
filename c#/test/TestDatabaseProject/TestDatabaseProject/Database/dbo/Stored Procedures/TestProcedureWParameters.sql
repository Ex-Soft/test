
create procedure TestProcedureWParameters
	@input_param int,
	@output_param int output
as
begin
	set nocount on

	set @output_param = @input_param * 2

	return 0
end
