-- https://stackoverflow.com/questions/10949730/is-it-possible-to-for-sql-output-clause-to-return-a-column-not-being-inserted

declare @logInsert table
(
	id int null,
	f1 int null,
	f2 int null,
	f3 int null,
	f4 int null
)

declare @logMerge table
(
	idOld int null,
	f1Old int null,
	f2Old int null,
	f3Old int null,
	f4Old int null,
	ActionTaken nvarchar(10),
	idNew int null,
	f1New int null,
	f2New int null,
	f3New int null,
	f4New int null
)

select
	*
from
	TestTable4Output
where
	f4 = 18

insert into TestTable4Output
	(f1, f2, f3, f4)
output inserted.id, inserted.f1, inserted.f2, inserted.f3, inserted.f4 into @logInsert
select
	f1, f2, f3, 999 as f4
from
	TestTable4Output
where
	f4 = 18

select * from @logInsert

;merge into TestTable4Output as tgt
using
(
	select
		id, f1, f2, f3, 999 as f4
	from
		TestTable4Output
	where
		f4 = 18
) as src
on 1 = 0
when not matched
	then
		insert (f1, f2, f3, f4)
		values (src.f1, src.f2, src.f3, src.f4)
output src.id, src.f1, src.f2, src.f3, src.f4, $action, inserted.id, inserted.f1, inserted.f2, inserted.f3, inserted.f4 into @logMerge;

select * from @logMerge
