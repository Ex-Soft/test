use testdb
go

if object_id(N'TestFunctionWithDelay', N'fn') is not null
	drop function TestFunctionWithDelay
go

create function TestFunctionWithDelay (@in int, @sleep char(8))
returns int
as
begin
	/*
	Msg 443, Level 16, State 14, Procedure TestFunctionWithDelay, Line 6
	Invalid use of a side-effecting operator 'WAITFOR' within a function.
	*/
	waitfor delay @sleep
	return @in
end
go
