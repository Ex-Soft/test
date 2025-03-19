use testdb;
go

if object_id(N'TestTable4ApplyII', N'u') is not null
  drop table TestTable4ApplyII;
go

create table TestTable4ApplyII
(
   Id int not null identity constraint pkTestTable4ApplyII primary key,
   Field1 int null,
   Field2 int null
);
go
