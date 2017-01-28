use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TT1')
            and    type = 'U')
   drop table TT1
go

create table TT1
(
   Id int not null constraint pkTT1 primary key,
   Val varchar(256)
) lock datarows
go
