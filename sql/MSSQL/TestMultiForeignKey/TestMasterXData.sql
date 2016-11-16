use testdb
go

delete from TestMasterX
go

insert into TestMasterX (Val) values (N'1')
insert into TestMasterX (Val) values (N'2')
insert into TestMasterX (Val) values (N'3')
go

set identity_insert TestMasterX on
insert into TestMasterX (Id, Val) values (10, N'10')
set identity_insert TestMasterX off
go

