use testdb
go

delete from TestAllAnyDepartment
go

insert into TestAllAnyDepartment (id, name) values (1, N'Department# 1')
insert into TestAllAnyDepartment (id, name) values (2, N'Department# 2')
insert into TestAllAnyDepartment (id, name) values (3, N'Department# 3')
go
