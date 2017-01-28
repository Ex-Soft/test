select
  T1.*,
  T2.*
from
  T1 T1
  left outer join T2 on (T2.Id=T1.Id)

select
  T1.*,
  T2.*
from
  T1,
  T2
where
  T1.Id*=T2.Id

select
  T1.*,
  T2.*
from
  T1,
  T2
where
  T2.Id*=T1.Id

select
  T2.*,
  T1.*
from
  T2 T2
  right outer join T1 on (T1.Id=T2.Id)

select
  T2.*,
  T1.*
from
  T2,
  T1
where
  T2.Id=*T1.Id

create table #t1(t1id int primary key, data varchar(20) not null)
create table #t2(t2id int primary key, t1id int not null, data2 varchar(20) not null)

insert into #t1(t1id,data) values(1,'test')
insert into #t1(t1id,data) values(2,'test2')
/* insert into #t1(t1id,data) values(3,'test3') */

insert into #t2(t2id,t1id,data2) values(1,1,'test21')
insert into #t2(t2id,t1id,data2) values(2,2,'test22')

select * from #t1
select * from #t2

select
  a.*,
  b.*
from
  #t1 a
  left outer join #t2 b on (b.t1id=a.t1id)

select
  a.*,
  b.*
from
  #t1 a,
  #t2 b
where
  a.t1id*=b.t1id

select
  * 
from
  #t1 a
  right join #t2 b on b.t2id=a.t1id
WHERE
  b.data2 = 'test21'

select
  * 
from
  #t1 a,
  #t2 b
WHERE
  b.t2id =* a.t1id
  AND b.data2 = 'test21'

drop table #t1
drop table #t2