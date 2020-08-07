CREATE TABLE [dbo].[TestMaster] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Val]                 NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [GCRecord]            INT            NULL,
    [IdForView]           AS             ([Id]),
    CONSTRAINT [pkTestMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestMaster]
    ON [dbo].[TestMaster]([GCRecord] ASC);

