declare @t table (v nvarchar(5))
insert into @t values (N'123456')
select * from @t

declare
  @a int,
  @s1 nvarchar(256),
  @s2 nvarchar(256)

set @s1 = N'123 567'
set @s2 = stuff(@s1, 4, 1, '') -- '123567'
print N'''' + @s2 + N''''

set @s1 = N'1st/2nd/3rd'
select right(@s1, charindex(N'/', reverse(@s1)) - 1)

set @s1 = N'image.jpg'
select @s1, reverse(@s1), charindex(N'.', reverse(@s1)), left(@s1, len(@s1) - charindex(N'.', reverse(@s1))), left(@s1, len(@s1) - charindex(N'.', reverse(@s1))) + N'_suffix' + right(@s1, charindex(N'.', reverse(@s1)))

set @s1 = null
set @a = len(@s1)
print len(@s1) -- nothing Ж8-/ because null
print len(coalesce(@s1, N'')) -- 0
if @a is null
	print N'null' -- null
else
	print @a

set @a=111
set @s1=cast(@a as nvarchar(256))
set @s2=convert(nvarchar(256),@a)

print len(@s1)
print len(@s2)

/* concatenate string */
/* http://www.kodyaz.com/articles/concatenate-using-xml-path.aspx */
select name from Staff for xml path('record') /* <record><name>Ленин Владимир Ильич</name></record><record><name>Сталин Иосиф Виссарионович</name></record> */
select name from Staff for xml path('') /* <name>Ленин Владимир Ильич</name><name>Сталин Иосиф Виссарионович</name> */
select ', ' + name from Staff for xml path('record') /* <record>, Ленин Владимир Ильич</record><record>, Сталин Иосиф Виссарионович</record> */
select ', ' + name as aaa from Staff for xml path('') /* <aaa>, Ленин Владимир Ильич</aaa><aaa>, Сталин Иосиф Виссарионович</aaa> */
select ', ' + name from Staff for xml path('') /* , Ленин Владимир Ильич, Сталин Иосиф Виссарионович */
select stuff((select ', ' + name from Staff for xml path('')), 1, 2, '') as concatenated_string /* Ленин Владимир Ильич, Сталин Иосиф Виссарионович */

declare
  @ReturnValue nvarchar(max),
  @separator nvarchar(max)

set @separator=', '

select
  @ReturnValue = coalesce(@ReturnValue, '') + S1.name + @separator
from
  Staff S1
  join Staff S2 on S1.ID = S2.ID

set @ReturnValue = left(@ReturnValue, len(@ReturnValue)-len(@separator)) 

select @ReturnValue

declare
	@nullStr nvarchar(max),
	@emptyStr nvarchar(max),
	@notEmptyString nvarchar(max),
	@tmpString nvarchar(max)

set @emptyStr=N''
set @notEmptyString=N'123456789'

if @nullStr is null
	print N'@nullStr is null'		-- @nullStr is null
else
	print N'@nullStr is not null'

if @emptyStr is null
	print N'@emptyStr is null'
else
	print N'@emptyStr is not null'	-- @emptyStr is not null

if @nullStr=@emptyStr
	print N'@nullStr=@emptyStr'
else
	print N'@nullStr!=@emptyStr'	-- @nullStr!=@emptyStr

if @emptyStr=@nullStr
	print N'@emptyStr=@nullStr'
else
	print N'@emptyStr!=@nullStr'	-- @emptyStr!=@nullStr

set @tmpString=@nullStr+@notEmptyString
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=@notEmptyString+@nullStr
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=ltrim(@nullStr)
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=rtrim(@nullStr)
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=ltrim(rtrim(@nullStr))
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=left(ltrim(rtrim(@nullStr)), 10)
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=nullif(@emptyStr,N'')
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=nullif(@nullStr,N'')
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=nullif(@emptyStr,N'')
if @tmpString is not null
	print N''''+@tmpString+N''''
else
	print N'@tmpString is null'		-- @tmpString is null

set @tmpString=nullif(@notEmptyString,N'')
if @tmpString is not null
	print N''''+@tmpString+N''''		-- '123456789'
