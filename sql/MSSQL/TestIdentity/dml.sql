declare @src table (id int identity primary key, f1 int null, f2 int null);
declare @tgt table (id int identity primary key, f1 int null, f2 int null);
declare @log table (oldId int, oldF1 int null, oldF2 int null, action nvarchar(256), [newId] int, newF1 int null, newF2 int null);
declare @loglog table (id int not null, f1 int null, f2 int null);

insert into @src (f1, f2)
output null, null, null, N'insert into @src', inserted.* into @log
values (0, 0);

insert into @src (f1, f2)
output null, null, null, N'insert into @src', inserted.* into @log
values (0, 1);

insert into @src (f1, f2)
output null, null, null, N'insert into @src', inserted.* into @log
values (1, 0);

insert into @src (f1, f2)
output null, null, null, N'insert into @src', inserted.* into @log
values (1, 1);

insert into @tgt (f1, f2)
output null, null, null, N'insert into @tgt', inserted.* into @log
values (0, 0);

insert into @tgt (f1, f2)
output null, null, null, N'insert into @tgt', inserted.* into @log
values (1, 1);

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
when not matched
	then
		insert (f1, f2)
		values (src.f1, src.f2)
output deleted.*, $action, inserted.* into @log;

--select * from @src;select * from @tgt;select * from @log;

update
	@tgt
set
	f1 = 0,
	f2 = 0
output deleted.*, N'update @tgt', inserted.* into @log
where
	f1 = 1 and f2 = 1;

--select * from @tgt;select * from @log;

delete from @tgt
output deleted.*, N'delete @tgt', null, null, null into @log
where
	(f1 = 1 and f2 = 0)
	or (f1 = 0 and f2 = 1);

--select * from @tgt;select * from @log;

delete from @tgt;

insert into @tgt (f1, f2)
--output inserted.f1, inserted.f2 into @loglog -- doesn't work https://docs.microsoft.com/en-us/sql/t-sql/queries/output-clause-transact-sql
output inserted.id, inserted.f1, inserted.f2 into @loglog
select f1, f2
from @src;

select * from @tgt;select * from @loglog;