insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (1, 1, sysdate, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (2, 1, sysdate+1, 2);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (3, 1, sysdate+2, 3);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (4, 1, sysdate+3, 4);

insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (5, 2, sysdate, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (6, 2, sysdate+1, 3);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (7, 2, sysdate+2, 5);

insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (8, 3, sysdate, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (9, 4, sysdate, 2);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (10, 5, sysdate, 3);
