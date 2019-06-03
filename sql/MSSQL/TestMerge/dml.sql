-- http://msdn.microsoft.com/en-us/library/bb510625.aspx

declare	@t1 table (id int, f1 nvarchar(255), f2 nvarchar(255))
declare	@t2 table (id int, f1 nvarchar(255), f2 nvarchar(255))
declare @log table (UpdatedId int, OldF1 nvarchar(255), OldF2 nvarchar(255), ActionTaken nvarchar(10), InsertedId int, NewF1 nvarchar(255), NewF2 nvarchar(255))

insert into @t1 (id, f1, f2) values (1, N'f1', N'f2')
insert into @t1 (id, f1, f2) values (2, N'f1 from @t1', N'f2')
insert into @t1 (id, f1, f2) values (3, N'f1', N'f2 from @t1')
insert into @t1 (id, f1, f2) values (4, N'f1 from @t1', N'f2 from @t1')

insert into @t2 (id, f1, f2) values (1, N'f1', N'f2')
insert into @t2 (id, f1, f2) values (2, N'f1 from @t2', N'f2')
insert into @t2 (id, f1, f2) values (3, N'f1', N'f2 from @t2')
insert into @t2 (id, f1, f2) values (4, N'f1 from @t2', N'f2 from @t2')
insert into @t2 (id, f1, f2) values (5, N'f1 (5) from @t2', N'f2 (5) from @t2')

select * from @t1
select * from @t2

;merge into @t1 as tgt
using
(
	select
		id,
		f1,
		f2
	from
		@t2
) as src
on tgt.id = src.id
when matched and
(
	tgt.f1 != src.f1
	or tgt.f2 != src.f2
)
then
	update
	set
		f1 = src.f1,
		f2 = src.f2
when not matched
then
	insert (id, f1, f2)
	values (src.id, src.f1, src.f2)
output deleted.id, deleted.f1, deleted.f2, $action, inserted.id, inserted.f1, inserted.f2 into @log;

select * from @t1
select * from @log

------------------------------------------------------------

declare
	@idBuyPointMain int = 1,
	@idPosition int = 1

declare @buyPoints table (id int, idMain int)
declare @buyPointPositions table (id int identity, idBuyPoint int, idPosition int, deleted bit)
declare @log table (UpdatedId int, OldIdBuypoint int, OldIdPosition int, OldDeleted bit, ActionTaken nvarchar(10), InsertedId int, NewIdBuyPoint int, NewIdPosition int, NewDeleted bit)

insert into @buyPoints (id, idMain) values (1, 1)
insert into @buyPoints (id, idMain) values (2, 1)
insert into @buyPoints (id, idMain) values (3, 1)
insert into @buyPoints (id, idMain) values (4, 2)
insert into @buyPoints (id, idMain) values (5, 2)
insert into @buyPoints (id, idMain) values (1, 3)

insert into @buyPointPositions (idBuyPoint, idPosition, deleted) values (1, @idPosition, 0)
insert into @buyPointPositions (idBuyPoint, idPosition, deleted) values (1, @idPosition, 0)
insert into @buyPointPositions (idBuyPoint, idPosition, deleted) values (2, @idPosition, 1)
insert into @buyPointPositions (idBuyPoint, idPosition, deleted) values (2, @idPosition, 1)

select * from @buyPointPositions

;merge into @buyPointPositions as tgt
using
(
	select
		buyPoints.id,
		max(buyPointPositions.id) as idBuyPointPosition
	from
		@buyPoints buyPoints
		left join @buyPointPositions buyPointPositions on buyPointPositions.idBuyPoint = buyPoints.id and buyPointPositions.idPosition = @idPosition and deleted = 1
	where
		idMain = @idBuyPointMain
	group by buyPoints.id
) as src
on (tgt.idBuyPoint = src.id) and (tgt.idPosition = @idPosition)
when matched and (tgt.id = src.idBuyPointPosition)
	then update set deleted = 0
when not matched
	then insert (idBuyPoint, idPosition, deleted) values (src.id, @idPosition, 0)
output deleted.id, deleted.idBuyPoint, deleted.idPosition, deleted.deleted, $action, inserted.id, inserted.idBuyPoint, inserted.idPosition, inserted.deleted into @log;

--select * from @buyPoints
select * from @buyPointPositions
select * from @log

------------------------------------------------------------

declare @DocumentType table (DocumentTypeId int, DocumentTypeName varchar(100))
declare @JobStatus table (JobStatusId int, JobStatusName varchar(50))
declare @State table (StateId int)
declare @DocumentConfiguration table (DocumentConfigurationId int identity not null, DocumentTypeId int, JobStatusId int, StateId int)

