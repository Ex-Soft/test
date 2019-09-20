declare
	@a int = 1,
	@b int = 5,
	@c int = 3

if @c between @a and @b
	print convert(nchar(1), @c) + N' between ' + convert(nchar(1), @a) + ' and ' + convert(nchar(1), @b)
else
	print N'! ' + convert(nchar(1), @c) + N' between ' + convert(nchar(1), @a) + ' and ' + convert(nchar(1), @b)

if @c between @b and @a
	print convert(nchar(1), @c) + N' between ' + convert(nchar(1), @b) + ' and ' + convert(nchar(1), @a)
else
	print N'! ' + convert(nchar(1), @c) + N' between ' + convert(nchar(1), @b) + ' and ' + convert(nchar(1), @a)