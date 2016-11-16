use testdb
go

if object_id(N'GetTableWithHierarchyChildren', N'tf') is not null
  drop function GetTableWithHierarchyChildren
go

create function GetTableWithHierarchyChildren (@Id int)
returns @t table(Id int)
as
begin
  with RecursiveQuery (Id, ParentId)
  as
  (
     select
       t.Id,
       t.ParentId
     from
       TableWithHierarchy t
     where
       (t.Id=@Id)
     union all
     select
       t.Id,
       t.ParentId
     from
       TableWithHierarchy t
       join RecursiveQuery rq on (rq.Id=t.ParentId)
  )
  insert into @t
  select
    rq.Id
  from
    RecursiveQuery rq
  where
    rq.Id != @Id;

  return;
end
go