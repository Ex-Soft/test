use testdb
go

if exists (select 1
           from
             sysobjects
           where
             (id=object_id('sp_TestCursorInsert2'))
             and (type = 'P'))
   drop procedure sp_TestCursorInsert2
go

create procedure sp_TestCursorInsert2
as 
begin
  declare
    @Id numeric(18,0),
    @Val numeric(18,0),
    @i int,
    @tmpStr varchar(254)

  set @i=0

  declare TestCursorInsert cursor
  for
    select
      Id,
      Val
    from
      TestCursorMain
    where
      Cod=1
    for update of Val

  open TestCursorInsert
  fetch TestCursorInsert into @Id, @Val
  while (@@sqlstatus=0)
    begin
      set @tmpStr='@Id='||coalesce(convert(varchar(32),@Id),'NULL')||', @Val='||coalesce(convert(varchar(32),@Val),'NULL')
      print @tmpStr

      set @i=@i+1
      if @i>100
        begin
          print '>100'
          goto ClearAll
        end

      update
        TestCursorMain
      set
        Val=Val*2
      where
        current of TestCursorInsert

      insert into TestCursorMain (Id, Val, Cod) values (@Id*2, @Val*3, 3)

      fetch TestCursorInsert into @Id, @Val
    end

  ClearAll:
  close TestCursorInsert
  deallocate TestCursorInsert
end
go
