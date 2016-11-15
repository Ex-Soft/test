
create procedure TestProcedureWImplicitDataTypeConversions
	@pBit bit,
	@pBitWDefault bit=0,
	@pBigint bigint,
	@pBigintWDefault bigint=0
as
begin
	set nocount on

	declare
		@tmpStr nvarchar(max)

	if @pBit is null
		set @tmpStr=N'@pBit is null'
	else
		set @tmpStr=N'@pBit is not null'
	print @tmpStr

	if @pBit is not null
		print @pBit

	print @pBitWDefault

	if @pBigint is null
		set @tmpStr=N'@pBigint is null'
	else
		set @tmpStr=N'@pBigint is not null'
	print @tmpStr

	if @pBigint is not null
		print @pBigint

	print @pBigintWDefault

	return(0)
end
