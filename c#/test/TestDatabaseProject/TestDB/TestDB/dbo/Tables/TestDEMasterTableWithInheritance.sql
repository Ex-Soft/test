CREATE TABLE [dbo].[TestDEMasterTableWithInheritance] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [valueLite]           NVARCHAR (255) NULL,
    [value]               NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [ObjectType]          INT            NULL,
    CONSTRAINT [pkTestDEMasterTableWithInheritance] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fkTestDEMasterTableWithInheritance_ObjectType] FOREIGN KEY ([ObjectType]) REFERENCES [dbo].[XPObjectType] ([OID]) NOT FOR REPLICATION
);


GO
CREATE NONCLUSTERED INDEX [iObjectType_TestDEMasterTableWithInheritance]
    ON [dbo].[TestDEMasterTableWithInheritance]([ObjectType] ASC);

