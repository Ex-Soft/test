use testdb
go

if object_id(N'TableWithHierarchy', N'u') is not null
	drop table TableWithHierarchy
go

create table TableWithHierarchy
(
	Id int not null constraint pk_TableWithHierarchy primary key,
	ParentId int constraint fk_TableWithHierarchy references TableWithHierarchy (Id),
	Val nvarchar(255),
	MaterializedPath nvarchar(256),
	Selected bit not null constraint df_TableWithHierarchy_Selected default 0
)
go

if not exists (select 1
		from
			syscolumns
		where
			id = object_id(N'TableWithHierarchy', N'u')
			and name = N'Selected')
  alter table TableWithHierarchy add Selected bit not null constraint df_TableWithHierarchy_Selected default 0
else
  print N'TableWithHierarchy.Selected already exists!!!'
go

if object_id(N'tr_TableWithHierarchy_IUD', N'tr') is not null
  drop trigger tr_TableWithHierarchy_IUD
go

create trigger tr_TableWithHierarchy_IUD
on TableWithHierarchy
for insert, update, delete  
as  
begin
  set nocount on

  declare
    @cntInserted int,
    @cntDeleted int,
    @tmpId int,
    @tmpStr nvarchar(255)

  declare CursorIns cursor for
  select
    Id
  from
    inserted
  for read only

  declare CursorDel cursor for
  select
    Id
  from
    deleted
  for read only

  select
    @cntInserted=count(*)
  from
    inserted
  set @tmpStr='inserted count(*)='+convert(nvarchar(255),@cntInserted)
  print @tmpStr

  select
    @cntDeleted=count(*)
  from
    deleted
  set @tmpStr='deleted count(*)='+convert(nvarchar(255),@cntDeleted)
  print @tmpStr

  if @cntInserted=0 and @cntDeleted!=0
    begin
      print 'Delete only'

      open CursorDel
      fetch from CursorDel into @tmpId
      while @@fetch_status=0
        begin
          delete from
            TableWithHierarchy
          where
            Id in (select Id from dbo.GetTableWithHierarchyChildren(@tmpId))

          fetch from CursorDel into @tmpId
        end
      close CursorDel
    end
  else
    begin
      print 'Insert or Update'

      open CursorIns
      fetch from CursorIns into @tmpId
      while @@fetch_status=0
        begin
          if @cntDeleted!=0
            begin
              print 'Update'

              if exists (select
                           inserted.Id,
                           deleted.Id
                         from
                           inserted inserted
                           join deleted deleted on deleted.Id=inserted.Id and (((deleted.ParentId is null) and (inserted.ParentId is not null)) or ((deleted.ParentId is not null) and (inserted.ParentId is null)) or (deleted.ParentId!=inserted.ParentId)))
                begin
                  print 'exists'

                  update
                    TableWithHierarchy
                  set
                    MaterializedPath=dbo.GetTableWithHierarchyMaterializedPath(Id)
                  where
                   Id in (select Id from dbo.GetTableWithHierarchyChildren(@tmpId) union select @tmpId)
                end
              else
                print '!exists'
            end
          else
            begin
              print 'Insert only'

              update
                TableWithHierarchy
              set
                MaterializedPath=dbo.GetTableWithHierarchyMaterializedPath(Id)
              where
                Id=@tmpId
            end

          fetch from CursorIns into @tmpId
        end
      close CursorIns
    end

  deallocate CursorIns
  deallocate CursorDel
end
go