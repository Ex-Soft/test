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

print format(12345678,  N'مجموع' + N' 0 00 ' + N'ع.ت')
print format(12345678,  N'مجموع' + @ltr + N' 0 00 ' + @rtl + N'ع.ت')

set @s = N'كلمة قبل {0} كلمة بعد.'
set @s = replace(@s, N'{0}', N'800 4969')
print @s

set @s = N'كلمة قبل {0} كلمة بعد.'
set @s = replace(@s, N'{0}', N'800' + nchar(0x00a0) + '4969')
print @s

set @s = N'قبل {0} بعد'

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
	@nchar2 nchar(1),
	@str nvarchar(max),
	@msg nvarchar(max)

select @str = N'800 4969', @i = 1
print N'''' + @str + N''''
set @len = len(@str)
while @i <= @len
	begin
		set @nchar1 = substring(@str, @i, 1)
		set @msg = @str + N'[' + cast(@i as nvarchar(10)) + N'] = ''' + @nchar1 + N''' (' + cast(master.dbo.fn_varbintohexstr(unicode(@nchar1)) as nvarchar(10)) + N')'
		print @msg
		set @i += 1
	end

select @str = replace(@str, nchar(0x0020), nchar(0x00a0)), @i = 1
print N'''' + @str + N''''
set @len = len(@str)
while @i <= @len
	begin
		set @nchar1 = substring(@str, @i, 1)
		set @msg = @str + N'[' + cast(@i as nvarchar(10)) + N'] = ''' + @nchar1 + N''' (' + cast(master.dbo.fn_varbintohexstr(unicode(@nchar1)) as nvarchar(10)) + N')'
		print @msg
		set @i += 1
	end

select @str = FNVarCharMax from TestTable4Types where Id = 4
set @len = len(@str)
while @i <= @len
	begin
		set @nchar1 = substring(@str, @i, 1)
		print @nchar1
		print unicode(@nchar1)
		set @i += 1
	end

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

set @i = 1
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
