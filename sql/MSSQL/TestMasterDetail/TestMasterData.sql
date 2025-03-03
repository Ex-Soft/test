use testdb;
go


delete from TestMaster;
go

insert into TestMaster (Val) values (N'1');
insert into TestMaster (Val) values (N'2');
insert into TestMaster (Val) values (N'3');
insert into TestMaster (Val) values (N'TEST An item with the same key has already been added 1:1');
insert into TestMaster (Val) values (N'TEST An item with the same key has already been added 1:N');
go
