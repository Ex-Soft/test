use testdb;
go

delete from TestTable4ApplyOrder;
go

insert into TestTable4ApplyOrder (Total) values (100);
insert into TestTable4ApplyOrder (Total) values (200);
insert into TestTable4ApplyOrder (Total) values (300);
insert into TestTable4ApplyOrder (Total) values (400);
insert into TestTable4ApplyOrder (Total) values (500);
go
