use testdb
go

delete from TestTable4ApplyII
go

insert into TestTable4ApplyII (Field1, Field2) values (1, 11)
insert into TestTable4ApplyII (Field1, Field2) values (1, 12)
insert into TestTable4ApplyII (Field1, Field2) values (1, 13)
insert into TestTable4ApplyII (Field1, Field2) values (1, 14)
insert into TestTable4ApplyII (Field1, Field2) values (1, 15)
insert into TestTable4ApplyII (Field1, Field2) values (3, 31)
insert into TestTable4ApplyII (Field1, Field2) values (3, 32)
insert into TestTable4ApplyII (Field1, Field2) values (3, 33)
insert into TestTable4ApplyII (Field1, Field2) values (6, 66)
go
