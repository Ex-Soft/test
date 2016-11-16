delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (2, 2)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (4, 4)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

update
  TestTable4IUDDest
set
  Val=10
from
  TestTable4IUDDest Dest,
  TestTable4IUDSrc Src
where
  Dest.Id=Src.Id

select
  *
from
  TestTable4IUDDest

/*
1	10
2	2
3	10
4	4
5	10
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (2, 2)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (4, 4)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

update
  TestTable4IUDDest
set
  Val=10
from
  TestTable4IUDDest Dest
  join TestTable4IUDSrc Src on (Src.Id=Dest.Id)

select
  *
from
  TestTable4IUDDest

/*
1	10
2	2
3	10
4	4
5	10
*/

------------------------------------------------------------

delete from TestTable4IUDSrc
delete from TestTable4IUDDest

insert into TestTable4IUDSrc (Id) values (1)
insert into TestTable4IUDSrc (Id) values (3)
insert into TestTable4IUDSrc (Id) values (5)

insert into TestTable4IUDDest (Id, Val) values (1, 1)
insert into TestTable4IUDDest (Id, Val) values (2, 2)
insert into TestTable4IUDDest (Id, Val) values (3, 3)
insert into TestTable4IUDDest (Id, Val) values (4, 4)
insert into TestTable4IUDDest (Id, Val) values (5, 5)

update
  TestTable4IUDDest
set
  Val=10
from
  TestTable4IUDDest Dest
  left join TestTable4IUDSrc Src on (Src.Id=Dest.Id)
where
  (Src.Id is null)

select
  *
from
  TestTable4IUDDest

/*
1	1
2	10
3	3
4	10
5	5
*/

------------------------------------------------------------

declare
	@t1 table (id int, val nvarchar(10))

declare
	@t2 table (id int, idT int)


insert into @t1 (id, val) values (1, N'1')
insert into @t1 (id, val) values (2, N'2')
insert into @t1 (id, val) values (3, N'3')
insert into @t1 (id, val) values (4, N'4')

insert into @t2 (id, idT) values (1, 1)
insert into @t2 (id, idT) values (3, 3)

select
	*
from
	@t2 t2
	join @t1 t1 on t1.id = t2.idT

;with cte(idSrc, idDest)
as
(
	select
		(select id from @t1 where val = N'1') as idSrc,
		(select id from @t1 where val = N'2') as idDest
	from
		master..sysdatabases
	where
		dbid = 1
	union
	select
		(select id from @t1 where val = N'3') as idSrc,
		(select id from @t1 where val = N'4') as idDest
	from
		master..sysdatabases
	where
		dbid = 1
)
update
	@t2
set
	idT = cte.idDest
from
	@t2 dest
	join cte cte on cte.idSrc = dest.idT

select
	*
from
	@t2 t2
	join @t1 t1 on t1.id = t2.idT

------------------------------------------------------------

declare @ids table (id bigint)
declare @dj table (id bigint, idBusinessStatus bigint)
declare @refDocBusinessStatuses table (id bigint, outercode nvarchar(50))

insert into @ids (id) values (1)
insert into @ids (id) values (3)

insert into @dj (id, idBusinessStatus) values (1, 3)
insert into @dj (id, idBusinessStatus) values (2, 2)
insert into @dj (id, idBusinessStatus) values (3, 3)

insert into @refDocBusinessStatuses (id, outercode) values (1, N'SentTo1CFacing')
insert into @refDocBusinessStatuses (id, outercode) values (2, N'ProcessedIn1CFacing')

;with cte(id)
as
(
	select id from @refDocBusinessStatuses where outercode = N'SentTo1CFacing_'
)
update
	@dj
set
	idBusinessStatus = cte.id
from
	@dj dest
	join @ids ids on ids.id = dest.id
	cross join cte

select * from @dj

------------------------------------------------------------

declare	@DocJournal table (id int, idMaster int, idBusinessStatus int)
declare	@ids table (id int)

insert into @DocJournal (id, idMaster, idBusinessStatus) values (1, 1, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (2, 1, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (3, 1, 1)

insert into @DocJournal (id, idMaster, idBusinessStatus) values (4, 4, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (5, 4, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (6, 4, 1)

insert into @DocJournal (id, idMaster, idBusinessStatus) values (7, 7, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (8, 7, 1)
insert into @DocJournal (id, idMaster, idBusinessStatus) values (9, 7, 1)

insert into @ids (id) values (1)
insert into @ids (id) values (8)

select
	*
from
	@DocJournal dj
	join @ids ids on ids.id = dj.id
	join @DocJournal djUp on djUp.idMaster = dj.idMaster and djUp.id >= ids.id

;with cte(id)
as
(
	select
		2
	from
		sys.databases
	where
		name = N'master'
)
update
	djUp
set
	idBusinessStatus = cte.id
from
	@DocJournal dj
	join @ids ids on ids.id = dj.id
	join @DocJournal djUp on djUp.idMaster = dj.idMaster and djUp.id >= ids.id
	cross join cte

select
	*
from
	@DocJournal dj
