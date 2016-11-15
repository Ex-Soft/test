use TestTargetFWVersion
go

declare
	@paramLeft nvarchar(255),
	@paramRight nvarchar(255) = N'paramRight',
	@resultStr nvarchar(255)

select @paramLeft = N'paramLeft2', @paramRight = N'paramRight2'
set @resultStr = N'''' + dbo.CLRFunction2(@paramLeft, @paramRight) + N''''
print @resultStr

select @paramLeft = N'paramLeft4', @paramRight = N'paramRight4'
set @resultStr = N'''' + dbo.CLRFunction4(@paramLeft, @paramRight) + N''''
print @resultStr

select @paramLeft = N'paramLeft2', @paramRight = N'paramRight2'
set @resultStr = N'''' + dbo.CLRFunction2(@paramLeft, @paramRight) + N''''
print @resultStr

select @paramLeft = N'paramLeft4', @paramRight = N'paramRight4'
set @resultStr = N'''' + dbo.CLRFunction4(@paramLeft, @paramRight) + N''''
print @resultStr

declare
	@inParam nvarchar(255),
	@outParam nvarchar(255),
	@resultInt int

set @inParam = N'inParam2'
exec @resultInt = CLRProcedureWithOutputParameters2 @inParam = @inParam, @outParam = @outParam out
set @resultStr = N'''' + @outParam + N''''
print @resultStr
print @resultInt

set @inParam = N'inParam4'
exec @resultInt = CLRProcedureWithOutputParameters4 @inParam = @inParam, @outParam = @outParam out
set @resultStr = N'''' + @outParam + N''''
print @resultStr
print @resultInt

set @inParam = N'inParam2'
exec @resultInt = CLRProcedureWithOutputParameters2 @inParam = @inParam, @outParam = @outParam out
set @resultStr = N'''' + @outParam + N''''
print @resultStr
print @resultInt

set @inParam = N'inParam4'
exec @resultInt = CLRProcedureWithOutputParameters4 @inParam = @inParam, @outParam = @outParam out
set @resultStr = N'''' + @outParam + N''''
print @resultStr
print @resultInt
