CREATE TABLE [dbo].[TestTable4ReadLock] (
    [Id]          INT            NOT NULL,
    [Value]       INT            NOT NULL,
    [Placeholder] NVARCHAR (200) CONSTRAINT [Def_TestTable4ReadLock_Placeholder] DEFAULT (N'a') NOT NULL,
    CONSTRAINT [PK_TestTable4ReadLock] PRIMARY KEY CLUSTERED ([Id] ASC)
);

