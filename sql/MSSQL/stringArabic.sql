declare
	@s nvarchar(max) = N'قبل {0} بعد',
	@before nvarchar(max) = N'قبل',
	@before_ nvarchar(max) = N'قبل ',
	@after nvarchar(max) = N'بعد',
	@_after nvarchar(max) = N' بعد',
	@r nvarchar(max),
	@ltrEmbed nchar = nchar(0x202a),
	@popDirectional nchar = nchar(0x202c),
	@ltr nchar = nchar(0x200e),
	@rtl nchar = nchar(0x200f)

set @r = @before + N' {0} ' + @after
select N'''' + @r + N''' ' + iif(@r = @s, N'=', N'!') + N'=' + N' ''' + @s + N''''

set @r = @before_ + N'{0}' + @_after
select N'''' + @r + N''' ' + iif(@r = @s, N'=', N'!') + N'=' + N' ''' + @s + N''''

set @r = @before + N' ' + N'{0}' + N' ' + @after
select N'''' + @r + N''' ' + iif(@r = @s, N'=', N'!') + N'=' + N' ''' + @s + N''''

select
	@before + N' {0} ' + @after,
	@before_ + N'{0}' + @_after,
	@before + N' ' + N'{0}' + N' ' + @after,
	@before + N' ' + @ltr + N'{0}' + @popDirectional + N' ' + @after,
	@before + N' ' + @ltr + N'{0}' + @rtl + N' ' + @after

/*insert into TestTable4Types (Id, FNVarCharMax) values (1, @before + N' {0} ' + @after)
insert into TestTable4Types (Id, FNVarCharMax) values (2, @before + N' ' + N'{0}' + N' ' + @after)
insert into TestTable4Types (Id, FNVarCharMax) values (3, @before + N' ' + @ltrEmbed + N'{0}' + @popDirectional + N' ' + @after)
insert into TestTable4Types (Id, FNVarCharMax) values (4, @before + N' ' + @ltr + N'{0}' + @popDirectional + N' ' + @after)
insert into TestTable4Types (Id, FNVarCharMax) values (5, @before + N' ' + @ltr + N'{0}' + @rtl + N' ' + @after)*/

declare
	@s1 nvarchar(max) = N'هذه الجملة 1. هذه الجملة 2.',
	@s2 nvarchar(max) = N'هذه الجملة 3. هذه الجملة 4.',
	@s3 nvarchar(max) = N'هذه الجملة 5. هذه الجملة 6.',
	@result1 nvarchar(max) = N'هذه الجملة 1. هذه الجملة 2. هذه الجملة 3. هذه الجملة 4. هذه الجملة 5. هذه الجملة 6.',
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

print @len1
print @len2

if @len1 <= @len2
	set @len = @len1
else
	set @len = @len2

while @i <= @len
	begin
		set @nchar1 = substring(@result1, @i, 1)
		set @nchar2 = substring(@result2, @i, 1)
		if @nchar1 != @nchar2
			begin
				print N' '
				print @i
				print @nchar1
				print @nchar2
			end
		set @i += 1
	end

N'رقم السطر 1. رقم السطر 2. رقم السطر 3. رقم السطر 4. رقم السطر 5. رقم السطر 6.'
N'هذه الجملة 1. هذه الجملة 2. هذه الجملة 3. هذه الجملة 4. هذه الجملة 5. هذه الجملة 6.'