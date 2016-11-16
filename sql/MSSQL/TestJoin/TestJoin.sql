declare @t table (id int)
declare @ids table (id int)

declare
	@idsCnt int,
	@testEmpty bit

set @testEmpty = 0

;with cte(id)
as
(
	select 1
	union all
	select id + 1
	from cte
	where id < 5
)
insert into @t (id)
select id
from cte
option (maxrecursion 0)

insert into @ids (id) values (1)
insert into @ids (id) values (3)

if @testEmpty = 1
	delete from @ids

select @idsCnt = count(*) from @ids

select
	*
from
	@t t
	join @ids ids on @idsCnt = 0 or ids.id = t.id

select
	*
from
	@t t
	left join @ids ids on @idsCnt = 0 or ids.id = t.id
where
	(@idsCnt = 0 and ids.id is null) or (@idsCnt != 0 and ids.id is not null)

select
	*
from
	@t t
where
	@idsCnt = 0 or t.id in (select id from @ids)