use testdb
go

set identity_insert ContragentWGenIdDate on

insert into ContragentWGenIdDate (Id, GenId, Name, RecordModify) values (1, 1,'����� �������� ����','20090320')
insert into ContragentWGenIdDate (Id, GenId, Name, RecordModify) values (1, 2,'����� �������� �����','20090321')
insert into ContragentWGenIdDate (Id, GenId, Name, RecordModify) values (3, 3,'������ ����� �������������','20090326')

set identity_insert ContragentWGenIdDate off
go

/*
select
  C.*
from
  ContragentWGenIdDate C
where
  C.GenID=(select max(GenID) from ContragentWGenIdDate where Id=C.Id)

select
  C.*
from
  ContragentWGenIdDate C
where
  C.GenID>=all(select GenID from ContragentWGenIdDate where Id=C.Id)

*/