use testdb
go

if object_id(N'vTestMasterTestDetail', N'v') is not null
	drop view vTestMasterTestDetail
go

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
go
