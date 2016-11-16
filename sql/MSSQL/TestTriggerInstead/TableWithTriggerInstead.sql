use testdb
go

if object_id(N'TableWithTriggerInstead', N'u') is not null
  drop table TableWithTriggerInstead
go

create table TableWithTriggerInstead
(
   Id numeric(18,0) identity,
   Value varchar(256) not null,
   RecordModify datetime not null   
)
go

if object_id(N'Trigger4TableWithTriggerInstead', N'tr') is not null
  drop trigger Trigger4TableWithTriggerInstead
go

create trigger Trigger4TableWithTriggerInstead
on TableWithTriggerInstead
instead of insert, update, delete  
as  
begin
  set nocount on

  declare
    @cnt int,
    @tmpStr varchar(255),
    @tmpId numeric(18,0),
    @tmpValue varchar(256)
    
  select
    @cnt=count(*)
  from
    inserted
  set @tmpStr='inserted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr

  select
    @cnt=count(*)
  from
    deleted
  set @tmpStr='deleted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr
  
  if exists (select
               inserted.Id,
               inserted.Value,
               deleted.Id,
               deleted.Value
             from
               inserted inserted
               join deleted deleted on deleted.Id=inserted.Id)
    print 'exists'
  else
    print '!exists'
    
  insert into TableWithTriggerInsteadHistory 
  select 
    Id, 
    Value+' (from inserted)', 
    RecordModify 
  from inserted  
  
  insert into TableWithTriggerInsteadHistory  
  select 
    Id, 
    Value+' (from deleted)', 
    RecordModify 
  from deleted

  insert into TableWithTriggerInstead
  select 
    Value, 
    RecordModify 
  from inserted  
end
go