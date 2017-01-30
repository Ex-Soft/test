select
ascii('A'),
char(65),
charindex('B','ABC'),charindex('Z','ABC'),
char_length('ABC'),
lower('ABC'), lower('???'),
ltrim('   ABC'),
replicate('ABC',3),
reverse('ABC'),
right('ABC',2),
rtrim('ABC       '),
space(3),
str(999.99,18,6),
stuff('ABC',2,1,'Z'),
substring('ABC',2,1),
upper('abc'),upper('???')

set identity_insert TEST_CHAR on
insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0xad"),
char(hextoint("0xad"))+" 0xad")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2d"),
char(hextoint("0x2d"))+" 0x2d")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2c"),
char(hextoint("0x2c"))+" 0x2c")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3b"),
char(hextoint("0x3b"))+" 0x3b")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3a"),
char(hextoint("0x3a"))+" 0x3a")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x21"),
char(hextoint("0x21"))+" 0x21")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3f"),
char(hextoint("0x3f"))+" 0x3f")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2f"),
char(hextoint("0x2f"))+" 0x2f")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2e"),
char(hextoint("0x2e"))+" 0x2e")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x60"),
char(hextoint("0x60"))+" 0x60")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x5e"),
char(hextoint("0x5e"))+" 0x5e")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x7e"),
char(hextoint("0x7e"))+" 0x7e")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x27"),
char(hextoint("0x27"))+" 0x27")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x22"),
char(hextoint("0x22"))+" 0x22")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x28"),
char(hextoint("0x28"))+" 0x28")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x29"),
char(hextoint("0x29"))+" 0x29")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x5b"),
char(hextoint("0x5b"))+" 0x5b")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x5d"),
char(hextoint("0x5d"))+" 0x5d")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x7b"),
char(hextoint("0x7b"))+" 0x7b")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x7d"),
char(hextoint("0x7d"))+" 0x7d")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0xa7"),
char(hextoint("0xa7"))+" 0xa7")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x40"),
char(hextoint("0x40"))+" 0x40")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x24"),
char(hextoint("0x24"))+" 0x24")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2a"),
char(hextoint("0x2a"))+" 0x2a")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x5c"),
char(hextoint("0x5c"))+" 0x5c")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x26"),
char(hextoint("0x26"))+" 0x26")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0xb9"),
char(hextoint("0xb9"))+" 0xb9")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x23"),
char(hextoint("0x23"))+" 0x23")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x25"),
char(hextoint("0x25"))+" 0x25")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x2b"),
char(hextoint("0x2b"))+" 0x2b")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3c"),
char(hextoint("0x3c"))+" 0x3c")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3d"),
char(hextoint("0x3d"))+" 0x3d")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x3e"),
char(hextoint("0x3e"))+" 0x3e")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x7c"),
char(hextoint("0x7c"))+" 0x7c")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0x7f"),
char(hextoint("0x7f"))+" 0x7f")

insert into TEST_CHAR (ID,FCHAR) values (
hextoint("0xa0"),
char(hextoint("0xa0"))+" 0xa0")

set identity_insert TEST_CHAR off

------------------------------------------------------------
declare
@str varchar(1024),
@i int,
@len int,
@tmpChar varchar(1024),
@code int

set @i=224
set @str=null
while @i<=255
begin
set @str=@str||char(@i-32)||char(@i)
set @i=@i+1
end
set @str=@str||char(165 /* 0x0a5 */)||char(180 /* 0x0b4 */)
set @str=@str||char(129 /* 0x081 */)||char(131 /* 0x083 */)
set @str=@str||char(128 /* 0x080 */)||char(144 /* 0x090 */)
set @str=@str||char(170 /* 0x0aa */)||char(186 /* 0x0ba */)
set @str=@str||char(168 /* 0x0a8 */)||char(184 /* 0x0b8 */)
set @str=@str||char(189 /* 0x0bd */)||char(190 /* 0x0be */)
set @str=@str||char(178 /* 0x0b2 */)||char(179 /* 0x0b3 */)
set @str=@str||char(175 /* 0x0af */)||char(191 /* 0x0bf */)
set @str=@str||char(163 /* 0x0a3 */)||char(188 /* 0x0bc */)
set @str=@str||char(141 /* 0x08d */)||char(157 /* 0x09d */)
set @str=@str||char(138 /* 0x08a */)||char(154 /* 0x09a */)
set @str=@str||char(140 /* 0x08c */)||char(156 /* 0x09c */)
set @str=@str||char(142 /* 0x08e */)||char(158 /* 0x09e */)
set @str=@str||char(161 /* 0x0a1 */)||char(162 /* 0x0a2 */)
set @str=@str||char(143 /* 0x08f */)||char(159 /* 0x09f */)
print @str

/* set @str=convert(varchar(32),char_length(@str))
print @str */

set @len=char_length(@str)
set @i=1
set identity_insert TEST_CHAR on
while @i<=@len
begin
set @code=ascii(substring(@str,@i,1))
if not exists (select 1 from TEST_CHAR where ID=@code)
begin
set @tmpChar=inttohex(@code)
set @tmpChar=lower(@tmpChar)
set @tmpChar=substring(@tmpChar,7,2)
set @tmpChar=substring(@str,@i,1)||' 0x'||@tmpChar
print @tmpChar
insert into TEST_CHAR (ID,FCHAR) values (@code,@tmpChar)
end
set @i=@i+1
end
set identity_insert TEST_CHAR off

select * from test_char order by id
------------------------------------------------------------
declare
@str varchar(1024),
@i int,
@len int,
@tmpChar varchar(1024),
@code int

select @str=fchar from test_char where id=1 /*set @str='0123456789abcdefghijklmnopqrstuvwxyz'*/
set @len=char_length(@str)
set @i=1
while @i<=@len
begin
set @code=ascii(substring(@str,@i,1))
set @tmpChar=substring(@str,@i,1)||' ('||convert(varchar(32),@code)||' (0X'||inttohex(@code)||'))'
print @tmpChar
set @i=@i+1
end
/* select char(188) */
------------------------------------------------------------


declare
  @a int,
  @tmpStr varchar(255)

set @a=null

if @a is null
  print '@a is NULL'
else
  print '@a is not NULL'

set @tmpStr=convert(varchar(255),@a)

if @tmpStr is null
  print '@tmpStr is NULL'
else
  print '@tmpStr is not NULL'

set @tmpStr=''''||convert(varchar(255),@a)||''''
print @tmpStr

set @a=char_length(@tmpStr)
set @tmpStr=convert(varchar(255),@a)
print @tmpStr

set @a=null
set @tmpStr=coalesce(convert(varchar(255),@a),'@a is NULL (by coalesce)')
print @tmpStr
set @tmpStr=isnull(convert(varchar(255),@a),'@a is NULL (by isnull)')
print @tmpStr

set @tmpStr=''''||null||''''
set @a=char_length(@tmpStr)
set @tmpStr=convert(varchar(255),@a)
print @tmpStr

set @tmpStr=''''||''||''''
print @tmpStr
set @a=char_length(@tmpStr)
set @tmpStr=convert(varchar(255),@a)
print @tmpStr


------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------