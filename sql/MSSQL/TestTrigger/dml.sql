/*

;with cte(id, [Value], RecordModify)
as
(
	select 1 as id, N'Value# ' + cast(1 as nvarchar(10)), getdate()
	union all
	select id + 1 as id, N'Value# ' + cast(id + 1 as nvarchar(10)), getdate()
	from cte
	where id < 10
)
insert into TableWithTriggerIUD
	([Value], RecordModify)
select
	[Value], RecordModify
from cte
option (maxrecursion 0);

*/

update
  TableWithTriggerIUD
set
  Value=4
where
  Id=4

/*
insert into TableWithTriggerIUD
(Value,RecordModify)
values
('99',getdate())
*/

select
  *
from
  TableWithTriggerIUD

select
  *
from
  TableWithTriggerIUDHistory