use testdb
go

if object_id(N'Document', N'u') is not null
	drop table Document
go

create table Document
(
   DocumentId int not null identity constraint pkDocument primary key,
   JobId int not null constraint fk_Document_Job foreign key references [Job](JobID),
   DocumentTypeId int not null,
   DocumentStatus int not null
)
go
