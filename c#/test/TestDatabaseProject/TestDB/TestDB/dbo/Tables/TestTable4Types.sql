CREATE TABLE [dbo].[TestTable4Types] (
    [Id]                  BIGINT             NOT NULL,
    [FVarChar]            VARCHAR (256)      NULL,
    [FNVarChar]           NVARCHAR (256)     NULL,
    [FBit]                BIT                NULL,
    [FDate]               DATE               NULL,
    [FTime]               TIME (7)           NULL,
    [FDateTime]           DATETIME           NULL,
    [FDateTime2]          DATETIME2 (7)      NULL,
    [FSmallDateTime]      SMALLDATETIME      NULL,
    [FDateTimeOffset]     DATETIMEOFFSET (7) NULL,
    [FXml]                XML                NULL,
    [OptimisticLockField] INT                NULL,
    [GCRecord]            INT                NULL,
    [FNumeric_30_15]      NUMERIC (30, 15)   NULL,
    [FVarBinary_28]       VARBINARY (28)     NULL,
    CONSTRAINT [pkTestTable4Types] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CheckTestTable4TypesFNumeric_30_15] CHECK ([FNumeric_30_15]>=(-79228162514264.337593543950335) AND [FNumeric_30_15]<=(79228162514264.337593543950335))
);


GO
CREATE NONCLUSTERED INDEX [iGCRecord_TestTable4Types]
    ON [dbo].[TestTable4Types]([GCRecord] ASC);

