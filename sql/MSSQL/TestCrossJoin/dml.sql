declare
	@t1 table (f1 nvarchar(255), f2 int, f3 int)

declare
	@t2 table (f1 nvarchar(255))

declare
	@t3 table (f1 int)

insert into @t1 (f1, f2, f3) values (N'POS# 1 123', 1, 123)
insert into @t1 (f1, f2, f3) values (N'POS# 1 321', 1, 321)
insert into @t1 (f1, f2, f3) values (N'POS# 2 123', 2, 123)

insert into @t2 (f1) values (N'A')
insert into @t2 (f1) values (N'B')
insert into @t2 (f1) values (N'C')

insert into @t3 (f1) values (123)

select
	*
from
	@t1 t1
	cross join @t2 t2
	left join @t3 t3 on (t3.f1=t1.f3)
where
	(t1.f2=1)
	and (t3.f1 is null)
order by t1.f1