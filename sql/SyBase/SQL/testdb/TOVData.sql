use testdb
go

delete from TOV
go

insert into TOV (ID, CNT) values (1, 10)
insert into TOV (ID, CNT) values (2, 200)
insert into TOV (ID, CNT) values (3, 3000)
insert into TOV (ID, CNT) values (1, 20)
insert into TOV (ID, CNT) values (2, 400)
insert into TOV (ID, CNT) values (3, 6000)
insert into TOV (ID, CNT) values (4, 5000)
insert into TOV (ID, CNT) values (5, 110)
insert into TOV (ID, CNT) values (2, 4400)
go

/* ------------------------------------------------------ */
select
  T1.ID,
  T1.CNT
from
  TOV T1

select
  T1.ID,
  sum(T1.CNT) as CNT
from
  TOV T1
group by
  T1.ID
order by 2 desc

/* ------------------------------------------------------ */

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

select distinct top 2
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
  (select distinct /* top 2 */ sum(T2.CNT) from TOV T2 group by T2.ID /* order by 1 desc */)

/* ------------------------------------------------------ */

select
  T1.ID as T1_ID,
  T1.CNT as T1_CNT,
  T2.ID as T2_ID,
  T2.CNT as T2_CNT
from
  (select ID, sum(CNT) as CNT from TOV group by ID) T1
  join (select ID, sum(CNT) as CNT from TOV group by ID) T2 on T1.CNT<=T2.CNT

select
  T1.ID,
  T1.CNT
from
  (select ID, sum(CNT) as CNT from TOV group by ID) T1
  join (select ID, sum(CNT) as CNT from TOV group by ID) T2 on T1.CNT<=T2.CNT
group by
  T1.ID, T1.CNT

select
  T1.ID,
  T1.CNT
from
  (select ID, sum(CNT) as CNT from TOV group by ID) T1
  join (select ID, sum(CNT) as CNT from TOV group by ID) T2 on T1.CNT<=T2.CNT
group by
  T1.ID, T1.CNT
order by
  count(distinct T2.ID), T1.ID

select
  T1.ID,
  T1.CNT
from
  (select ID, sum(CNT) as CNT from TOV group by ID) T1
  join (select ID, sum(CNT) as CNT from TOV group by ID) T2 on T1.CNT<=T2.CNT
group by
  T1.ID, T1.CNT
having
  count(distinct T2.CNT)<=2
order by
  count(distinct T2.ID), T1.ID
