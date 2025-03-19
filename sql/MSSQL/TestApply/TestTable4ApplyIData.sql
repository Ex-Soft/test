use testdb;
go

delete from TestTable4ApplyI;
go

insert into TestTable4ApplyI (Field1, Field2) values (1, 5);
insert into TestTable4ApplyI (Field1, Field2) values (2, 4);
insert into TestTable4ApplyI (Field1, Field2) values (3, 3);
insert into TestTable4ApplyI (Field1, Field2) values (4, 2);
insert into TestTable4ApplyI (Field1, Field2) values (5, 1);
insert into TestTable4ApplyI (Field1, Field2) values (6, 66);
go
