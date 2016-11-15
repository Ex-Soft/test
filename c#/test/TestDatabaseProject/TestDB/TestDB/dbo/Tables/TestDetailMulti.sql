CREATE TABLE [dbo].[TestDetailMulti] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IdMaster] INT            NOT NULL,
    [Val]      NVARCHAR (255) NULL,
    CONSTRAINT [pkTestDetailMulti] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fkTestMasterXTestDetailMulti] FOREIGN KEY ([IdMaster]) REFERENCES [dbo].[TestMasterX] ([Id]),
    CONSTRAINT [fkTestMasterYTestDetailMulti] FOREIGN KEY ([IdMaster]) REFERENCES [dbo].[TestMasterY] ([Id])
);


GO
ALTER TABLE [dbo].[TestDetailMulti] NOCHECK CONSTRAINT [fkTestMasterXTestDetailMulti];


GO
ALTER TABLE [dbo].[TestDetailMulti] NOCHECK CONSTRAINT [fkTestMasterYTestDetailMulti];

