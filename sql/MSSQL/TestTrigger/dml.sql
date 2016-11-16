
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