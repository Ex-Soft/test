declare
	@t table (f1 int, deleted bit)

insert into @t (f1, deleted) values (1, 0)
insert into @t (f1, deleted) values (2, 0)
insert into @t (f1, deleted) values (2, 1)
insert into @t (f1, deleted) values (3, 0)
insert into @t (f1, deleted) values (3, 1)
insert into @t (f1, deleted) values (3, 1)
insert into @t (f1, deleted) values (4, 1)

select
	*
from
	@t t

select
	*
from
	@t t
where
	((select count(*) from @t ti where (ti.f1=t.f1) and (ti.deleted=1))>=1)
	and (deleted=1)

select
	*
from
	@t t
where
	(t.deleted=0)
	and exists (select 1 from @t ti where (ti.f1=t.f1) and (ti.deleted=1))

delete from
	@t
where
	f1 in (
		select
			f1
		from
			@t t
		where
			(t.deleted=0)
			and exists (select 1 from @t ti where (ti.f1=t.f1) and (ti.deleted=1))
	)
	and (deleted=1)

select
	*
from
	@t