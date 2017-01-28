use testdb
go

insert into TestMinId (Id, IdDate) values (1, '20091116')
insert into TestMinId (Id, IdDate) values (2, '20091116')
insert into TestMinId (Id, IdDate) values (3, '20091116')
insert into TestMinId (Id, IdDate) values (7, '20091116')
insert into TestMinId (Id, IdDate) values (8, '20091116')
insert into TestMinId (Id, IdDate) values (9, '20091116')
insert into TestMinId (Id, IdDate) values (10, '20091116')
insert into TestMinId (Id, IdDate) values (11, '20091116')
insert into TestMinId (Id, IdDate) values (12, '20091116')
insert into TestMinId (Id, IdDate) values (15, '20091117')
insert into TestMinId (Id, IdDate) values (16, '20091117')
insert into TestMinId (Id, IdDate) values (17, '20091117')
insert into TestMinId (Id, IdDate) values (20, '20091117')
insert into TestMinId (Id, IdDate) values (21, '20091117')
insert into TestMinId (Id, IdDate) values (22, '20091117')
insert into TestMinId (Id, IdDate) values (25, '20091118')
insert into TestMinId (Id, IdDate) values (26, '20091118')
insert into TestMinId (Id, IdDate) values (27, '20091118')
go

select
  min(TMI1.Id)+1
from
  TestMinId TMI1
  left outer join TestMinId TMI2 on (TMI2.Id-1=TMI1.Id)
where
  (TMI1.IdDate>='20091117')
  and (TMI2.Id is null)
go