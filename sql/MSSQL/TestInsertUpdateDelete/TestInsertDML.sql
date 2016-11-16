delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id, Val) values (1, 10)
insert into TestTable4IUDSrc (Id, Val) values (2, 20)
insert into TestTable4IUDSrc (Id, Val) values (3, 30)
insert into TestTable4IUDSrc (Id, Val) values (4, 40)
insert into TestTable4IUDSrc (Id, Val) values (5, 50)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  Src.Id,
  Src.Val
from
  TestTable4IUDDest Dest,
  TestTable4IUDSrc Src
where
  Dest.Id=Src.Id

select
  *
from
  TestTable4IUDDest

/*
1	1
3	3
5	5
1	10
3	30
5	50
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id, Val) values (1, 10)
insert into TestTable4IUDSrc (Id, Val) values (2, 20)
insert into TestTable4IUDSrc (Id, Val) values (3, 30)
insert into TestTable4IUDSrc (Id, Val) values (4, 40)
insert into TestTable4IUDSrc (Id, Val) values (5, 50)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  Src.Id,
  Src.Val
from
  TestTable4IUDDest Dest
  join TestTable4IUDSrc Src on (Src.Id=Dest.Id)

select
  *
from
  TestTable4IUDDest

/*
1	1
3	3
5	5
1	10
3	30
5	50
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id, Val) values (1, 10)
insert into TestTable4IUDSrc (Id, Val) values (2, 20)
insert into TestTable4IUDSrc (Id, Val) values (3, 30)
insert into TestTable4IUDSrc (Id, Val) values (4, 40)
insert into TestTable4IUDSrc (Id, Val) values (5, 50)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  Src.Id,
  Src.Val
from
  TestTable4IUDSrc Src
  left join TestTable4IUDDest Dest on (Dest.Id=Src.Id)
where
  (Dest.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1	1
3	3
5	5
2	20
4	40
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id, Val) values (1, 10)
insert into TestTable4IUDSrc (Id, Val) values (2, 20)
insert into TestTable4IUDSrc (Id, Val) values (3, 30)
insert into TestTable4IUDSrc (Id, Val) values (4, 40)
insert into TestTable4IUDSrc (Id, Val) values (5, 50)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (3, 2)
insert into TestTable4IUDDest (Id, Val) values (5, 1)

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  Src.Id,
  Src.Val
from
  TestTable4IUDSrc Src
  left join TestTable4IUDDest Dest on (Dest.Id=Src.Id) and (Dest.Val=1)
where
  (Dest.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1	1
3	2
5	1
2	20
3	30
4	40
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id, Val) values (1, 1)
insert into TestTable4IUDSrc (Id, Val) values (1, 2)
insert into TestTable4IUDSrc (Id, Val) values (1, 3)
insert into TestTable4IUDSrc (Id, Val) values (2, 1)
insert into TestTable4IUDSrc (Id, Val) values (2, 3)
insert into TestTable4IUDSrc (Id, Val) values (3, 2)

insert into TestTable4IUDDest (Id, Val) values (1, 2)
insert into TestTable4IUDDest (Id, Val) values (2, 3)

select
  *
from
  TestTable4IUDDest

/*
1	2
2	3
*/

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  Src.Id,
  Src.Val
from
  TestTable4IUDSrc Src
  left join TestTable4IUDDest Dest on (Dest.Id=Src.Id) and (Dest.Val=Src.Val)
where
  (Dest.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1	2
2	3
1	1
1	3
2	1
3	2
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (2)
insert into TestTable4IUDSrc (Id) values (3)

insert into TestTable4IUDDest (Id, Val) values (1, 2)
insert into TestTable4IUDDest (Id, Val) values (2, 3)

select
  *
from
  TestTable4IUDDest

/*
1	2
2	3
*/

insert into TestTable4IUDDest
  (
   Id,
   Val
  )
select
  1,
  Src.Id
from
  TestTable4IUDSrc Src
  left join TestTable4IUDDest Dest on (Dest.Id=1) and (Dest.Val=Src.Id)
where
  (Dest.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1	2
2	3
1	1
1	3
*/
