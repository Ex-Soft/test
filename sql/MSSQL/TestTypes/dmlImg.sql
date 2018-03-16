declare
	@Path nvarchar(max) = N'D:\temp\images\',
	@ImageFileName nvarchar(max) = N'delete.png';

exec(N'
	update
		TestTable4Types
	set
		FVarBinary_Max = (select pic.* from openrowset(bulk ''' + @Path + @ImageFileName + N''', single_blob) as pic)
	where
		id = 2
	'
);

select cast(0 as varbinary(max));
select datalength(cast(0 as varbinary(max)));

select
	datalength(FVarBinary_28) as [datalength(FVarBinary_28)],
	datalength(FVarBinary_Max) as [datalength(FVarBinary_Max)],
	*
from
	TestTable4Types;
