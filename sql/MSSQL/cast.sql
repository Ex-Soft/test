declare
	@tmpNVarChar255 nvarchar(255),
	@tmpBigInt bigint

set @tmpNVarChar255 = null
set @tmpBigInt = cast(@tmpNVarChar255 as bigint)

if @tmpBigInt is not null
	print N'is not null'
else
	print N'null'
