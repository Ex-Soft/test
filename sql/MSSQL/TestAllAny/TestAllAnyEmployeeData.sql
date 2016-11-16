use testdb
go

delete from TestAllAnyEmployee
go

insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (1, 1, null, N'Chief of Department# 1', 1000)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (2, 2, null, N'Chief of Department# 2', 2000)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (3, 3, null, N'Chief of Department# 3', 3000)

insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (4, 1, 1, N'Employee# 1 of Department# 1', 900)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (5, 1, 1, N'Employee# 2 of Department# 1', 1100)

insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (6, 2, 2, N'Employee# 1 of Department# 2', 1900)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (7, 2, 2, N'Employee# 2 of Department# 2', 2100)

insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (8, 3, 3, N'Employee# 1 of Department# 3', 2900)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (9, 3, 3, N'Employee# 2 of Department# 3', 3100)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (10, 3, 3, N'Employee# 3 of Department# 3', 3200)
insert into TestAllAnyEmployee (id, department_id, chief_id, name, salary) values (11, 3, 2, N'Employee# 4 of Department# 3', 3300)
go
