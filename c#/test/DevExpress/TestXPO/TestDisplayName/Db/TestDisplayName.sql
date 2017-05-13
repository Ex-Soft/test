if object_id(N'TestDisplayName', N'u') is not null
	drop table TestDisplayName;

create table TestDisplayName
(
	Id int not null identity constraint pkTestDisplayName primary key,
	Name nvarchar(256) null
);