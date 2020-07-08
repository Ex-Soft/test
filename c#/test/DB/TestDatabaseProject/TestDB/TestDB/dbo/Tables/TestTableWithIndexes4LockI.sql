CREATE TABLE [dbo].[TestTableWithIndexes4LockI] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [idSmthI]  INT           NOT NULL,
    [idSmthII] INT           NOT NULL,
    [FieldI]   NVARCHAR (50) NOT NULL,
    [FieldII]  NVARCHAR (50) NOT NULL,
    [FieldIII] INT           NULL,
    [FieldIV]  BINARY (16)   NULL,
    CONSTRAINT [pkTestTableWithIndexes4LockI] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [fkTestTableWithIndexes4LockI_II] FOREIGN KEY ([idSmthI]) REFERENCES [dbo].[TestTableWithIndexes4LockII] ([id])
);


GO
CREATE UNIQUE CLUSTERED INDEX [idx_TestTableWithIndexes4LockI_idSmthII_idSmthI]
    ON [dbo].[TestTableWithIndexes4LockI]([idSmthII] ASC, [idSmthI] ASC);

