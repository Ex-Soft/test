select * from TestMasterX
select * from TestMasterY
select * from TestDetailWithPolymorphicAssociations

select
	*
from
	TestDetailWithPolymorphicAssociations detail
	left join TestMasterX masterX on masterX.Id = detail.MasterId and detail.MasterType = 'X'
	left join TestMasterY masterY on masterY.Id = detail.MasterId and detail.MasterType = 'Y'

/*
insert into TestMasterX (Val) values (N'11')
insert into TestMasterY (Val) values (N'21')

insert into TestDetailWithPolymorphicAssociations (MasterType, MasterId, Val) values ('X', 10, N'X(10)')
insert into TestDetailWithPolymorphicAssociations (MasterType, MasterId, Val) values ('Y', 20, N'Y(20)')
*/

/*
update TestDetailWithPolymorphicAssociations set MasterId = 12, Val = N'X(12)' where id = 5
update TestDetailWithPolymorphicAssociations set MasterId = 21, Val = N'Y(21)' where id = 4
*/