use testdb
go

if object_id(N'TestFunctionCalledSP', N'fn') is not null
  drop function TestFunctionCalledSP
go

create function TestFunctionCalledSP (@a int)
returns int
as
begin
  declare
    @result int
    
  exec TestProcedureWParameters @a, @result output /* Only functions and some extended stored procedures can be executed from within a function. */
  
  return @result
end
go