select
  Id1,
  Id2,
  sum(Val) as _sum_
from
  TestGroupBy
group by
  Id1,
  Id2
order by Id1, Id2

select
  Id1,
  Id2,
  sum(Val) as _sum_
from
  TestGroupBy
group by
  Id2,
  Id1
order by Id2, Id1

select
  TGB.Id1,
  count(TGB.Id1),
  T1.Id
from
  TestGroupBy TGB
  left outer join T2 T1 on (T1.Id=TGB.Id1)
group by
  TGB.Id1,
  T1.Id,
/* !!! */
  T1.ValueInt
/* !!! */
having
  (count(TGB.Id1)>T1.ValueInt)
order by TGB.Id1
