use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('ContragentDetailWGenIdDate')
            and    type = 'U')
   drop table ContragentDetailWGenIdDate
go

create table ContragentDetailWGenIdDate
(
   GenId numeric(18,0) identity,
   Name varchar(1024),
   RecordModify datetime
) lock datarows with identity_gap=10
go
