create table tStatusP
(
   Id numeric(18,0) identity,
   StatusId int not null
) lock datarows with identity_gap=10
go

if exists (select
             1
           from
             sysobjects
           where
             (id=object_id('tr_U_tStatusP'))
             and (type='TR'))
   drop trigger tr_U_tStatusP
go

create trigger tr_U_tStatusP
on tStatusP
for update
as
begin
  if exists (select
               1
             from
               inserted inserted
               join deleted deleted on (deleted.Id=inserted.Id)
             where
               (inserted.StatusId!=deleted.StatusId)
            )
    begin
      print 'StatusId has been changed'

      update
        tStatusS
      set
        StatusId=case inserted.StatusId
                   when 10 then 1010
                   when 11 then 1111
                   when 12 then 1212
                   when 13 then 1313
                   when 14 then 1414
                   when 15 then 1515
                   when 16 then 1616
                   when 17 then 1717
                 end
      from
        tStatusS s
        join inserted inserted on (inserted.Id=s.Id)
        join deleted deleted on (deleted.Id=inserted.Id)
      where
        (inserted.StatusId!=deleted.StatusId)
        and (inserted.StatusId in (10, 11, 12, 13, 14, 15, 16, 17))
    end
end
go