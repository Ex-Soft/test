CREATE TABLE [dbo].[TableWithHierarchy] (
    [Id]       INT            NOT NULL,
    [ParentId] INT            NULL,
    [Val]      NVARCHAR (255) NULL,
    CONSTRAINT [pk_TableWithHierarchy] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_TableWithHierarchy] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[TableWithHierarchy] ([Id])
);

