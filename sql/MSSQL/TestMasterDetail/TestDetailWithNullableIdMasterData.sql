use testdb;
go

delete from TestDetailWithNullableIdMaster;
go

insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (1, N'1.1');
insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (1, N'1.2');
insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (1, N'1.3');
insert into TestDetailWithNullableIdMaster (Val) values (N'2.1');
insert into TestDetailWithNullableIdMaster (Val) values (N'2.2');
insert into TestDetailWithNullableIdMaster (Val) values (N'2.3');
insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (2, N'3.1');
insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (2, N'3.2');
insert into TestDetailWithNullableIdMaster (IdMaster, Val) values (2, N'3.3');
go
