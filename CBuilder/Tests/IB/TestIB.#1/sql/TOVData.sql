select
  sum(T2.CNT)
from
  TOV T2
group by
  T2.ID
order by 1 desc

select distinct
  sum(T2.CNT)
from
  TOV T2
group by
  T2.ID
order by 1 desc

select first 2 distinct
  sum(T2.CNT)
from
  TOV T2
group by
  T2.ID
order by 1 desc

select
  T1.ID,
  sum(T1.CNT)
from
  TOV T1
group by
  T1.ID
having
  sum(T1.CNT) in
  (select first 2 distinct sum(T2.CNT) from TOV T2 group by T2.ID order by 1 desc)

select
  T1.ID,
  sum(T1.CNT) as CNT
from
  TOV T1
group by
  T1.ID
having
  sum(T1.CNT)>=
(select first 1 skip 1 distinct
  sum(T2.CNT) as CNT
from
  TOV T2
group by
  T2.ID
order by 1 desc)