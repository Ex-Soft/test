CREATE TABLE [dbo].[Staff] (
    [ID]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]                VARCHAR (255) NULL,
    [Salary]              MONEY         NULL,
    [Dep]                 INT           NULL,
    [BirthDate]           DATE          NULL,
    [NullField]           NUMERIC (18)  NULL,
    [OptimisticLockField] INT           NULL,
    [GCRecord]            INT           NULL,
    CONSTRAINT [pkStaff] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_Staff]
    ON [dbo].[Staff]([GCRecord] ASC);

