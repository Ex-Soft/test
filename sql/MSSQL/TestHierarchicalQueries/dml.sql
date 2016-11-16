/* http://www.osp.ru/pcworld/2007/03/4199032/ */

select * from TableWithHierarchy

--update TableWithHierarchy set ParentId = 204 where id = 202
--update TableWithHierarchy set ParentId = 204 where id = 202 -- make cycle
--update TableWithHierarchy set ParentId = 201 where id = 202 -- repair

;with cteDown (Id, ParentId, Val, MaterializedPath, Level, Path)
as
(
	select
		t.Id,
		t.ParentId,
		t.Val,
		t.MaterializedPath,
		0 as Level,
		cast(N'/' + t.Val as varchar(max)) as Path
	from
		TableWithHierarchy t
	where
		--t.ParentId is null
		t.Id = 202
	union all
	select
		t.Id,
		t.ParentId,
		t.Val,
		t.MaterializedPath,
		Level + 1,
		cast(Path + N'/' + t.Val as varchar(max))
	from
		TableWithHierarchy t
		join cteDown recursiveQuery on recursiveQuery.id = t.ParentId
	where
		recursiveQuery.Level < 10
)
select
	cteDown.id,
	cteDown.ParentId,
	count(*)
from
	cteDown cteDown
group by cteDown.id, cteDown.ParentId
option (maxrecursion 10)

;with RecursiveQueryDown (Id, ParentId, Val, Level, Path)
as
(
	select
		t.Id,
		t.ParentId,
		t.Val,
		0 as Level,
		cast('/' + t.val as varchar(max)) as Path
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
		cast(Path + '/' + t.val as varchar(max))
	from
		TableWithHierarchy t
		join RecursiveQueryDown rqd on (rqd.Id=t.ParentId)
)
select
	rqd.Id,
	rqd.ParentId,
	rqd.Val,
	rqd.Level,
	rqd.Path
from
	RecursiveQueryDown rqd
where
	rqd.Level <= 3
order by rqd.Val
go


;with RecursiveQueryUp (Id, ParentId, Val, Level, Path)
as
(
	select
		t.Id,
		t.ParentId,
		t.Val,
		0 as Level,
		cast('/' + t.val as varchar(max)) as Path
	from
		TableWithHierarchy t
	where
		(t.Id=9)
	union all
	select
		t.Id,
		t.ParentId,
		t.Val,
		Level+1,
		cast('/' + t.val + Path as varchar(max))
	from
		TableWithHierarchy t
		join RecursiveQueryUp rqu on (rqu.ParentId=t.Id)
)
select
	rqu.Id,
	rqu.ParentId,
	rqu.Val,
	rqu.Level,
	rqu.Path
from
	RecursiveQueryUp rqu
order by rqu.Val
go

;with RecursiveQueryForChildren (Id, ParentId, Val, Level, Path)
as
(
	select
		t.Id,
		t.ParentId,
		t.Val,
		0 as Level,
		cast('/' + t.val as varchar(max)) as Path
	from
		TableWithHierarchy t
	where
		(t.Id in (9, 10))
	union all
	select
		t.Id,
		t.ParentId,
		t.Val,
		Level+1,
		cast(Path + '/' + t.val as varchar(max))
	from
		TableWithHierarchy t
		join RecursiveQueryForChildren rq4c on (rq4c.Id=t.ParentId)
),
RecursiveQueryForParent (Id, ParentId, Val, Level, Path)
as
(
	select
		t.Id,
		t.ParentId,
		t.Val,
		0 as Level,
		cast('/' + t.val as varchar(max)) as Path
	from
		TableWithHierarchy t
	where
		(t.Id in (9,10))
	union all
	select
		t.Id,
		t.ParentId,
		t.Val,
		Level+1,
		cast('/' + t.val + Path as varchar(max))
	from
		TableWithHierarchy t
		join RecursiveQueryForParent rq4p on (rq4p.ParentId=t.Id)
)
select
	rq4p.Id,
	rq4p.ParentId,
	rq4p.Val,
	rq4p.Level,
	rq4p.Path
from
	RecursiveQueryForParent rq4p
union
select
	rq4c.Id,
	rq4c.ParentId,
	rq4c.Val,
	rq4c.Level,
	rq4c.Path
from
	RecursiveQueryForChildren rq4c
order by 3
go
