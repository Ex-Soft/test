create table [dbo].[Staff]
(
   [ID] BIGINT NOT NULL IDENTITY CONSTRAINT pkStaff PRIMARY KEY,
   [Name] NVARCHAR(255) NULL,
   [Salary] MONEY NULL,
   [Dep] INT NULL,
   [BirthDate] DATE NULL,
   [NullField] NUMERIC(18,0) NULL
)