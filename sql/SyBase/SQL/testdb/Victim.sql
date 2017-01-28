use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('Victim')
            and    type = 'U')
   drop table Victim
go

create table Victim
(
   Id int not null,
   Val int not null
) lock datarows
go
