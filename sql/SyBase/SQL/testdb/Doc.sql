use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('Doc')
            and    type = 'U')
   drop table Doc
go

create table Doc
(
   Id int not null,
   DocNo varchar(20) null,
   DocSeries varchar(5) null,
   constraint pkDoc primary key(Id)
) lock datarows
go
