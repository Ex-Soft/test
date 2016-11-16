--execute('select aspnetuser.FunctionWOutputND(?, ?) from dual','aaaa',1) at typhoon

--select * from openquery(typhoon,'select aspnetuser.FunctionWOutputND(''ssss'', 1) from dual')
/*
select * from openquery(typhoon,'{call aspnetuser.test_simpleprocedure(1, 2, {resultset 25, c})}')

declare
  @a decimal,
  @b decimal,
  @c decimal

set @a=1
set @b=2
set @c=null

exec ('{call aspnetuser.test_simpleprocedure(?, ?, ?)}', @a, @b, @c output) at typhoon
select @c

declare
  @Id_in int,
  @FVarchar2_in nvarchar(50)

set @Id_in=1
set @FVarchar2_in='M$ SQL'

exec ('{call aspnetuser.updatetesttabletypes(?, ?)}', @Id_In, @FVarchar2_in) at typhoon
*/

declare
  @a bigint

select @a=nextval from openquery(typhoon,'select aspnetuser.s_tbl_demands.nextval from dual')

select @a