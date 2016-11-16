use testdb
go

delete from TestTableCustomPermissionMain
go

insert into TestTableCustomPermissionMain (Id_1, Id_2) values (1, 2)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (1, 3)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (1, 4)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (1, 5)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (1, null)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (2, 1)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (2, 3)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (2, 4)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (2, 5)
insert into TestTableCustomPermissionMain (Id_1, Id_2) values (2, null)

go
