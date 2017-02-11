delete from EntityA
go

insert into EntityA (Id, MainId, Value) values (1, 1, N'1')
insert into EntityA (Id, MainId, Value) values (2, 1, N'1.2')
insert into EntityA (Id, MainId, Value) values (3, 1, N'1.3')
insert into EntityA (Id, MainId, Value) values (4, 4, N'4')
insert into EntityA (Id, MainId, Value) values (5, 4, N'4.5')
insert into EntityA (Id, MainId, Value) values (6, 4, N'4.6')
insert into EntityA (Id, MainId, Value) values (7, 4, N'4.7')
go

delete from EntityB
go

insert into EntityB (Id, Value) values (10, N'10')
go

delete from EntityC
go

insert into EntityC (Id, EntityAId, EntityBId, Value) values (100, 1, 10, N'1 10')
insert into EntityC (Id, EntityAId, EntityBId, Value) values (200, 4, 10, N'4 10')
go

select
	*
from
	EntityA entityA
	left join EntityC entityC on entityC.EntityAId = entityA.Id
	left join EntityB entityB on entityB.id = entityC.EntityBId

select
	*
from
	EntityB entityB
	left join EntityC entityC on entityC.EntityBId = entityB.Id
	left join EntityA entityA on entityA.id = entityC.EntityAId

-- 16.2.4
-- queryable
-- wrong
exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where exists(select * from "dbo"."EntityC" N1 where ((N1."EntityBId" = @p0) and (N1."Id" = N0."MainId")))',N'@p0 int',@p0=10

-- right
exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where exists(select * from "dbo"."EntityC" N1 where ((N1."EntityBId" = @p0) and (N1."EntityAId" = N0."MainId")))',N'@p0 int',@p0=10

-- list
exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where N0."MainId" in (@p0,@p1)',N'@p0 int,@p1 int',@p0=1,@p1=4
-- 16.2.4

-- 14.2.7
exec sp_executesql N'select N0."EntityAId" from "dbo"."EntityC" N0
where (N0."EntityBId" = @p0)',N'@p0 int',@p0=10

exec sp_executesql N'select N0."Id",N0."MainId",N0."Value",N0."OptimisticLockField" from "dbo"."EntityA" N0
where N0."Id" in (@p0,@p1)',N'@p0 int,@p1 int',@p0=1,@p1=4

exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where N0."MainId" in (@p0,@p1)',N'@p0 int,@p1 int',@p0=1,@p1=4
-- 14.2.7