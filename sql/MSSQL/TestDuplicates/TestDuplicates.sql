use testdb
go

if object_id(N'TestDuplicates', N'u') is not null
  drop table TestDuplicates
go

create table TestDuplicates
(
   id int not null constraint pkTestDuplicates primary key,
   F1 int null,
   F2 int null,
   F3 int null
)
go
