CREATE TABLE [dbo].[TestDE] (
    [id]                  BIGINT IDENTITY (1, 1) NOT NULL,
    [f1]                  INT    NULL,
    [f2]                  INT    NULL,
    [f3]                  INT    NULL,
    [OptimisticLockField] INT    NULL,
    [GCRecord]            INT    NULL,
    CONSTRAINT [pkTestDE] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestDE]
    ON [dbo].[TestDE]([GCRecord] ASC);

