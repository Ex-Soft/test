use testdb
go

if object_id(N'Table4TestTransactionLog', N'u') is not null
	drop table Table4TestTransactionLog
go

create table Table4TestTransactionLog
(
	id bigint not null identity constraint pkTable4TestTransactionLog primary key,
	tableName nvarchar(8) not null,
	idRecord int not null,
	value nvarchar(255) null,
	[datetime] datetime default getdate(),
	spid smallint not null,
	trancount int not null
)
go