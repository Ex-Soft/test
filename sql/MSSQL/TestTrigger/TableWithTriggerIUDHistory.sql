use testdb
go

if object_id(N'TableWithTriggerIUDHistory', N'u') is not null
  drop table TableWithTriggerIUDHistory
go

create table TableWithTriggerIUDHistory
(
  Id numeric(18,0) not null,
  Value varchar(256) not null,
  RecordModify datetime not null   
)
go