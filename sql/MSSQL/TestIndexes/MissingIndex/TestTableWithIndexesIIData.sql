use testdb
go

delete from TestTableWithIndexesII
go

insert into TestTableWithIndexesII (Field1, Field2) values (5, 1)
insert into TestTableWithIndexesII (Field1, Field2) values (4, 2)
insert into TestTableWithIndexesII (Field1, Field2) values (3, 3)
insert into TestTableWithIndexesII (Field1, Field2) values (2, 4)
insert into TestTableWithIndexesII (Field1, Field2) values (1, 5)
go
