CREATE TABLE [dbo].[TableWithTriggerU] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,
    [value1]       INT      NULL,
    [value2]       INT      NULL,
    [value3]       INT      NULL,
    [recordModify] DATETIME NULL,
    CONSTRAINT [pkTableWithTriggerU] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

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
