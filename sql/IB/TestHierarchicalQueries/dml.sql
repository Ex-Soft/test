/* http://www.osp.ru/pcworld/2007/03/4199032/ */
with recursive RecursiveQuery (Id, ParentId, Val, Level, Path)
as
(
   select
     t.Id,
     t.ParentId,
     t.Val,
     0 as Level,
     cast('/' || t.val as varchar(256) character set utf8) as Path
   from
     TableWithHierarchy t
   where
     (t.ParentId is null)
   union all
   select
     t.Id,
     t.ParentId,
     t.Val,
     Level+1,
     cast(Path || '/' || t.val as varchar(256) character set utf8)
   from
     TableWithHierarchy t
     join RecursiveQuery rq on (rq.Id=t.ParentId)
)
select
  rq.Id,
  rq.ParentId,
  rq.Val,
  rq.Level,
  rq.Path
from
  RecursiveQuery rq
order by rq.Val;

with recursive RecursiveQuery (Id, ParentId, Val, Level, Path)
as
(
   select
     t.Id,
     t.ParentId,
     t.Val,
     0 as Level,
     cast('/' || t.val as varchar(256) character set utf8) as Path
   from
     TableWithHierarchy t
   where
     (t.ParentId is null)
   union all
   select
     t.Id,
     t.ParentId,
     t.Val,
     Level+1,
     cast(Path || '/' || t.val as varchar(256) character set utf8)
   from
     TableWithHierarchy t
     join RecursiveQuery rq on (rq.Id=t.ParentId)
)
select
  rq.Id,
  rq.ParentId,
  rq.Val,
  rq.Level,
  rq.Path
from
  RecursiveQuery rq
order by rq.ParentId;

with recursive RecursiveQuery (Id, ParentId, Val, Level, Path)
as
(
   select
     t.Id,
     t.ParentId,
     t.Val,
     0 as Level,
     cast('/' || t.val as varchar(256) character set utf8) as Path
   from
     TableWithHierarchy t
   where
     (t.Id=12)
   union all
   select
     t.Id,
     t.ParentId,
     t.Val,
     Level+1,
     cast('/' || t.val || Path as varchar(256) character set utf8)
   from
     TableWithHierarchy t
     join RecursiveQuery rq on (rq.ParentId=t.Id)
)
select
  rq.Id,
  rq.ParentId,
  rq.Val,
  rq.Level,
  rq.Path
from
  RecursiveQuery rq
order by rq.Val;
