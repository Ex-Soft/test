use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TableWIdentityDetails'))
             and (type='U'))
   drop table TableWIdentityDetails
go

create table TableWIdentityDetails
(
   Id numeric(18,0) identity,
   IdMaster numeric(18,0) not null,
   Value varchar(254)
) lock datarows with identity_gap=10
go
