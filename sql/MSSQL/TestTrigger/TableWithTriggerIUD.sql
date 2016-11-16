use testdb
go

if object_id(N'TableWithTriggerIUD', N'u') is not null
  drop table TableWithTriggerIUD
go

create table TableWithTriggerIUD
(
   Id numeric(18,0) identity,
   Value varchar(256) not null,
   RecordModify datetime not null   
)
go

if object_id(N'Trigger4TableWithTriggerIUD', N'tr') is not null
  drop trigger Trigger4TableWithTriggerIUD
go

create trigger Trigger4TableWithTriggerIUD
on TableWithTriggerIUD
for insert, update, delete  
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
    
  insert into TableWithTriggerIUDHistory 
  select 
    Id, 
    Value+' (from inserted)', 
    RecordModify 
  from inserted  
  
  insert into TableWithTriggerIUDHistory  
  select 
    Id, 
    Value+' (from deleted)', 
    RecordModify 
  from deleted

  declare CursorIns cursor for
  select
    Id,
    Value
  from
    inserted
  for read only
  
  open CursorIns
  fetch from CursorIns into @tmpId, @tmpValue
  while @@fetch_status=0
    begin

      if lower(@tmpValue)='hi'
        update
          TableWithTriggerIUD
        set
          Value='ПрЫвЭт'
        where
          Id=@tmpId

      fetch from CursorIns into @tmpId, @tmpValue
    end
  close CursorIns
  deallocate CursorIns
end
go