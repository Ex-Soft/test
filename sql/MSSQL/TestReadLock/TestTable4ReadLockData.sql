;with CTE(ID)
as
(
	select 1
	union all
	select ID + 1
	from CTE
	where ID < 50000
)
insert into TestTable4ReadLock (Id, Value)
select ID, ID
from CTE
option (MAXRECURSION 0)