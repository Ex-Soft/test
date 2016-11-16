use testdb
go

delete from TestTableWithIndexes4LockI
go

insert into TestTableWithIndexes4LockI (idSmthI, idSmthII, FieldI, FieldII) values (1, 1, N'TableName', N'outercode')
go
