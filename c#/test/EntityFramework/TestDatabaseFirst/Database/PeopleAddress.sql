CREATE TABLE [dbo].[PeopleAddress]
(
	[Id] INT NOT NULL CONSTRAINT pkPeopleAddress PRIMARY KEY IDENTITY,
	[PeopleId] INT NOT NULL CONSTRAINT fk_PeopleAddress_Peoples FOREIGN KEY REFERENCES [dbo].[Peoples] ([Id]),
	[AddressId] INT NOT NULL CONSTRAINT fk_PeopleAddress_Addresses FOREIGN KEY REFERENCES [dbo].[Addresses] ([Id])
)
