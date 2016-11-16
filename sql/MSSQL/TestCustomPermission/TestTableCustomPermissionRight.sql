use testdb
go

if object_id('TestTableCustomPermissionRight', N'u') is not null
  drop table TestTableCustomPermissionRight
go

create table TestTableCustomPermissionRight
(
   Id numeric(18,0) not null identity constraint 'pkTestTableCustomPermissionRight' primary key,
   Allow numeric(18,0) not null
)
go
