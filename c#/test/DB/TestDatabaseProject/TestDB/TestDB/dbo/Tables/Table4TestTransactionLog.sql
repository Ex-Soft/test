CREATE TABLE [dbo].[Table4TestTransactionLog] (
    [id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [tableName] NVARCHAR (8)   NOT NULL,
    [idRecord]  INT            NOT NULL,
    [value]     NVARCHAR (255) NULL,
    [datetime]  DATETIME       DEFAULT (getdate()) NULL,
    [spid]      SMALLINT       NOT NULL,
    [trancount] INT            NOT NULL,
    CONSTRAINT [pkTable4TestTransactionLog] PRIMARY KEY CLUSTERED ([id] ASC)
);

