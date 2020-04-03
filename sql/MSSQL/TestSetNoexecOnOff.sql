if object_id(N'TestSetNoexecOnOff', N'p') is not null
	set noexec on;
go

create procedure TestSetNoexecOnOff
as
	set nocount on;
go

set noexec off;
go

alter procedure TestSetNoexecOnOff
	@input_param1 int,
	@input_param2 int,
	@output_param int output
as
begin
	set nocount on;

	print N'TestSetNoexecOnOff';

	set @output_param = @input_param1 + @input_param2;

	return 0;
end
go

declare @output int
exec TestSetNoexecOnOff @input_param1 = 1, @input_param2 = 2, @output_param = @output out
print @output

--drop procedure TestSetNoexecOnOff