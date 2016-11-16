declare @t1 table(id int)
declare @t2 table(id int)

;with cte(id)
as
(
	select 1
	union all
	select id + 1
	from cte
	where id < 10
)
insert into @t1 (id)
select id
from cte
option (maxrecursion 0)

;with cte(id)
as
(
	select 5
	union all
	select id + 1
	from cte
	where id < 15
)
insert into @t2 (id)
select id
from cte
option (maxrecursion 0)

--select * from @t1
--select * from @t2

select
	id
from
	@t1
except
select
	id
from
	@t2

select
	*
from
	@t1 t1
	left join @t2 t2 on t2.id = t1.id 
where
	t2.id is null

select
	id
from
	@t1
intersect
select
	id
from
	@t2

select
	*
from
	@t1 t1
	left join @t2 t2 on t2.id = t1.id 
where
	t2.id is not null