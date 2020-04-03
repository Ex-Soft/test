declare @t table (id int, f1 int, f2 nchar(1), f3 nvarchar(1024))

insert into @t
	(id, f1, f2, f3)
select
	id,
	f1,
	f2,
	f3
from
(
	values
		(1, 1, N'1', N'blah-blah-blah1 [blah-blah-blah1](blah-blah-blah1) blah-blah-blah1'),
		(2, 2, N'2', N'blah-blah-blah2 [blah-blah-blah2](blah-blah-blah2) blah-blah-blah2'),
		(3, 3, N'3', N'blah-blah-blah3 [blah-blah-blah3](blah-blah-blah3) blah-blah-blah3'),
		(4, 4, N'4', N'blah-blah-blah4 [blah-blah-blah4](blah-blah-blah4) blah-blah-blah4')
) tmpTbl(id, f1, f2, f3)

select
	id,
	f1,
	'''' + f2 + '''' as f2,
	case f2
		when N'1' then N'1st'
		when N'2' then N'2nd'
		when N'3' then N'3rd'
		else f2 + N'th'
	end as f2Ordinal
from
	@t

select
	id,
	f1,
	'''' + f2 + '''' as f2,
	case
		when f1 = 1 and f2 = N'1' then N'1st'
		when f1 = 2 and f2 = N'2' then N'2nd'
		when f1 = 3 and f2 = N'3' then N'3rd'
		else f2 + N'th'
	end as f2Ordinal
from
	@t

;with cte (id, f3)
as
(
	select
		id,
		replace(f3, v.currentValue, '(halb-halb-halb)') as f3
	from
		@t t
		join
		(
			values
				(N'(blah-blah-blah2)'),
				(N'(blah-blah-blah4)')
		) v (currentValue) on t.f3 like N'%' + v.currentValue + N'%'
)
update
	@t
set
	f3 = cte.f3
from
	@t t
	join cte cte on cte.id = t.id

select * from @t