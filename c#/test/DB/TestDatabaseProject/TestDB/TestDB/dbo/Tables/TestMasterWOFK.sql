CREATE TABLE [dbo].[TestMasterWOFK] (
    [Id]                  INT            NOT NULL,
    [Val]                 NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [GCRecord]            INT            NULL,
    CONSTRAINT [pkTestMasterWOFK] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestMasterWOFK]
    ON [dbo].[TestMasterWOFK]([GCRecord] ASC);

