use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('TableWIdentityMaster'))
             and (type='U'))
   drop table TableWIdentityMaster
go

create table TableWIdentityMaster
(
   Id numeric(18,0) identity,
   Value varchar(254)
) lock datarows with identity_gap=10
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('Trigger4TableWIdentityMaster'))
             and (type='TR'))
   drop trigger Trigger4TableWIdentityMaster
go

create trigger Trigger4TableWIdentityMaster
on TableWIdentityMaster
for insert
as
begin
  insert into TableWIdentityDetails (IdMaster, Value)
  select
    Id,
    Value
  from inserted  
end
go