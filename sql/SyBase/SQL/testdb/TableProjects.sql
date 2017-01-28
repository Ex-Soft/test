use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TableProjects')
            and    type = 'U')
   drop table TableProjects
go

create table TableProjects
(
   id numeric(18,0) identity,
   date_create date,
   name_project varchar(256),
   year_project int
) lock datarows with identity_gap=10
go
