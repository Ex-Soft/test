declare
  @a bit,
  @b bit,
  @c bit,
  @tmpStr char(255)

set @a=0
set @b=0
set @c=0
set @tmpStr=convert(char(1),@a)+convert(char(1),@b)+convert(char(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' true'
else
  set @tmpStr=@tmpStr+' false'
print @tmpStr

declare
  @a bit,
  @b bit,
  @c bit,
  @tmpStr varchar(255)

set @a=0
set @b=0
set @c=0
set @tmpStr=convert(char(1),@a)+convert(char(1),@b)+convert(char(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' true'
else
  set @tmpStr=@tmpStr+' false'
print @tmpStr
