declare
	@t table (id int, f1 int, f2 int)

delete from @t
insert into @t (id, f1, f2) values (1, 1, 1)
insert into @t (id, f1, f2) values (2, 1, 2)
insert into @t (id, f1, f2) values (3, 1, null)
insert into @t (id, f1, f2) values (4, 2, 1)
insert into @t (id, f1, f2) values (5, 2, null)
insert into @t (id, f1, f2) values (6, 3, null)

------------------------------------------------------------

select * from @t

/*select
	*
from
	@t t
	left join @t te on (te.f1=t.f1) and (te.f2 is not null)
where
	(t.f2 is null)
	and (te.id is not null)*/

delete
	t
	--@t -- The table '@t' is ambiguous
from
	@t t
	left join @t te on (te.f1=t.f1) and (te.f2 is not null)
where
	(t.f2 is null)
	and (te.id is not null)

select * from @t

------------------------------------------------------------

delete from @t
insert into @t (id, f1, f2) values (1, 1, 1)
insert into @t (id, f1, f2) values (2, 1, 2)
insert into @t (id, f1, f2) values (3, 1, null)
insert into @t (id, f1, f2) values (4, 2, 1)
insert into @t (id, f1, f2) values (5, 2, null)
insert into @t (id, f1, f2) values (6, 3, null)

select * from @t

delete
	@t
from
	@t t
where
	exists
	(
		select 1 from @t ti where (ti.f1=t.f1) and (ti.f2 is not null)
	)
	and (t.f2 is null)

select * from @t
