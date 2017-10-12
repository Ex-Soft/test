use testdb
go

if object_id(N'Customer', N'u') is not null
	drop table Customer
go

if object_id(N'Executive', N'u') is not null
	drop table Executive
go

if object_id(N'Employee', N'u') is not null
	drop table Employee
go

if object_id(N'Person', N'u') is not null
	drop table Person
go

create table Person
(
	Id int not null constraint pkPerson primary key,
	Name nvarchar(256)
)
go

create table Employee
(
	Id int not null constraint pkEmployee primary key,
	Salary money
)
go

create table Customer
(
	Id int not null constraint pkCustomer primary key,
	Preferences nvarchar(256)
)
go

create table Executive
(
	Id int not null constraint pkExecutive primary key,
	Bonus money
)
go
