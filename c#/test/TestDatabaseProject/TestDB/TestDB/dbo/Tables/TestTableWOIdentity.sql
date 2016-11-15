CREATE TABLE [dbo].[TestTableWOIdentity] (
    [Id]                  INT            NOT NULL,
    [Val]                 NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [GCRecord]            INT            NULL,
    CONSTRAINT [pkTestTableWOIdentity] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestTableWOIdentity]
    ON [dbo].[TestTableWOIdentity]([GCRecord] ASC);

