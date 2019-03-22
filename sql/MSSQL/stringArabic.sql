declare
	@s1 nvarchar(max) = N'هذه الجملة هي رقم 1. هذه الجملة هي رقم 2.',
	@s2 nvarchar(max) = N'هذا الاقتراح هو رقم 3. هذا الاقتراح هو رقم 4.',
	@s3 nvarchar(max) = N'هذا الاقتراح رقم 5. هذا الاقتراح رقم 6.',
	@result1 nvarchar(max) = N'هذا الاقتراح هو 1. هذا هو الاقتراح رقم 2. هذا هو الاقتراح رقم 3. هذا هو الاقتراح رقم 4. هذا هو الاقتراح رقم 5. هذا هو الاقتراح رقم 6.',
	@result2 nvarchar(max),
	@i int = 1,
	@len1 int,
	@len2 int,
	@len int,
	@nchar1 nchar(1),
	@nchar2 nchar(1)

set @result2 = @s1 + N' '+ @s2 + N' ' + @s3;

print @result1
print @result2

set @len1 = len(@result1)
set @len2 = len(@result2)

if @len1 <= @len2
	set @len = @len1
else
	set @len = @len2

while @i <= @len
	begin
		set @nchar1 = substring(@result1, @i, 1)
		set @nchar2 = substring(@result2, @i, 1)
		print N' '
		print @i
		print @nchar1
		print @nchar2
		if @nchar1 = @nchar2
			print N'='
		else
			print N'!='
		set @i += 1
	end