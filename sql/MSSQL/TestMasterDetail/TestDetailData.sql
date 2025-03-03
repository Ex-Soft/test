use testdb;
go

delete from TestDetail;
go

insert into TestDetail (IdMaster, Val) values (1, N'1.1');
insert into TestDetail (IdMaster, Val) values (1, N'1.2');
insert into TestDetail (IdMaster, Val) values (1, N'1.3');
insert into TestDetail (IdMaster, Val) values (1, N'1.4');
insert into TestDetail (IdMaster, Val) values (1, N'1.5');
insert into TestDetail (IdMaster, Val) values (1, N'1.6');
insert into TestDetail (IdMaster, Val) values (1, N'1.7');
insert into TestDetail (IdMaster, Val) values (1, N'1.8');
insert into TestDetail (IdMaster, Val) values (1, N'1.9');
insert into TestDetail (IdMaster, Val) values (1, N'1.10');
insert into TestDetail (IdMaster, Val) values (1, N'1.11');
insert into TestDetail (IdMaster, Val) values (1, N'1.12');
insert into TestDetail (IdMaster, Val) values (1, N'1.13');
insert into TestDetail (IdMaster, Val) values (2, N'2.1');
insert into TestDetail (IdMaster, Val) values (2, N'2.2');
insert into TestDetail (IdMaster, Val) values (2, N'2.3');
go

;with cte (MasterId)
as
(
	select
		Id
	from
		TestMaster
	where
		Val = N'TEST An item with the same key has already been added 1:1'
)
insert into TestDetail
	(IdMaster, Val)
select
	cte.MasterId as IdMaster,
	N'TEST An item with the same key has already been added 1:1'
from
	cte cte;
go

;with cte (MasterId)
as
(
	select
		Id
	from
		TestMaster
	where
		Val = N'TEST An item with the same key has already been added 1:N'
)
insert into TestDetail
	(IdMaster, Val)
select
	cte.MasterId as IdMaster,
	N'TEST An item with the same key has already been added 1:N'
from
	cte cte
union all
select
	cte.MasterId as IdMaster,
	N'TEST An item with the same key has already been added 1:N'
from
	cte cte;
go
