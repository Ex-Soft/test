create view vTestMasterTestDetail
as
select
	[master].Id as MasterId,
	[master].Val as MasterVal,
	[detail].Id as DetailId,
	[detail].Val as DetailVal
from
	TestMaster [master]
	left join TestDetail [detail] on [detail].IdMaster = [master].Id