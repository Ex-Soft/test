use testdb
go

delete from TestCursorMain
go

insert into TestCursorMain (Id, Val, Cod) values (1, 1, 1)
insert into TestCursorMain (Id, Val, Cod) values (2, 2, 1)
insert into TestCursorMain (Id, Val, Cod) values (3, 3, 1)
insert into TestCursorMain (Id, Val, Cod) values (4, 4, 2)
insert into TestCursorMain (Id, Val, Cod) values (5, 5, 2)
go
