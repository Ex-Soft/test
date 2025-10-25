use testdb;
go

if object_id(N'TestFunctionReturnOnly', N'fn') is not null
	drop function TestFunctionReturnOnly;
go

create function TestFunctionReturnOnly (@a int, @b int)
returns int
as
begin
	declare
		@result int;

	set @result = @a + @b;

	return @result;
end;
go
