use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('T4')
            and    type = 'U')
   drop table T4
go

create table T4
(
   GroupId int not null,
   Id int not null,
   Val varchar(256),
   constraint pkT4 primary key(GroupId,Id)
) lock datarows
go
