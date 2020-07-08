CREATE TABLE [dbo].[TestTableWithNullField] (
    [id]  INT IDENTITY (1, 1) NOT NULL,
    [val] INT NULL,
    CONSTRAINT [pkTestTableWithNullField] PRIMARY KEY CLUSTERED ([id] ASC)
);

