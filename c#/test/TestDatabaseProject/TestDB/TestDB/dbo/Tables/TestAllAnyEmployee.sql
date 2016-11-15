CREATE TABLE [dbo].[TestAllAnyEmployee] (
    [id]            INT            NOT NULL,
    [department_id] INT            NULL,
    [chief_id]      INT            NULL,
    [name]          NVARCHAR (255) NULL,
    [salary]        MONEY          NULL,
    CONSTRAINT [pkTestAllAnyEmployee] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fkTestAllAnyDepartmentEmployee] FOREIGN KEY ([department_id]) REFERENCES [dbo].[TestAllAnyDepartment] ([id]),
    CONSTRAINT [fkTestAllAnyEmployeeEmployee] FOREIGN KEY ([chief_id]) REFERENCES [dbo].[TestAllAnyEmployee] ([id])
);

