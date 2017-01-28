use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestCOALESCE2')
            and    type = 'U')
   drop table TestCOALESCE2
go

create table TestCOALESCE2(
  Id numeric(18,0) not null,
  Value varchar(180) null   
  ValueNumeric18_0 numeric(18,0) null,
  ValueDNumeric18_0 D_NUMERIC18_0 null
) lock datarows
go
