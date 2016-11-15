CREATE TABLE [dbo].[TestTable4TestPIVOTList] (
    [Id]        INT NOT NULL,
    [IdProduct] INT NULL,
    [IdStore]   INT NULL,
    [Cnt]       INT NULL,
    CONSTRAINT [pkTestTable4TestPIVOTList] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fkTestTable4TestPIVOTList_Products] FOREIGN KEY ([IdProduct]) REFERENCES [dbo].[TestTable4TestPIVOTProducts] ([Id]),
    CONSTRAINT [fkTestTable4TestPIVOTList_Stores] FOREIGN KEY ([IdStore]) REFERENCES [dbo].[TestTable4TestPIVOTStores] ([Id])
);

