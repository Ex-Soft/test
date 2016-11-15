CREATE TABLE [dbo].[TestTableManyToOne] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [A]             NVARCHAR (10)  NULL,
    [B]             NVARCHAR (10)  NULL,
    [C]             NVARCHAR (10)  NULL,
    [D]             NVARCHAR (10)  NULL,
    [E]             NVARCHAR (10)  NULL,
    [F]             NVARCHAR (10)  NULL,
    [G]             NVARCHAR (10)  NULL,
    [H]             NVARCHAR (10)  NULL,
    [I]             NVARCHAR (10)  NULL,
    [Discriminator] NVARCHAR (MAX) NULL,
    CONSTRAINT [pkTestTableManyToOne] PRIMARY KEY CLUSTERED ([id] ASC)
);

