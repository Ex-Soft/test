CREATE TABLE [dbo].[TestDETableRight] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Val]                 VARCHAR (255) NULL,
    [ValRight]            VARCHAR (255) NULL,
    [OptimisticLockField] INT           NULL,
    CONSTRAINT [pkTestDETableRight] PRIMARY KEY CLUSTERED ([Id] ASC)
);

