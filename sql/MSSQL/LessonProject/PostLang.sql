use LessonProject
go

if object_id(N'PostLang', N'u') is not null
	drop table PostLang
go

create table PostLang
(
	ID int not null identity constraint pkPostLang primary key,
	PostID int not null constraint fk_PostLang_Post foreign key references [Post](ID) on update cascade on delete cascade,
	LanguageID int not null constraint fk_PostLang_Language foreign key references [Language](ID),
	Header nvarchar(500) not null,
	Content nvarchar(max) not null
)
go
