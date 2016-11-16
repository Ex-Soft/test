use LessonProject
go

if object_id(N'Role', N'u') is not null
	drop table Role
go

create table Role
(
	ID int not null identity constraint pkRole primary key,
	Code nvarchar(50) not null,
	Name nvarchar(50) not null
)
go
