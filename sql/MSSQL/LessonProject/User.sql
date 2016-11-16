use LessonProject
go

if object_id(N'User', N'u') is not null
	drop table [User]
go

create table [User]
(
	ID int not null identity constraint pkUser primary key,
	Email nvarchar(150) not null,
	[Password] nvarchar(50) not null,
	AddedDate datetime not null,
	ActivatedDate datetime null,
	ActivatedLink nvarchar(50) not null,
	LastVisitDate datetime null,
	AvatarPath nvarchar(150) null,
	Birthdate datetime not null default N'20120101',
	LanguageID int null constraint fk_User_Language foreign key references [Language](ID)
)
go

if not exists (select * from sys.columns where object_id = object_id(N'User', N'u') and name = N'LanguageID')
	alter table [User] add LanguageID int null constraint fk_User_Language foreign key references [Language](ID)
go
