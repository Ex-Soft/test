use testdb
go

delete from TestMasterY
go

insert into TestMasterY (Val) values (N'1')
insert into TestMasterY (Val) values (N'2')
insert into TestMasterY (Val) values (N'3')
go

set identity_insert TestMasterY on
insert into TestMasterY (Id, Val) values (20, N'20')
set identity_insert TestMasterY off
go
