select * from TestTable4Types

select
	id,
	ltrim(fvarchar),
	rtrim(fvarchar),
	rtrim(ltrim(fvarchar)),
	ltrim(rtrim(fvarchar)),
	len(fvarchar),
	len(ltrim(fvarchar)),
	len(rtrim(fvarchar)),
	len(ltrim(rtrim(fvarchar))),
	len(rtrim(ltrim(fvarchar)))
from
	TestTable4Types
where
	len(rtrim(ltrim(fvarchar))) > 0

declare
	@fvarchar varchar(256)

exec TestProcedureWithOutputVarChar 3, @fvarchar output
select @fvarchar
