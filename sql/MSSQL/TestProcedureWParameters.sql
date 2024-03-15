use testdb;
go

if object_id(N'dbo.TestProcedureWParameters', N'p') is not null
	drop procedure dbo.TestProcedureWParameters;
go

create procedure dbo.TestProcedureWParameters
	@input_param int,
	@output_param int = null output
as
begin
	set nocount on;

	set @output_param = @input_param;

	/*
	select id, f1, f2
	from
	(
		values
			(1, N'1', N'1.1'),
			(2, N'1', N'1.2'),
			(3, N'2', N'2.1'),
			(4, N'2', N'2.2'),
			(5, N'3', N'3.1'),
			(6, N'3', N'3.2')
	) t (id, f1, f2);
	*/

	return @input_param * @output_param;
end;
go

declare @return_value int, @output int;
exec @return_value = dbo.TestProcedureWParameters @input_param = 13, @output_param = @output out;
print @return_value;
print @output;
