use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TableMaster')
            and    type = 'U')
   drop table TableMaster
go

create table TableMaster
(
   Id int not null identity constraint pkTableMaster primary key,
   Val varchar(254) null
)
go
