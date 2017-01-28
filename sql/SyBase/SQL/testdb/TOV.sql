use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TOV'))
             and (type='U'))
   drop table TOV
go

create table TOV
(
   ID int not null,
   CNT int
) lock datarows
go
