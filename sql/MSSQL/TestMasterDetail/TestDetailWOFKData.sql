use testdb
go

delete from TestDetailWOFK
go

insert into TestDetailWOFK (Id, IdMaster, Val) values (1, 2, N'2.2')
go
