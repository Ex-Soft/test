
update
  TableWithTriggerIUD
set
  Value=4
where
  Id=4

/*
insert into TableWithTriggerInstead
(Value,RecordModify)
values
('99',getdate())
*/

select
  *
from
  TableWithTriggerInstead

select
  *
from
  TableWithTriggerInsteadHistory