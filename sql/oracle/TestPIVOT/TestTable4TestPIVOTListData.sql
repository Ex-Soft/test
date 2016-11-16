delete from TestTable4TestPIVOTList;
commit;

insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 1, 3, 10);
insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 1, 4, 15);

insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 2, 1, 1);
insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 2, 2, 1);
insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 2, 3, 2);
insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 2, 4, 10);

insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 3, 2, 1);
insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 3, 3, 5);

insert into TestTable4TestPIVOTList (Id, IdProduct, IdStore, Cnt) values (1, 6, 4, 1);
commit;
