use testdb
go

delete from TestDetailMulti
go

insert into TestDetailMulti (IdMaster, Val) values (1, N'1.1')
insert into TestDetailMulti (IdMaster, Val) values (1, N'1.2')
insert into TestDetailMulti (IdMaster, Val) values (1, N'1.3')
insert into TestDetailMulti (IdMaster, Val) values (2, N'2.1')
insert into TestDetailMulti (IdMaster, Val) values (2, N'2.2')
insert into TestDetailMulti (IdMaster, Val) values (2, N'2.3')
go

insert into TestDetailMulti (IdMaster, Val) values (10, N'10.1') -- The INSERT statement conflicted with the FOREIGN KEY constraint "fkTestMasterYTestDetailMulti". The conflict occurred in database "testdb", table "dbo.TestMasterY", column 'Id'.
go

insert into TestDetailMulti (IdMaster, Val) values (20, N'20.1') -- The INSERT statement conflicted with the FOREIGN KEY constraint "fkTestMasterXTestDetailMulti". The conflict occurred in database "testdb", table "dbo.TestMasterX", column 'Id'.

go

