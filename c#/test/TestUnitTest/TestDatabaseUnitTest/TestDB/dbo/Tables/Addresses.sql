﻿CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL IDENTITY CONSTRAINT pkAddresses PRIMARY KEY, 
    [Country] NVARCHAR(255) NOT NULL 
)