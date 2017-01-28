use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_TestUpdateTmpTable')
            and    type = 'P')
   drop procedure sp_TestUpdateTmpTable
go

create procedure sp_TestUpdateTmpTable
as 
begin
  create table #TmpTable(
    Id int constraint NotNullTmpTableId not null constraint pkTmpTable primary key,
    A int null,
    B int null,
    C int null,
    D int not null)

  insert into #TmpTable (Id, A, B, C, D) values (1,    1, null, null, 1)
  insert into #TmpTable (Id, A, B, C, D) values (2, null,    2, null, 1)
  insert into #TmpTable (Id, A, B, C, D) values (3,    3, null, null, 0)
  insert into #TmpTable (Id, A, B, C, D) values (4, null,    4, null, 0)

  update
    #TmpTable
  set
    C=case
        when A is not null
        then A
        else B
      end
  where
    D=1

  declare
    @Id int,
    @A int,
    @B int,
    @C int,
    @D int

  declare TmpTableCursor cursor
  for
  select
    Id, A, B, C, D
  from
    #TmpTable
  where
    D=0
  for update

  open TmpTableCursor
  fetch TmpTableCursor into @Id, @A, @B, @C, @D
  while (@@sqlstatus=0)
    begin
      update
        #TmpTable
      set
        C=99
      where current of TmpTableCursor

      fetch TmpTableCursor into @Id, @A, @B, @C, @D
    end

  close TmpTableCursor
  deallocate cursor TmpTableCursor

  select
    *
  from
    #TmpTable
  order by Id

  drop table #TmpTable
end
go
