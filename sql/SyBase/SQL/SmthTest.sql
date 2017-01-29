declare
@a D_MONEY,
@b D_Money,
@c D_Money,
@tmpStr varchar(255)

set @a=5
set @b=10
set @c=@a-@b
set @tmpStr=coalesce(convert(varchar(255),@c),'NULL')
print @tmpStr
