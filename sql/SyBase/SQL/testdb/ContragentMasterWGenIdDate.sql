use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('ContragentMasterWGenIdDate')
            and    type = 'U')
   drop table ContragentMasterWGenIdDate
go

create table ContragentMasterWGenIdDate
(
   Id numeric(18,0),
   GenId numeric(18,0)
) lock datarows
go
