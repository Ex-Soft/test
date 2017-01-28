use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestCreateTableInSp')
            and    type = 'P')
   drop procedure TestCreateTableInSp
go

create procedure TestCreateTableInSp
as
begin
  if not exists (select 1
                 from
                 sysobjects
                 where
                   id=object_id('TableCreatedFromSP')
                   and type='U')
    create table TableCreatedFromSP(
      id tinyint not null
    ) lock datarows
end
go
