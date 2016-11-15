CREATE TABLE [dbo].[TestDEDetailTableWithInheritance] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [idMaster]            INT            NULL,
    [valueLite]           NVARCHAR (255) NULL,
    [value]               NVARCHAR (255) NULL,
    [OptimisticLockField] INT            NULL,
    [ObjectType]          INT            NULL,
    CONSTRAINT [pkTestDEDetailTableWithInheritance] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fkTestDEDetailTableWithInheritance_ObjectType] FOREIGN KEY ([ObjectType]) REFERENCES [dbo].[XPObjectType] ([OID]) NOT FOR REPLICATION,
    CONSTRAINT [fkTestDEDetailTableWithInheritance_TestDEMasterTableWithInheritance] FOREIGN KEY ([idMaster]) REFERENCES [dbo].[TestDEMasterTableWithInheritance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iidMaster_TestDEDetailTableWithInheritance]
    ON [dbo].[TestDEDetailTableWithInheritance]([idMaster] ASC);


GO
CREATE NONCLUSTERED INDEX [iObjectType_TestDEDetailTableWithInheritance]
    ON [dbo].[TestDEDetailTableWithInheritance]([ObjectType] ASC);

