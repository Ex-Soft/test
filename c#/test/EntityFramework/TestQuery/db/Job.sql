use testdb
go

if object_id(N'Job', N'u') is not null
	drop table [Job]
go

create table [Job]
(
   JobID int not null identity constraint pkJob primary key,
   Name nvarchar(255)
)
go

if not exists (select 1 from syscolumns	where id = object_id(N'Job') and name = N'Name')
	alter table [Job] add Name nvarchar(255) null
else
	print N'Job.Name already exists!!!'
go
