dbcc traceon (1222, -1)
go

dbcc tracestatus (1222, -1)
go

begin transaction
insert into t1 (fint) values (1)
select * from t1
select * from t2
insert into t2 (fint) values (1)
--commit