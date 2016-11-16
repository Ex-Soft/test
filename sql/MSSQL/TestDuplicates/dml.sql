select * from TestDuplicates;

select
  F1,
  F2,
  F3
from
  TestDuplicates
group by
  F1,
  F2,
  F3
having
  count(*)>1;

;with cte
as
(
select
  row_number() over (partition by F1, F2, F3 order by id) as rn
from
  TestDuplicates
)
delete from cte
where
  rn>1;

select * from TestDuplicates;

declare
	@t table (f1 int)

insert into @t (f1) values (1)
--insert into @t (f1) values (1)
--insert into @t (f1) values (1)
insert into @t (f1) values (2)

if exists(
select
	count(*)
from
	@t
group by f1
having count(*)=1
)
print N'Tampax'
else
print N'oB!'

------------------------------------------------------------

declare
	@errMsg nvarchar(max)

set @errMsg=null

select
	@errMsg=stuff(
	(
		select
			N';'+ltrim(rtrim(str(f1)))
		from
			TestDuplicates
		group by f1
		having count(*)>1
		for xml path(N'')
	), 1, 1, N'')

print coalesce(@errMsg, N'NULL')