use LessonProject
go

if object_id(N'UserRole', N'u') is not null
	drop table UserRole
go

create table UserRole
(
	ID int not null identity constraint pkUserRole primary key,
	UserID int not null constraint fk_UserRole_User foreign key references [User](ID) on update cascade on delete cascade,
	RoleID int not null constraint fk_UserRole_Role foreign key references [Role](ID) on update cascade on delete cascade
)
go
