use testdb
go

if object_id(N'Table4TestTransaction', N'u') is not null
	drop table Table4TestTransaction
go

create table Table4TestTransaction
(
	id int not null identity constraint pkTable4TestTransaction primary key,
	value nvarchar(255) null
)
go

if object_id(N'Trigger4Table4TestTransactionIUD', N'tr') is not null
	drop trigger Trigger4Table4TestTransactionIUD
go

create trigger Trigger4Table4TestTransactionIUD
on Table4TestTransaction
for insert, update, delete  
as  
begin
	set nocount on

	insert into Table4TestTransactionLog (tableName, idRecord, value, spid, trancount) select N'inserted', id, value, @@spid, @@trancount from inserted
	insert into Table4TestTransactionLog (tableName, idRecord, value, spid, trancount) select N'deleted', id, value, @@spid, @@trancount from deleted
end
go