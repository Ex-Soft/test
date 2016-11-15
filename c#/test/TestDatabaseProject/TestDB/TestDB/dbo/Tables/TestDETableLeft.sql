CREATE TABLE [dbo].[TestDETableLeft] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Val]                 VARCHAR (255) NULL,
    [ValLeft]             VARCHAR (255) NULL,
    [OptimisticLockField] INT           NULL,
    CONSTRAINT [pkTestDETableLeft] PRIMARY KEY CLUSTERED ([Id] ASC)
);

