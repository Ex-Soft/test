insert into VictimII (Id, IdId, Val) values (1,1,1);
insert into VictimII (Id, IdId, Val) values (2,2,2);
insert into VictimII (Id, IdId, Val) values (3,3,4);
insert into VictimII (Id, IdId, Val) values (4,4,4);
insert into VictimII (Id, IdId, Val) values (5,5,5);

commit;

select
  v.*,
  t.*
from
  victimII v
  left join t2II t on (t.id=v.id) and (t.idid=v.idid);

select
  v.*
from
  VictimII v
where
  (Id, IdId) in (select T.Id, T.IdId from T2II T);

delete from
  VictimII
where
  (Id, IdId) in (select T.Id, T.IdId from T2II T);
