-- http://msdn.microsoft.com/en-us/library/ms187326.aspx
-- http://msdn.microsoft.com/en-us/library/ms186329.aspx

use testdb
go

if object_id(N'TableWithTriggerU', N'u') is not null
	drop table TableWithTriggerU
go

create table TableWithTriggerU
(
	id int not null identity constraint pkTableWithTriggerU primary key,
	value1 int null,
	value2 int null,
	value3 int null,
	recordModify datetime null
)
go

if object_id(N'Trigger4TableWithTriggerU', N'tr') is not null
	drop trigger Trigger4TableWithTriggerU
go

create trigger Trigger4TableWithTriggerU
on TableWithTriggerU
for update
as
begin
	set nocount on

	if update(value1)
		begin
			print N'update(value1)'
		end

	if update(value2)
		begin
			print N'update(value2)'
		end

	if update(value3)
		begin
			print N'update(value3)'
		end

	if update(value1) and update(value2)
		begin
			print N'update(value1) and update(value2)'
			
			update
				TableWithTriggerU
			set
				recordModify = getdate()
			from
				TableWithTriggerU t
				join inserted inserted on (inserted.id=t.id)
		end
end
go
