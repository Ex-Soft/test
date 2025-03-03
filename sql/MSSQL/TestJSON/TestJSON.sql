use testdb;
go

if object_id(N'TestJson', N'u') is not null
  drop table TestJson;
go

create table TestJson
(
   Id int not null identity constraint pkTestJson primary key,
   JsonDataObject json null constraint chkTestJsonJsonDataObject check (isjson(JsonDataObject) = 1),
   JsonDataArray json null constraint chkTestJsonJsonDataArray check (isjson(JsonDataArray) = 1)
)
go
