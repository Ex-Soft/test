use testdb
go

delete from TestTableWithIndexes4LockII
go

insert into TestTableWithIndexes4LockII (FieldI) values (1)
go
