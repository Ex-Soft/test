CREATE TABLE [dbo].[TableWithTriggerAfterStub] (
    [id]    BIGINT         NOT NULL,
    [value] NVARCHAR (256) NULL,
    CONSTRAINT [pkTableWithTriggerAfterStub] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

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
