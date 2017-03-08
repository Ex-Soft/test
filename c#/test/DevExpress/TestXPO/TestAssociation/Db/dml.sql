/*
insert into TableLeft (Id, Val) values (1, N'Left (1)')
insert into TableLeft (Id, Val) values (2, N'Left (2)')
insert into TableLeft (Id, Val) values (3, N'Left (3)')
insert into TableLeft (Id, Val) values (4, N'Left (4)')
*/

/*
insert into TableRight (Id, Val) values (1, N'Right (1)')
insert into TableRight (Id, Val) values (2, N'Right (2)')
insert into TableRight (Id, Val) values (3, N'Right (3)')
insert into TableRight (Id, Val) values (4, N'Right (4)')
*/


/*
insert into AssociativeTable (LeftId, RightId) values (1, 1)
insert into AssociativeTable (LeftId, RightId) values (1, 2)
insert into AssociativeTable (LeftId, RightId) values (1, 3)
insert into AssociativeTable (LeftId, RightId) values (2, 4)
insert into AssociativeTable (LeftId, RightId) values (3, 4)
insert into AssociativeTable (LeftId, RightId) values (4, 4)

*/

/*
;with cte(Id, Val)
as
(
	select 10, N'Left (' + convert(nvarchar(256), 10) + ')'
	union all
	select Id + 1, N'Left (' + convert(nvarchar(256), Id) + ')'
	from cte
	where Id < 5000
)
insert into TableLeft (Id, Val)
select id, Val
from cte
option (maxrecursion 0);

;with cte(Id, Val)
as
(
	select 10, N'Right (' + convert(nvarchar(256), 10) + ')'
	union all
	select Id + 1, N'Right (' + convert(nvarchar(256), Id) + ')'
	from cte
	where Id < 5000
)
insert into TableRight (Id, Val)
select id, Val
from cte
option (maxrecursion 0);

;with cte(id)
as
(
	select 10
	union all
	select Id + 1
	from cte
	where Id < 5000
)
insert into AssociativeTable (LeftId, RightId)
select id, id
from cte
option (maxrecursion 0);

*/

select
	*
from
	TableLeft tableLeft
	left join AssociativeTable associativeTable on associativeTable.LeftId = tableLeft.Id
	left join TableRight tableRight on tableRight.Id = associativeTable.RightId

select
	*
from
	TableRight tableRight
	left join AssociativeTable associativeTable on associativeTable.RightId = tableRight.Id
	left join TableLeft tableLeft on tableLeft.Id = associativeTable.LeftId

------------------------------------------------------------

exec sp_executesql N'select N0."Id",N0."Val",N0."OptimisticLockField" from "dbo"."TableLeft" N0
where (N0."Id" = @p0)',N'@p0 int',@p0=1

exec sp_executesql N'select N0."Id",N0."LeftId",N0."RightId",N0."OptimisticLockField" from "dbo"."AssociativeTable" N0
where (N0."LeftId" = @p0)',N'@p0 int',@p0=1

exec sp_executesql N'select N0."Id",N0."Val",N0."OptimisticLockField" from "dbo"."TableRight" N0
where N0."Id" in (@p0,@p1,@p2)',N'@p0 int,@p1 int,@p2 int',@p0=1,@p1=2,@p2=3
------------------------------------------------------------

exec sp_executesql N'select N0."Id",N0."Val",N0."OptimisticLockField" from "dbo"."TableRight" N0
where (N0."Id" = @p0)',N'@p0 int',@p0=4

exec sp_executesql N'select N0."Id",N0."LeftId",N0."RightId",N0."OptimisticLockField" from "dbo"."AssociativeTable" N0
where (N0."RightId" = @p0)',N'@p0 int',@p0=4

exec sp_executesql N'select N0."Id",N0."Val",N0."OptimisticLockField" from "dbo"."TableLeft" N0
where N0."Id" in (@p0,@p1,@p2)',N'@p0 int,@p1 int,@p2 int',@p0=2,@p1=3,@p2=4
------------------------------------------------------------
