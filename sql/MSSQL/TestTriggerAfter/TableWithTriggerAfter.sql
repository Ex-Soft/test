use testdb
go

if object_id(N'TableWithTriggerAfter', N'u') is not null
	drop table TableWithTriggerAfter
go

create table TableWithTriggerAfter
(
	id bigint not null constraint pkTableWithTriggerAfter primary key,
	value nvarchar(256) null
)
go

if object_id(N'trTableWithTriggerAfter', N'tr') is not null
	drop trigger trTableWithTriggerAfter
go

create trigger trTableWithTriggerAfter
on TableWithTriggerAfter
after insert, update, delete
as
begin
	set nocount on

	print N'trTableWithTriggerAfter'

	declare
		@cnt int,
		@tmpStr nvarchar(max),
		@tmpId bigint,
		@tmpValue nvarchar(256)

	select @cnt=count(*) from inserted
	set @tmpStr='inserted count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	select @cnt=count(*) from deleted
	set @tmpStr='deleted count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	if exists (
		select
			inserted.id,
			inserted.value,
			deleted.id,
			deleted.value
		from
			inserted inserted
			join deleted deleted on deleted.id=inserted.id)
		print 'exists'
	else
		print '!exists'

	select @cnt=count(*) from TableWithTriggerAfter
	set @tmpStr='TableWithTriggerAfter count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	declare	#CursorInTrTableWithTriggerAfter cursor for
		select
			id,
			value
		from
			TableWithTriggerAfter
		for read only

	open #CursorInTrTableWithTriggerAfter
	fetch from #CursorInTrTableWithTriggerAfter into @tmpId, @tmpValue
	while @@fetch_status=0
		begin
			set @tmpStr=N'id='+convert(nvarchar(max), @tmpId)+N', value='''+coalesce(@tmpValue, N'NULL')+N''''
			print @tmpStr

			fetch from #CursorInTrTableWithTriggerAfter into @tmpId, @tmpValue
		end
	close #CursorInTrTableWithTriggerAfter
	deallocate #CursorInTrTableWithTriggerAfter
end
go

if object_id(N'trTableWithTriggerAfterFor', N'tr') is not null
	drop trigger trTableWithTriggerAfterFor
go

create trigger trTableWithTriggerAfterFor
on TableWithTriggerAfter
for insert, update, delete
as
begin
	set nocount on

	print N'trTableWithTriggerAfterFor'

	declare
		@cnt int,
		@tmpStr nvarchar(max),
		@tmpId bigint,
		@tmpValue nvarchar(256)

	select @cnt=count(*) from inserted
	set @tmpStr='inserted count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	select @cnt=count(*) from deleted
	set @tmpStr='deleted count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	if exists (
		select
			inserted.id,
			inserted.value,
			deleted.id,
			deleted.value
		from
			inserted inserted
			join deleted deleted on deleted.id=inserted.id)
		print 'exists'
	else
		print '!exists'

	select @cnt=count(*) from TableWithTriggerAfter
	set @tmpStr='TableWithTriggerAfter count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	declare	#CursorInTrTableWithTriggerAfterFor cursor for
		select
			id,
			value
		from
			TableWithTriggerAfter
		for read only

	open #CursorInTrTableWithTriggerAfterFor
	fetch from #CursorInTrTableWithTriggerAfterFor into @tmpId, @tmpValue
	while @@fetch_status=0
		begin
			set @tmpStr=N'id='+convert(nvarchar(max), @tmpId)+N', value='''+coalesce(@tmpValue, N'NULL')+N''''
			print @tmpStr

			fetch from #CursorInTrTableWithTriggerAfterFor into @tmpId, @tmpValue
		end
	close #CursorInTrTableWithTriggerAfterFor
	deallocate #CursorInTrTableWithTriggerAfterFor
end
go