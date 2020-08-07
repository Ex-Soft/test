CREATE TABLE [dbo].[XPObjectType] (
    [OID]          INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [TypeName]     NVARCHAR (254) NULL,
    [AssemblyName] NVARCHAR (254) NULL,
    CONSTRAINT [PK_XPObjectType] PRIMARY KEY CLUSTERED ([OID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iTypeName_XPObjectType]
    ON [dbo].[XPObjectType]([TypeName] ASC);

