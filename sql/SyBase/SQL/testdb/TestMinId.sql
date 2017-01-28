use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TestMinId'))
             and (type='U'))
   drop table TestMinId
go

create table TestMinId
(
   Id int not null constraint pkTestMinId primary key,
   IdDate date
) lock datarows
go
