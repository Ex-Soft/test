select
  M.*,
  D.*
from
  TableMaster M
  left outer join TableDetail D on (D.MasterId=M.Id)
order by
  M.Id,
  D.Id