else
	print N'@tmpString is null'

set @tmpString=ltrim(rtrim(isnull(@nullStr,N'')))
if @tmpString is not null
	print N''''+@tmpString+N''''	-- ''
else
	print N'@tmpString is null'

declare
	@a bigint,
	@b nvarchar(max)

set @a=null
set @b=case when @a is not null then convert(nvarchar(max), @a) else N'NULL' end
print @b -- @b=N'NULL'

------------------------------------------------------------

declare
	@signature1 nvarchar(200),
	@signature2 nvarchar(200),
	@i int,
	@suffix nvarchar(200),
	@tmpString nvarchar(max)

set @signature1=N'signature'
set @signature2=N'SIGNATURE'

declare
	@tSrc table (name nvarchar(200))

declare
	@tDest table (name nvarchar(200))

set @i=1
while @i<=15
begin
	if @i%2=0
		set @suffix=N' '
	else
		set @suffix=N'_'

	insert into @tSrc (name) values (@signature1+@suffix+CONVERT(nvarchar(200), @i))
	set @i=@i+1
end

select * from @tSrc

insert into
	@tDest
select
	name
from
	@tSrc
where
	name like @signature1+N' %'

select
	name,
	len(name),
	len(@signature1),
	substring(name, len(@signature1)+2, 2)
from
	@tDest

select
	N',' + @signature2 + substring(name, len(@signature1)+2, 2)
from
	@tDest
for xml path('')

set @tmpString=(select
	N',' + @signature2 + substring(name, len(@signature1)+2, 2)
from
	@tDest
for xml path(''))

print @tmpString

------------------------------------------------------------

set @tmpString=N'58_blah'
select charindex(N'_', @tmpString) -- 3
select charindex(N'W', @tmpString) -- 0
select substring(@tmpString, 1, charindex(N'_', @tmpString)-1) -- 58
select substring(@tmpString, charindex(N'_', @tmpString)+1, len(@tmpString)-charindex(N'_', @tmpString)) -- blah

------------------------------------------------------------

declare
	@HtmlBody nvarchar(max),
	@signature nvarchar(max)=N'%<IMG   src="%',
	@posBegin bigint,
	@posEnd bigint,
	@str nvarchar(max)

set @HtmlBody=N'<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">  <HTML><HEAD>  <META content="text/html; charset=windows-1251" http-equiv=Content-Type>  <META name=GENERATOR content="MSHTML 10.00.9200.16660"></HEAD>  <BODY contentEditable=true>  <P>Информация о товаре:</P>  <P><IMG   src="17958.jpg"></P></BODY></HTML>'
set @posBegin=patindex(@signature, @HtmlBody)+len(@signature)-3
set @posEnd=charindex(N'"', @HtmlBody, @posBegin+1)
set @str=substring(@HtmlBody, 1, @posBegin)+N'blah-blah-blah'+substring(@HtmlBody, @posEnd, len(@HtmlBody)-@posEnd+1)
print @str

------------------------------------------------------------

declare
	@tmpStr nvarchar(max),
	@len int,
	@i int,
	@tmpChar nchar(1)

set @tmpStr=char(13)+char(10)+N'abcd'
set @len=len(@tmpStr)
set @i=1

while @i<=@len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1)
		print ascii(@tmpChar)
		set @i = @i+1
	end

------------------------------------------------------------

/* split */

declare
	@tmpStr nvarchar(max),
	@delimeter nvarchar(max) = N', '

select @tmpStr = stuff((select @delimeter + Name from sys.objects where type = N'U' and Name like N'!_exportXls%' escape N'!' for xml path(N'')), 1, len(@delimeter), N'')
print @tmpStr

declare @x xml

select @x = cast(N'<root><name>' + replace(@tmpStr, @delimeter, N'</name><name>') + N'</name></root>' as xml)
select @x

select
  n.v.query('.')
from
  @x.nodes('root/name/text()') as n(v)

select @x = cast(N'<name>' + replace(@tmpStr, @delimeter, N'</name><name>') + N'</name>' as xml)
select @x

select
  n.v.query('.')
from
  @x.nodes('name/text()') as n(v)