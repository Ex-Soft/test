update
  T1
set
  Value='123'
from
  T1
  left outer join T2 T2 on (T2.ID=T1.ID)
where
  (T1.ID is not null)
  and (T2.ID is null)

select
  T1.*,
  T2.*
from
  T1
  left outer join T2 T2 on (T2.ID=T1.ID)