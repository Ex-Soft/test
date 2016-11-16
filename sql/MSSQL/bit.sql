declare
	@smthInt int = 15,
	@int1 int = 1,
	@int2 int = 2,
	@int4 int = 4,
	@int8 int = 8,
	@result int

set @result = @smthInt & @int1
print @result

set @result = @smthInt & @int2
print @result

set @result = @smthInt & @int4
print @result

set @result = @smthInt & @int8
print @result