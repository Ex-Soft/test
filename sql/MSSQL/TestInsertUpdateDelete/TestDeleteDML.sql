delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id) values (1)
insert into TestTable4IUDDest (Id) values (2)
insert into TestTable4IUDDest (Id) values (3)
insert into TestTable4IUDDest (Id) values (4)
insert into TestTable4IUDDest (Id) values (5)

delete
  TestTable4IUDDest
from
  TestTable4IUDDest Victim,
  TestTable4IUDSrc DataToDelete
where
  Victim.Id=DataToDelete.Id

select
  *
from
  TestTable4IUDDest

/*
2
4
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id) values (1)
insert into TestTable4IUDDest (Id) values (2)
insert into TestTable4IUDDest (Id) values (3)
insert into TestTable4IUDDest (Id) values (4)
insert into TestTable4IUDDest (Id) values (5)

delete
  TestTable4IUDDest
from
  TestTable4IUDDest Victim
  join TestTable4IUDSrc DataToDelete on (DataToDelete.Id=Victim.Id)

select
  *
from
  TestTable4IUDDest

/*
2
4
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id) values (1)
insert into TestTable4IUDDest (Id) values (2)
insert into TestTable4IUDDest (Id) values (3)
insert into TestTable4IUDDest (Id) values (4)
insert into TestTable4IUDDest (Id) values (5)

delete
  TestTable4IUDDest
from
  TestTable4IUDDest Victim
  left join TestTable4IUDSrc DataToDelete on (DataToDelete.Id=Victim.Id)
where
  (DataToDelete.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1
3
5
*/
