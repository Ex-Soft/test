use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('Presidents')
            and    type = 'U')
   drop table Presidents
go

create table Presidents(
  Id tinyint not null,
  FirstName varchar(256) null,
  LastName varchar(256) null,
  FirstNameEn varchar(256) null,
  LastNameEn varchar(256) null,
  Born date null,
  Died date null,
  DateBegin date null,
  DateEnd date null
) lock datarows
go
