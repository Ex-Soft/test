declare
	@val int

declare @t table (val int)

insert into @t (val) values (1)
insert into @t (val) values (2)
insert into @t (val) values (3)
insert into @t (val) values (null)
insert into @t (val) values (null)

set @val = 1
select * from @t where val = @val

set @val = null
select * from @t where val = @val

------------------------------------------------------------

declare
	@a int,
	@b int,
	@c int

set @a = null
set @b = null
set @c = @a + @b -- null
if @c is not null
	print @c
else
	print N'@c is null'

set @a = 1
set @b = null
set @c = @a + @b -- null
if @c is not null
	print @c
else
	print N'@c is null'

set @a = null
set @b = 1
set @c = @a + @b -- null
if @c is not null
	print @c
else
	print N'@c is null'

set @a = 1
set @b = 1
set @c = @a + @b -- 2
if @c is not null
	print @c
else
	print N'@c is null'

------------------------------------------------------------

declare
	@val int

set @val=1

select
	*
from
	TestTableWithNullField
where
	(val=@val) or (@val is null)

set @val=null

select
	*
from
	TestTableWithNullField
where
	(val=@val) or (@val is null)
