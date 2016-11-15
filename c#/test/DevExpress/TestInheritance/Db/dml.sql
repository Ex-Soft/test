select * from XPObjectType order by OID
select * from XPObjectType where AssemblyName = N'TestInheritance'

--set identity_insert XPObjectType on
--insert into XPObjectType (OID, TypeName, AssemblyName) values (9, N'TestInheritance.Db.TestDEMasterTableWithInheritanceLite', N'TestInheritance')
--insert into XPObjectType (OID, TypeName, AssemblyName) values (10, N'TestInheritance.Db.TestDEMasterTableWithInheritance', N'TestInheritance')
--insert into XPObjectType (OID, TypeName, AssemblyName) values (11, N'TestInheritance.Db.TestDEDetailTableWithInheritanceLite', N'TestInheritance')
--insert into XPObjectType (OID, TypeName, AssemblyName) values (12, N'TestInheritance.Db.TestDEDetailTableWithInheritance', N'TestInheritance')
--set identity_insert XPObjectType off

select * from TestDEMasterTableWithInheritance
select * from TestDEDetailTableWithInheritance

select
	*
from
	TestDEMasterTableWithInheritance [master]
	join TestDEDetailTableWithInheritance [detail] on [detail].idMaster = [master].id
order by [master].id, [detail].id

--update TestDEMasterTableWithInheritance set ObjectType = 9 where ID = 1
--update TestDEDetailTableWithInheritance set ObjectType = 11 where ID = 4


insert into TestDEReference ([Value]) values (N'Link# 1')
insert into TestDEReference ([Value]) values (N'Link# 2')

select * from TestDEReference

insert into TestDEForTestInheritanceI
([Value], LeftId, RightId)
select
	N'{Left:''Link# 1'', Right:''Link# 2''}',
	Id,
	(select Id from TestDEReference where [Value] = N'Link# 2')
from
	TestDEReference
where
	[Value] = N'Link# 1'

insert into TestDEForTestInheritanceI
([Value], LeftId, RightId)
select
	N'{Left:''Link# 2'', Right:''Link# 1''}',
	Id,
	(select Id from TestDEReference where [Value] = N'Link# 1')
from
	TestDEReference
where
	[Value] = N'Link# 2'

select * from TestDEForTestInheritanceI

select
	entity.[Value],
	referenceLeft.[Value],
	referenceRight.[Value],
	*
from
	TestDEForTestInheritanceI entity
	join TestDEReference referenceLeft on referenceLeft.Id = entity.LeftId
	join TestDEReference referenceRight on referenceRight.Id = entity.RightId

/*
insert into XPObjectType (TypeName, AssemblyName) values (N'TestInheritance.Db.ForTestInheritanceILeftRight', N'TestInheritance')
insert into XPObjectType (TypeName, AssemblyName) values (N'TestInheritance.Db.ForTestInheritanceIRightLeft', N'TestInheritance')

update
	TestDEForTestInheritanceI
set
	ObjectType = (select OID from XPObjectType where TypeName = N'TestInheritance.Db.ForTestInheritanceILeftRight' and AssemblyName = N'TestInheritance')
where
	Id = 1

update
	TestDEForTestInheritanceI
set
	ObjectType = (select OID from XPObjectType where TypeName = N'TestInheritance.Db.ForTestInheritanceIRightLeft' and AssemblyName = N'TestInheritance')
where
	Id = 2
*/

insert into refGoods (FullName, IsCompetitor) values (N'Свой товар #1', 0)
insert into refGoods (FullName, IsCompetitor) values (N'Свой товар #2', 0)
insert into refGoods (FullName, IsCompetitor) values (N'Товар конкурентов #1', 1)
insert into refGoods (FullName, IsCompetitor) values (N'Товар конкурентов #2', 1)
insert into refGoods (FullName, IsCompetitor) values (N'Товар конкурентов #3', 1)
go

insert into refGoodsCompetitors
	([Value], idGoods, idGoodsCompetitor)
select
	N'{SKU:''Свой товар #1'', SKUCompetitor:''Товар конкурентов #1''}',
	Id,
	(select Id from refGoods where FullName = N'Товар конкурентов #1')
from
	refGoods
where
	FullName = N'Свой товар #1'
go

select * from refGoods
select * from refGoodsCompetitors
