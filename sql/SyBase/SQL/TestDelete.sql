/*
Victim
1 1
2 2
3 3
4 4
5 5

T2
1
3
5
*/

delete
  Victim
from
  Victim V,
  T2 T
where
  V.Id=T.Id
/*
2
4
*/

delete
  Victim
from
  Victim V
  join T2 T on (V.Id=T.Id)
/*
2
4
*/

delete
  Victim
from
  Victim V
  left outer join T2 T on (V.Id=T.Id)
where
  T.Id is null
/*
1
3
5
*/