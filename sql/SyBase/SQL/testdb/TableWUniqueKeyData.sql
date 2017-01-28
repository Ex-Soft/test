insert into TableWUniqueKey(Id, Value) values (1, 'a')
insert into TableWUniqueKey(Id, Value) values (2, 'b')
insert into TableWUniqueKey(Id, Value) values (3, 'c')
insert into TableWUniqueKey(Id, Value) values (4, 'd')
insert into TableWUniqueKey(Id, Value) values (5, 'e')
insert into TableWUniqueKey(Id, Value) values (6, 'f')
insert into TableWUniqueKey(Id, Value) values (7, 'g')
go

update
  TableWUniqueKey
set
  Id=Id*-1
where
  Id between 4 and 7

update
  TableWUniqueKey
set
  Id=Id*-1+1
where
  Id between -7 and -4
