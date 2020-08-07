CREATE TABLE [dbo].[TestTableWithIndexesI] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Field1] INT NULL,
    [Field2] INT NULL,
    CONSTRAINT [pkTestTableWithIndexesI] PRIMARY KEY CLUSTERED ([Id] ASC)
);