insert into @DocumentType (DocumentTypeId, DocumentTypeName) values (97, 'Proof of Occupancy')
insert into @JobStatus (JobStatusId, JobStatusName) values (6, 'Solar Agreement Acceptance')

;with cte(id)
as
(
	select 1
	union all
	select id + 1
	from cte
	where id < 5
)
insert into @State (StateId)
select id
from cte
option (maxrecursion 0)

insert into @DocumentConfiguration (DocumentTypeId, JobStatusId, StateId) VALUES (97, 6, 2)
insert into @DocumentConfiguration (DocumentTypeId, JobStatusId, StateId) VALUES (97, 6, 4)

--select * from @DocumentType
--select * from @JobStatus
--select * from @State
select * from @DocumentConfiguration

;with cte(DocumentTypeId, JobStatusId)
as
(
	select
		DocumentTypeId,
		(select JobStatusId from JobStatus where JobStatusName = 'Solar Agreement Acceptance')
	from
		DocumentType
	where
		DocumentTypeName = 'Proof of Occupancy'
)
merge into @DocumentConfiguration as tgt
using
(
	select
		cte.DocumentTypeId,
		cte.JobStatusId,
		[state].StateId
	from
		cte cte
		cross join @State [state]
) as src
on tgt.DocumentTypeId = src.DocumentTypeId and tgt.JobStatusId = src.JobStatusId and tgt.StateId = src.StateId
when not matched
	then insert (DocumentTypeId,JobStatusId,StateId) values (src.DocumentTypeId, src.JobStatusId, src.StateId);

select * from @DocumentConfiguration

------------------------------------------------------------

declare @src table (id int identity primary key, f1 int null, f2 int null);
declare @tgt table (id int identity primary key, f1 int null, f2 int null);
declare @log table (oldId int, oldF1 int null, oldF2 int null, action nvarchar(256), [newId] int, newF1 int null, newF2 int null);

insert into @src
(f1, f2)
select f1, f2
from
(
	values
		(0, 0),
		(0, 1),
		(1, 0),
		(1, 1)
) tmp (f1, f2);

insert into @tgt
(f1, f2)
select f1, f2
from
(
	values
		(0, 0),
		(1, 1),
		(2, 2)
) tmp (f1, f2);

--select * from @src;select * from @tgt;select * from @log;

;merge into @tgt as tgt
using
(
	select
		f1,
		f2
	from
		@src
) as src
on tgt.f1 = src.f1 and tgt.f2 = src.f2
when matched
	then
		delete
when not matched by target
	then
		insert (f1, f2)
		values (src.f1, src.f2)
when not matched by source
	then
		delete
output deleted.*, $action, inserted.* into @log;

select * from @src;select * from @tgt;select * from @log;

;merge into @tgt as tgt
using
(
	values
		(0, 0),
		(0, 1),
		(1, 0),
		(1, 1)
) as src (f1, f2)
on tgt.f1 = src.f1 and tgt.f2 = src.f2
when matched
	then
		delete
when not matched by target
	then
		insert (f1, f2)
		values (src.f1, src.f2)
when not matched by source
	then
		delete
output deleted.*, $action, inserted.* into @log;

select * from @src;select * from @tgt;select * from @log;

------------------------------------------------------------

declare @src table (id int identity primary key, f1 int null, f2 int null, f3 int null, f4 int null, f5 int null);
declare @tgt table (id int identity primary key, f1 int null, f2 int null, f3 int null, f4 int null, f5 int null);
declare @log table (oldId int, oldF1 int null, oldF2 int null, oldF3 int null, oldF4 int null, oldF5 int null, action nvarchar(256), [newId] int, newF1 int null, newF2 int null, newF3 int null, newF4 int null, newF5 int null);

insert into @src
(f1, f2, f3, f4, f5)
select f1, f2, f3, f4, f5
from
(
	values
		(0, 0, 0, 0, 0)
) tmp (f1, f2, f3, f4, f5);

insert into @tgt
(f1, f2, f3, f4, f5)
select f1, f2, f3, f4, f5
from
(
	values
		(0, 0, 0, 0, 0)
) tmp (f1, f2, f3, f4, f5);

;merge into @tgt as tgt
using
(
	select
		f1,	f2, f3, f4, f5
	from
		@src
) as src
on tgt.f1 = src.f1 and tgt.f2 = src.f2
when matched
	then
		delete
when not matched by target
	then
		insert (f1, f2, f3, f4, f5)
		values (src.f1, src.f2, src.f3, src.f4, src.f5)
when not matched by source
	then
		delete
output deleted.*, $action, inserted.* into @log;
