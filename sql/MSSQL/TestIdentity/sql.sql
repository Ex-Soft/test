insert into TestDetail (idmaster,val) values (1, getdate())
insert into TestMaster (val) values (getdate())
select scope_identity()
select @@identity
select ident_current(N'TestMaster')
select ident_current(N'TestDetail')
select * from TestMaster
select * from TestDetail