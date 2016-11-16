use testdb
go

if object_id(N'TestAllAnyEmployee', N'u') is not null
	drop table TestAllAnyEmployee
go

create table TestAllAnyEmployee
(
	id int not null constraint pkTestAllAnyEmployee primary key,
	department_id int null constraint fkTestAllAnyDepartmentEmployee foreign key references TestAllAnyDepartment (id),
	chief_id int null constraint fkTestAllAnyEmployeeEmployee foreign key references TestAllAnyEmployee (id),
	name nvarchar(255),
	salary money null
)
go
