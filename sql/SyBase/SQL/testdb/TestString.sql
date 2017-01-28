use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestString')
            and    type = 'U')
   drop table TestString
go

create table TestString
(
   Id int not null constraint pkTestString primary key,
   Val varchar(254) null
) lock datarows
go
