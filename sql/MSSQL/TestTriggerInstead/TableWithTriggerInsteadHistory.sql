use testdb
go

if object_id(N'TableWithTriggerInsteadHistory', N'u') is not null
  drop table TableWithTriggerInsteadHistory
go

create table TableWithTriggerInsteadHistory
(
  Id numeric(18,0) not null,
  Value varchar(256) not null,
  RecordModify datetime not null   
)
go