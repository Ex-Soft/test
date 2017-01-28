use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestCharVarchar')
            and    type = 'U')
   drop table TestCharVarchar
go

create table TestCharVarchar
(
   Id int not null,
   FChar char(32) null,
   FVarchar varchar(32) null
) lock datarows
go
