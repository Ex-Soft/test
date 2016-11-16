set names utf8;

connect "C:\Program Files\Firebird\Firebird_2_5\TESTDB.FDB" user "sysdba" password "masterkey";

set term ^;

create procedure GetTableWithHierarchyChildren (InputParentId int)
returns (Id int)
as
begin
  for
  with recursive RecursiveQuery (Id, ParentId)
  as
  (
     select
       t.Id,
       t.ParentId
     from
       TableWithHierarchy t
     where
       (t.Id=:InputParentId)
     union all
     select
       t.Id,
       t.ParentId
     from
       TableWithHierarchy t
       join RecursiveQuery rq on (rq.Id=t.ParentId)
  )
  select
    rq.Id
  from
    RecursiveQuery rq
  where
    rq.Id <> :InputParentId
  into
    :Id
  do
  begin
    suspend;
  end

end^

set term ;^