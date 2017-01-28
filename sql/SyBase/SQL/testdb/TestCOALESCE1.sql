use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestCOALESCE1')
            and    type = 'U')
   drop table TestCOALESCE1
go

create table TestCOALESCE1(
  Id numeric(10,0) not null,
  Value varchar(100) null,
  ValueNumeric10_0 numeric(10,0) null,
  ValueDNumeric10_0 D_NUMERIC10_0 null
) lock datarows
go
