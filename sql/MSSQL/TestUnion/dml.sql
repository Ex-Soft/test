select
	null,
	null,
	FDate,
	FDateTime
from
	TestTable4Types
union
select
	Name,
	Salary,
	BirthDate,
	null
from
	Staff