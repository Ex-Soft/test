CREATE TABLE [dbo].[TestDetailWOFK] (
    [Id]                  INT            NOT NULL,
    [IdMaster]            INT            NULL,
    [Val]                 NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [GCRecord]            INT            NULL,
    CONSTRAINT [pkTestDetailWOFK] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fkTestMasterWOFKTestDetailWOFK] FOREIGN KEY ([IdMaster]) REFERENCES [dbo].[TestMasterWOFK] ([Id])
);


GO
ALTER TABLE [dbo].[TestDetailWOFK] NOCHECK CONSTRAINT [fkTestMasterWOFKTestDetailWOFK];


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestDetailWOFK]
    ON [dbo].[TestDetailWOFK]([GCRecord] ASC);


GO
CREATE NONCLUSTERED INDEX [iIdMaster_TestDetailWOFK]
    ON [dbo].[TestDetailWOFK]([IdMaster] ASC);

