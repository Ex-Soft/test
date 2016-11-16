select
	*
from
	dbo.TestMaster [master]
	left join dbo.TestDetail [detail] on [detail].IdMaster = [master].Id
order by [master].Id

-- update dbo.TestDetail set Val = N'' where id = 16
-- update dbo.TestDetail set Val = null where id = 16