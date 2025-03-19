use testdb;
go

if object_id(N'TestTable4ApplyI', N'u') is not null
  drop table TestTable4ApplyI;
go

create table TestTable4ApplyI
(
   Id int not null identity constraint pkTestTable4ApplyI primary key,
   Field1 int null,
   Field2 int null
);
go
