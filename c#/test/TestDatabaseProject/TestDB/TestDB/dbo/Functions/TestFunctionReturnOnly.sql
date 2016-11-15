
create function TestFunctionReturnOnly (@a int, @b int)
returns int
as
begin
	declare
		@result int
    
	set @result=@a+@b
  
	return @result
end
