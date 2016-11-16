delete from TestTableCustomPermissionMain
commit;

insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (1, 1, 2);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (2, 1, 3);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (3, 1, 4);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (4, 1, 5);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (5, 1, null);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (6, 2, 1);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (7, 2, 3);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (8, 2, 4);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (9, 2, 5);
insert into TestTableCustomPermissionMain (Id, Id_1, Id_2) values (10, 2, null);
commit;

