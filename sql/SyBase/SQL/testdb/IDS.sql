use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('IDS')
            and    type = 'U')
   drop table IDS
go

create table IDS(
  TABLE_ID int not null,
  VALUE_ID numeric(18,0) not null,
  TABLE_NAME D_SYSNAME null   
)lock datarows
go
