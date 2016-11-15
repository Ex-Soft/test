CREATE TABLE [dbo].[TestTableWithIndexesII] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Field1] INT NULL,
    [Field2] INT NULL,
    CONSTRAINT [pkTestTableWithIndexesII] PRIMARY KEY CLUSTERED ([Id] ASC)
);

