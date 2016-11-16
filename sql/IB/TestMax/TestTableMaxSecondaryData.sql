execute block
as
begin
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (1, 1, current_date, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (2, 1, current_date+1, 2);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (3, 1, current_date+2, 3);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (4, 1, current_date+3, 4);

insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (5, 2, current_date, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (6, 2, current_date+1, 3);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (7, 2, current_date+2, 5);

insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (8, 3, current_date, 1);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (9, 4, current_date, 2);
insert into TestTableMaxSecondary (id, parent_id, dt, value_id) values (10, 5, current_date, 3);
end;