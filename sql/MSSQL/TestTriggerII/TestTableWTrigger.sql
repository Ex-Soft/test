if object_id('TestTableWTrigger', 'U') is not null
  drop table TestTableWTrigger
go

create table TestTableWTrigger
(
   Id int identity,
   Val1 int,
   Val2 int,
   UsrName nvarchar(256),
   DtTm datetime
)
go

if object_id('tr_U_1_TestTableWTrigger', 'TR') is not null
  drop trigger tr_U_1_TestTableWTrigger
go

create trigger tr_U_1_TestTableWTrigger
on TestTableWTrigger
for update
as
begin

  set nocount on

  print db_name()
  print 'tr_U_1_TestTableWTrigger'

  if exists (select
               1
             from
               inserted inserted
               join deleted deleted on (deleted.Id=inserted.Id)
             where
               ((inserted.Val1 is null) and (deleted.Val1 is not null))
               or ((inserted.Val1 is not null) and (deleted.Val1 is null))
               or ((inserted.Val1 is not null) and (deleted.Val1 is not null) and (inserted.Val1!=deleted.Val1)))
    print 'Val1 has been changed!'
end
go

if object_id('tr_U_2_TestTableWTrigger', 'TR') is not null
  drop trigger tr_U_2_TestTableWTrigger
go

create trigger tr_U_2_TestTableWTrigger
on TestTableWTrigger
for update
as
begin

  set nocount on

  print db_name()
  print 'tr_U_2_TestTableWTrigger'

  if exists (select
               1
             from
               inserted inserted
               join deleted deleted on (deleted.Id=inserted.Id)
             where
               ((inserted.Val2 is null) and (deleted.Val2 is not null))
               or ((inserted.Val2 is not null) and (deleted.Val2 is null))
               or ((inserted.Val2 is not null) and (deleted.Val2 is not null) and (inserted.Val2!=deleted.Val2)))
    print 'Val2 has been changed!'
end
go

if object_id('tr_U_3_TestTableWTrigger', 'TR') is not null
  drop trigger tr_U_3_TestTableWTrigger
go

create trigger tr_U_3_TestTableWTrigger
on TestTableWTrigger
for update
as
begin

  set nocount on

  print db_name()
  print 'tr_U_3_TestTableWTrigger'

  update
    TestTableWTrigger
  set
    UsrName=user_name(),
    DtTm=getdate()
  from
    TestTableWTrigger t
    join inserted inserted on (inserted.Id=t.Id)

end
go