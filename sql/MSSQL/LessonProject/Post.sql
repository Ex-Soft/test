use LessonProject
go

if object_id(N'Post', N'u') is not null
	drop table Post
go

create table Post
(
	ID int not null identity constraint pkPost primary key,
	UserID int not null constraint fk_Post_User foreign key references [User](ID),
	Url nvarchar(500) not null,
	AddedDate datetime not null
)
go
