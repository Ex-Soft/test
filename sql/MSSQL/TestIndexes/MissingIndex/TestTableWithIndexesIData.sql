use testdb
go

delete from TestTableWithIndexesI
go

insert into TestTableWithIndexesI (Field1, Field2) values (1, 5)
insert into TestTableWithIndexesI (Field1, Field2) values (2, 4)
insert into TestTableWithIndexesI (Field1, Field2) values (3, 3)
insert into TestTableWithIndexesI (Field1, Field2) values (4, 2)
insert into TestTableWithIndexesI (Field1, Field2) values (5, 1)
go
