declare
	@Path nvarchar(max) = N'D:\temp\images\',
	@ImageFileName nvarchar(max) = N'delete.png'

exec(N'
	update
		TestTable4Types
	set
		FVarBinary_Max = (select pic.* from openrowset(bulk ''' + @Path + @ImageFileName + N''', single_blob) as pic)
	where
		id = 2
	'
)
