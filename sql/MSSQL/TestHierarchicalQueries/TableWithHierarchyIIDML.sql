/*
update TableWithHierarchyII set ParentId = 4 where id = 3
update TableWithHierarchyII set ParentId = 5 where id = 4
update TableWithHierarchyII set ParentId = 3 where id = 5
*/

/*
update TableWithHierarchyII set ParentId = 2 where id = 3
update TableWithHierarchyII set ParentId = 3 where id = 4
update TableWithHierarchyII set ParentId = 4 where id = 5
*/

select
	*
from
	TableWithHierarchyII

/* down */
;with cteDown(Id, ParentId)
as
(
	select
		t.Id,
		t.ParentId
	from
		TableWithHierarchyII t
	where
		t.ParentId is null
		--t.ParentId = 4
	union all
	select
		t.Id,
		t.ParentId
	from
		cteDown cteDown
		join TableWithHierarchyII t on t.ParentId = cteDown.Id
)
select
	*
from
	cteDown
--option (maxrecursion 10)
