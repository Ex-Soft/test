insert into Victim (Id, Val, F_Number1, F_Number2) values (1,1,2,3);
insert into Victim (Id, Val, F_Number1, F_Number2) values (2,2,3,4);
insert into Victim (Id, Val, F_Number1, F_Number2) values (3,3,4,5);
insert into Victim (Id, Val) values (4,4);
insert into Victim (Id, Val) values (5,5);

commit;

select
  v.*
from
  Victim v;

select
  t.*
from
  T2 t;

select
  v.*,
  t.*
from
  Victim v
  left join T2 t on (t.Id=v.Id);


delete from Victim v
where
  not exists (select Id from T2 t where t.Id=v.Id);
