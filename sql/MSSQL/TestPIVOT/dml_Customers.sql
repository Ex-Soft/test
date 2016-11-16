select
  *
from
(
   select
     times_purchased,
     state_code,
     count(1) as cnt
   from
     TestTable4TestPIVOTCustomers
   group by state_code, times_purchased
) as SourceTable
pivot
(
  sum(cnt)
  for state_code in ([CT], [NY], [NJ])
) as PivotTable


select
  times_purchased as 'Puchase Frequency', [NY] as 'New York', [CT] as 'Connecticut', [NJ] as 'New Jersey', [FL] as 'Florida', [MO] as 'Missouri'
from
(
   select
     times_purchased,
     state_code,
     count(1) as cnt
   from
     TestTable4TestPIVOTCustomers
   group by state_code, times_purchased
) as SourceTable
pivot
(
  sum(cnt)
  for state_code in ([CT], [NY], [NJ], [FL], [MO])
) as PivotTable