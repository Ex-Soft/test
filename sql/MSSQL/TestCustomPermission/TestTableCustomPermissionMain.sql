use testdb
go

if object_id('TestTableCustomPermissionMain', N'u') is not null
  drop table TestTableCustomPermissionMain
go

create table TestTableCustomPermissionMain
(
   Id numeric(18,0) not null identity constraint 'pkTestTableCustomPermissionMain' primary key,
   Id_1 numeric(18,0) null,
   Id_2 numeric(18,0) null
)
go
