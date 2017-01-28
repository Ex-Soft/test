use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TableLog')
            and    type = 'U')
   drop table TableLog
go

create table TableLog(
  Id numeric(18,0) identity,
  FDateTime datetime null,
  spid int null,
  Message varchar(255) null
)lock datarows with identity_gap=10
go 