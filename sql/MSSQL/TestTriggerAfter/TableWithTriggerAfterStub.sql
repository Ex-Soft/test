use testdb
go

if object_id(N'TableWithTriggerAfterStub', N'u') is not null
	drop table TableWithTriggerAfterStub
go

create table TableWithTriggerAfterStub
(
	id bigint not null constraint pkTableWithTriggerAfterStub primary key,
	value nvarchar(256) null
)
go

if object_id(N'trTableWithTriggerAfterStub', N'tr') is not null
	drop trigger trTableWithTriggerAfterStub
go

create trigger trTableWithTriggerAfterStub
on TableWithTriggerAfterStub
instead of insert, update, delete
as
begin
	set nocount on

	print N'trTableWithTriggerAfterStub'

	declare
		@cnt int,
		@tmpStr nvarchar(max),
		@tmpId bigint,
		@tmpValue nvarchar(256)

	select @cnt=count(*) from TableWithTriggerAfter
	set @tmpStr='TableWithTriggerAfter count(*)='+convert(nvarchar(max),@cnt)
	print @tmpStr

	declare	#CursorInTrTableWithTriggerAfterStub cursor for
		select
			id,
			value
		from
			TableWithTriggerAfter
		for read only

	open #CursorInTrTableWithTriggerAfterStub
	fetch from #CursorInTrTableWithTriggerAfterStub into @tmpId, @tmpValue
	while @@fetch_status=0
		begin
			set @tmpStr=N'id='+convert(nvarchar(max), @tmpId)+N', value='''+coalesce(@tmpValue, N'NULL')+N''''
			print @tmpStr

			fetch from #CursorInTrTableWithTriggerAfterStub into @tmpId, @tmpValue
		end
	close #CursorInTrTableWithTriggerAfterStub
	deallocate #CursorInTrTableWithTriggerAfterStub
end
go
