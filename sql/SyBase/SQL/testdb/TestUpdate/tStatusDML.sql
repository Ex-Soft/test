select
  *
from
  tStatus

select
  *
from
  tInsert

select
  *
from
  tDelete

update
  tStatus
set
  StatusId=case i.StatusId
             when 10 then 1010
             when 11 then 1111
             when 12 then 1212
             when 13 then 1313
             when 14 then 1414
             when 15 then 1515
           end
from
  tStatus s
  join tInsert i on (i.Id=s.Id)
  join tDelete d on (d.Id=i.Id)
where
  (i.StatusId!=d.StatusId)

select
  *
from
  tStatus
