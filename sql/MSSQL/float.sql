declare
	@f float = 123.445,
	@i int

set @i = cast(@f as int)
print round(@f, 0)
print floor(@f)
print @i
print ceiling(@f)
print round(@f, 1)
print round(@f, 2)

set @f = 123.567
set @i = cast(@f as int)

print round(@f, 0)
print floor(@f)
print @i
print ceiling(@f)
print round(@f, 1)
print round(@f, 2)
