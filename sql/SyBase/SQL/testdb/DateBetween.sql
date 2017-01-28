use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('DateBetween')
            and    type = 'U')
   drop table DateBetween
go

create table DateBetween(
  Id tinyint not null,
  DateBegin date null,
  DateEnd date null
) lock datarows
go
