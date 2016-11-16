use testdb
go

delete from TestTableCustomPermissionRight
go

insert into TestTableCustomPermissionRight (Allow) values (1)
insert into TestTableCustomPermissionRight (Allow) values (3)
go
