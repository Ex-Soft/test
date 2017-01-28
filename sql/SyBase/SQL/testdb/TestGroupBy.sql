use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestGroupBy')
            and    type = 'U')
   drop table TestGroupBy
go

create table TestGroupBy
(
   Id1 int not null,
   Id2 int not null,
   Id3 int not null,
   Val int not null
) lock datarows
go
