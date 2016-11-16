insert into TestTableWithTriggers (id, val) values (1, 1);
insert into TestTableWithTriggers (id, val) values (2, 2);
insert into TestTableWithTriggers (id, val) values (3, 3);
insert into TestTableWithTriggers (id, val) values (4, 4);
insert into TestTableWithTriggers (id, val) values (5, 5);
insert into TestTableWithTriggers (id, val) values (6, 6);
insert into TestTableWithTriggers (id, val) values (7, 7);
insert into TestTableWithTriggers (id, val) values (8, 8);
insert into TestTableWithTriggers (id, val) values (9, 9);
insert into TestTableWithTriggers (id, val) values (10, 10);
commit;

update TestTableWithTriggers set val=val*10;
commit;

select * from TestTableWithTriggers;