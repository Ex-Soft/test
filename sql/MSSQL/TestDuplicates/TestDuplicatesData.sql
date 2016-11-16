use testdb
go

delete from TestDuplicates
go

insert into TestDuplicates (id, F1, F2, F3) values (1, 1, 1, 1)
insert into TestDuplicates (id, F1, F2, F3) values (2, 1, 1, 1)
insert into TestDuplicates (id, F1, F2, F3) values (3, 1, 1, 1)
insert into TestDuplicates (id, F1, F2, F3) values (4, 2, 2, 2)
insert into TestDuplicates (id, F1, F2, F3) values (5, 2, 2, 2)
insert into TestDuplicates (id, F1, F2, F3) values (6, 3, 3, 3)
go
