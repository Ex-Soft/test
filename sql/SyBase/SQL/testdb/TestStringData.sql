use testdb
go

insert into TestString (Id, Val) values (1,null)
insert into TestString (Id, Val) values (2,'ABC')
insert into TestString (Id, Val) values (3,'AB''C')
insert into TestString (Id, Val) values (4,'A''B"C')
insert into TestString (Id, Val) values (5,'''A\B/C"')
go
