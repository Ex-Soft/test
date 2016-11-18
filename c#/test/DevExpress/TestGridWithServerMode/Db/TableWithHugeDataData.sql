--set identity_insert TableWithHugeData on

;with cte(id)
as
(
	select 1
	union all
	select id + 1
	from cte
	where id < 5000
)
insert into TableWithHugeData (Id)
select id
from cte
option (maxrecursion 0);

--set identity_insert TableWithHugeData off
