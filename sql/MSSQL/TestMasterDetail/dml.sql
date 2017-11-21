select
	*
from
	dbo.TestMaster [master]
	left join dbo.TestDetail [detail] on [detail].IdMaster = [master].Id
order by [master].Id, [detail].Val;

-- update dbo.TestDetail set IdMaster = 1 where id = 2;
-- update dbo.TestDetail set Val = N'' where id = 16;
-- update dbo.TestDetail set Val = null where id = 16;

;with cte
as
(
	select
		[master].Id,
		[master].Val as MasterVal,
		[detail].Val as DetailVal,
		row_number() over (partition by [master].Id order by [detail].Id) as rn
	from
		TestMaster [master]
		join TestDetail [detail] on [detail].IdMaster = [master].Id
)
select
	*
from
	cte
where
	rn = 1;

select
	[master].Id,
	[master].Val as MasterVal,
	[detail].Val as DetailVal
 from
	TestMaster [master]
	cross apply
	(
		select top 1
			Val
		from
			TestDetail [detail]
		where
			IdMaster = [master].Id
		order by Id
	) as [detail];
