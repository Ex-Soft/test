use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TestCursorMain'))
             and (type = 'U'))
   drop table TestCursorMain
go

create table TestCursorMain
(
   Id numeric(18,0) not null,
   Val numeric(18,0) not null,
   Cod numeric(18,0) null
) lock datarows
go
