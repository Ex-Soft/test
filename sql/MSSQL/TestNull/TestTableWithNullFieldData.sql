use testdb
go

delete from TestTableWithNullField
go

insert into TestTableWithNullField (val) values (1)
insert into TestTableWithNullField (val) values (null)
insert into TestTableWithNullField (val) values (3)
insert into TestTableWithNullField (val) values (null)
insert into TestTableWithNullField (val) values (5)
go
