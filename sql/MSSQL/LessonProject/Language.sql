use LessonProject
go

if object_id(N'Language', N'u') is not null
	drop table [Language]
go

create table [Language]
(
	ID int not null identity constraint pkLanguage primary key,
	Code nvarchar(50) not null,
	Name nvarchar(50) not null
)
go
