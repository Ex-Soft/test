set names utf8;

connect "C:\Program Files\Firebird\Firebird_2_5\TESTDB.FDB" user "sysdba" password "masterkey";

set term ^;

create procedure GetTableWithHierarchyMPath (Id integer)
returns (result varchar(256) character set utf8)
as
begin
  with recursive RecursiveQuery (Id, ParentId, Path)
  as
  (
     select
       t.Id,
       t.ParentId,
       cast('/' || cast(t.Id as varchar(256) character set utf8) as varchar(256) character set utf8) as Path
     from
       TableWithHierarchy t
     where
       (t.Id=:Id)
     union all
     select
       t.Id,
       t.ParentId,
       cast('/' || cast(t.Id as varchar(256) character set utf8) || Path as varchar(256) character set utf8)
     from
       TableWithHierarchy t
       join RecursiveQuery rq on (rq.ParentId=t.Id)
  )
  select
    rq.Path
  from
    RecursiveQuery rq
  where
    rq.ParentId is null
  into
    :result;
end^

set term ;^