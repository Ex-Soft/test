use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TestStringSort'))
             and (type='U'))
   drop table TestStringSort
go

create table TestStringSort
(
   Val varchar(254) null
) lock datarows
go
