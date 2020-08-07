CREATE TABLE [dbo].[Table4TestTransaction] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [value]               NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [GCRecord]            INT            NULL,
    CONSTRAINT [pkTable4TestTransaction] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_Table4TestTransaction]
    ON [dbo].[Table4TestTransaction]([GCRecord] ASC);


GO

create trigger Trigger4Table4TestTransactionIUD
on Table4TestTransaction
for insert, update, delete  
as  
begin
	set nocount on

	insert into Table4TestTransactionLog (tableName, idRecord, value, spid, trancount) select N'inserted', id, value, @@spid, @@trancount from inserted
	insert into Table4TestTransactionLog (tableName, idRecord, value, spid, trancount) select N'deleted', id, value, @@spid, @@trancount from deleted
end
