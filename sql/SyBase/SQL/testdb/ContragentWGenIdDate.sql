use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('ContragentWGenIdDate')
            and    type = 'U')
   drop table ContragentWGenIdDate
go

create table ContragentWGenIdDate
(
   Id numeric(18,0),
   GenId numeric(18,0) identity,
   Name varchar(1024),
   RecordModify datetime
) lock datarows with identity_gap=10
go
