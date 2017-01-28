use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('EmptyTable')
            and    type = 'U')
   drop table EmptyTable
go

create table EmptyTable
(
   Id numeric(18,0) identity
) lock datarows with identity_gap=10
go
