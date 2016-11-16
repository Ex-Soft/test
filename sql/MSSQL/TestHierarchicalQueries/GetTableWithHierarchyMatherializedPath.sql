use testdb
go

if object_id(N'GetTableWithHierarchyMaterializedPath', N'fn') is not null
  drop function GetTableWithHierarchyMaterializedPath
go

create function GetTableWithHierarchyMaterializedPath (@Id int)
returns nvarchar(256)
as
begin
  declare
    @result nvarchar(256);

  with RecursiveQuery (Id, ParentId, Path)
  as
  (
     select
       t.Id,
       t.ParentId,
       cast(N'/' + cast(t.Id as nvarchar(256)) as nvarchar(256)) as Path
     from
       TableWithHierarchy t
     where
       (t.Id=@Id)
     union all
     select
       t.Id,
       t.ParentId,
       cast(N'/' + cast(t.Id as nvarchar(256)) + Path as nvarchar(256))
     from
       TableWithHierarchy t
       join RecursiveQuery rq on (rq.ParentId=t.Id)
  )
  select
    @result = rq.Path
  from
    RecursiveQuery rq
  where
    rq.ParentId is null;

  return @result;
end
go