use testdb
go

if object_id(N'TestDE', N'u') is not null
	drop table TestDE
go

create table TestDE
(
	id bigint not null identity constraint pkTestDE primary key,
	f1 int null,
	f2 int null,
	f3 int null
)
go

if object_id(N'TestDE', N'p') is not null
	drop procedure TestDEUpdater
go

create procedure TestDEUpdater
as
begin
	set nocount on

	update TestDE set f1 = f1 + 1 where id = 1

	return 0
end
go