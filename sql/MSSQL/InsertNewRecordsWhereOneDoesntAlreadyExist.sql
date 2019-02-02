/* http://cc.davelozinski.com/sql/fastest-way-to-insert-new-records-where-one-doesnt-already-exist */

declare @t1 table (id int, value varchar(128));
;with cte(id, value)
as
(
	select 1, cast('Record# 1' as varchar(128))
	union all
	select id + 1, cast('Record# ' + cast(id + 1 as varchar(2)) as varchar(128))
	from cte
	where id < 6
)
insert into @t1 (id, value)
select id, value
from cte
option (maxrecursion 0);

declare @t2 table (id int identity, t1Id int);
insert into @t2 (t1Id) values (1);
select * from @t1 t1 left join @t2 t2 on t2.t1Id = t1.id;

--

if not exists (select 1 from @t2 where t1Id = 2)
	insert into @t2 (t1Id) values (2);

select * from @t1 t1 left join @t2 t2 on t2.t1Id = t1.id;

--

merge into @t2 as tgt
using
(
	select
		id
	from
		@t1
	where
		id = 3
) as src
on tgt.t1Id = src.id
when not matched
then
	insert (t1Id) values (src.id);

select * from @t1 t1 left join @t2 t2 on t2.t1Id = t1.id;

--

insert into @t2 (t1Id)
select id from @t1 where id < 5
except
select t1Id from @t2;

select * from @t1 t1 left join @t2 t2 on t2.t1Id = t1.id;

--

insert into @t2 (t1Id)
select
	t1.id
from
	@t1 t1
	left join @t2 t2 on t2.t1Id = t1.id
where
	t1.id = 5
	and t2.id is null;

select * from @t1 t1 left join @t2 t2 on t2.t1Id = t1.id;
