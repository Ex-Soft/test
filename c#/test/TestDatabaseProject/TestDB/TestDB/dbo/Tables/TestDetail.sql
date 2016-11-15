CREATE TABLE [dbo].[TestDetail] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [IdMaster]            INT           NOT NULL,
    [Val]                 VARCHAR (255) NULL,
    [OptimisticLockField] INT           NULL,
    [GCRecord]            INT           NULL,
    CONSTRAINT [pkTestDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fkTestMasterTestDetail] FOREIGN KEY ([IdMaster]) REFERENCES [dbo].[TestMaster] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestDetail]
    ON [dbo].[TestDetail]([GCRecord] ASC);


GO
CREATE NONCLUSTERED INDEX [iIdMaster_TestDetail]
    ON [dbo].[TestDetail]([IdMaster] ASC);

