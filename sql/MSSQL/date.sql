declare
  @t_date date,
  @t_datetime datetime,
  @t_datetime2 datetime2,
  @t_smalldatetime smalldatetime,
  @t_datetimeoffset datetimeoffset,
  @t_datetimeoffset2 datetimeoffset,
  @t2_date date,
  @t3_date date,
  @t2_datetime datetime,
  @t3_datetime datetime

set @t_date = '20190101'
set @t2_date = '20190102'
--set @t3_date = @t2_date - @t_date -- !!! Operand data type date is invalid for subtract operator !!!
set @t3_date = cast(@t2_date as datetime) - cast(@t_date as datetime)
print convert(varchar, @t2_date, 120) + ' - ' + convert(varchar, @t_date, 120) + ' = ' + convert(varchar, @t3_date, 120)
set @t_date = '20190102'
set @t2_date = '20190101'
set @t3_date = cast(@t_date as datetime) - cast(@t2_date as datetime)
print convert(varchar, @t2_date, 120) + ' - ' + convert(varchar, @t_date, 120) + ' = ' + convert(varchar, @t3_date, 120)
set @t_date = '20190101'
set @t2_date = '20190101'
set @t3_date = cast(@t_date as datetime) - cast(@t2_date as datetime)
print convert(varchar, @t2_date, 120) + ' - ' + convert(varchar, @t_date, 120) + ' = ' + convert(varchar, @t3_date, 120)

set @t_datetime = getdate()
set @t2_datetime = getdate()
set @t3_datetime = @t2_datetime - @t_datetime
print convert(varchar, @t2_datetime, 120) + ' - ' + convert(varchar, @t_datetime, 120) + ' = ' + convert(varchar, @t3_datetime, 120)

set @t_date=getdate()
set @t_datetime=getdate()
set @t_datetime2=getdate()
set @t_smalldatetime=getdate()
set @t_datetimeoffset=getdate()

print convert(varchar, @t_datetime, 4) + ' ' + convert(varchar, @t_datetime, 108) + ' - ' + convert(varchar, @t_datetime, 108)

set @t_datetimeoffset = N'20170101 01:13:13.456 +01:00'
set @t_datetimeoffset2 = N'20170101 02:13:13.456 +02:00'
select @t_datetimeoffset, @t_datetimeoffset2
if @t_datetimeoffset = @t_datetimeoffset2
	print N'oB!'
else
	print N'Tampax'

set @t_datetimeoffset = N'20170326 02:13:13.456 +02:00'
set @t_datetimeoffset2 = N'20170326 01:13:13.456 +01:00'
select @t_datetimeoffset, @t_datetimeoffset2

if @t_datetimeoffset = @t_datetimeoffset2
	print N'oB!'
else
	print N'Tampax'

set @t_datetimeoffset2 = N'20170326 00:13:13.456 +00:00'
select @t_datetimeoffset, @t_datetimeoffset2

if @t_datetimeoffset = @t_datetimeoffset2
	print N'oB!'
else
	print N'Tampax'

select
  @t_date,
  @t_datetime,
  convert(int, @t_datetime),
  @t_datetime2,
  @t_datetimeoffset,
  @t_smalldatetime,
  convert(int, @t_smalldatetime)

declare
	@dt datetime,
	@tmpStr nvarchar(max)

set @dt=null
set @tmpStr=convert(nvarchar(10), @dt, 104)
if @tmpStr is not null
	print N''''+@tmpStr+N''''
else
	print N'NULL' -- NULL

set @dt=null
set @tmpStr=convert(nvarchar(10), @dt, 108)
if @tmpStr is not null
	print N''''+@tmpStr+N''''
else
	print N'NULL' -- NULL

set @dt=N'20130819 11:50:13.123'
set @tmpStr=convert(nvarchar(10), @dt, 104)
if @tmpStr is not null
	print N''''+@tmpStr+N'''' -- '19.08.2013'
else
	print N'NULL'

set @dt=N'20130819 11:50:13.123'
set @tmpStr=convert(nvarchar(10), @dt, 108)
if @tmpStr is not null
	print N''''+@tmpStr+N'''' -- '11:50:13'
else
	print N'NULL'

set @tmpStr=N'20130715 16:43:13.123'
if isdate(@tmpStr)=1
	print N'oB!' -- oB!
else
	print N'Tampax'
set @dt=cast(@tmpStr as datetime)
select @dt

set @tmpStr=N'11:50:13'
if isdate(@tmpStr)=1
	print N'oB!' -- oB!
else
	print N'Tampax'
set @dt=cast(@tmpStr as datetime)
select @dt

------------------------------------------------------------

-- http://stackoverflow.com/questions/133081/most-efficient-way-in-sql-server-to-get-date-from-datetime
declare
	@dtSrc datetime,
	@d1 datetime,
	@d2 datetime,
	@d3 datetime,
	@d4 datetime,
	@d5 datetime

set @dtSrc=getdate()
set @d1=cast(floor(cast(@dtSrc as float)) as datetime)
set @d2=cast(floor(cast(@dtSrc as real)) as datetime)
set @d3=cast(cast(@dtSrc as date) as datetime) -- @@version >= M$ SQL 2008 
set @d4=convert(datetime, convert(nvarchar(10), @dtSrc, 104), 104)
set @d5=dateadd(day, datediff(day, 0, @dtSrc), 0)

select @dtSrc, @d1, @d2, @d3, @d4, @d5

------------------------------------------------------------

declare
	@fakeDateFrom datetime,
	@fakeDateTo datetime,
	@currentDate datetime,
	@dateFrom datetime,
	@dateTo datetime

set @currentDate=getdate()
set @fakeDateFrom=cast(floor(cast(@currentDate as real)) as datetime)
set @fakeDateTo=dateadd(day, 1, @fakeDateFrom)

select @fakeDateFrom, @currentDate, @fakeDateTo

set @dateFrom=null
set @dateTo=null
if @currentDate between coalesce(@dateFrom, @fakeDateFrom) and coalesce(@dateTo, @fakeDateTo)
	print N'oB!'
else
	print N'Tampax'

set @dateFrom=null
set @dateTo=dateadd(yyyy, -1, @fakeDateTo)
if @currentDate between coalesce(@dateFrom, @fakeDateFrom) and coalesce(@dateTo, @fakeDateTo)
	print N'oB!'
else
	print N'Tampax'

set @dateFrom=dateadd(yyyy, 1, @fakeDateFrom)
set @dateTo=null
if @currentDate between coalesce(@dateFrom, @fakeDateFrom) and coalesce(@dateTo, @fakeDateTo)
	print N'oB!'
else
	print N'Tampax'

set @dateFrom=dateadd(yyyy, 1, @fakeDateTo)
set @dateTo=dateadd(yyyy, -1, @fakeDateFrom)
if @currentDate between coalesce(@dateFrom, @fakeDateFrom) and coalesce(@dateTo, @fakeDateTo)
	print N'oB!'
else
	print N'Tampax'

set @dateFrom=dateadd(yyyy, -1, @fakeDateFrom)
set @dateTo=dateadd(yyyy, 1, @fakeDateTo)
if @currentDate between coalesce(@dateFrom, @fakeDateFrom) and coalesce(@dateTo, @fakeDateTo)
	print N'oB!'
else
	print N'Tampax'

select dateadd(day, 41728, '19000101')
select dateadd(day, 41728, '18991231')

/* Time range 00:00:00 through 23:59:59.997
Accuracy Rounded to increments of .000, .003, or .007 seconds */
declare
	@dt1 datetime = N'20150514 23:59:59.993',
	@dt2 datetime = N'20150514 23:59:59.994',
	@dt3 datetime = N'20150514 23:59:59.995',
	@dt4 datetime = N'20150514 23:59:59.996',
	@dt5 datetime = N'20150514 23:59:59.997',
	@dt6 datetime = N'20150514 23:59:59.998',
	@dt7 datetime = N'20150514 23:59:59.999'

select @dt1 as [93], @dt2 as [94], @dt3 as [95], @dt4 as [96], @dt5 as [97], @dt6 as [98], @dt7 as [99]


declare @t table (FInt int, FDate date, FDateTime datetime)

insert into @t (FInt, FDate, FDateTime) values (1, N'20150513', N'20150513 23:59:59.997')
insert into @t (FInt, FDate, FDateTime) values (2, N'20150514', N'20150514 00:00:00.000')
insert into @t (FInt, FDate, FDateTime) values (3, N'20150514', N'20150514 13:13:13.013')
insert into @t (FInt, FDate, FDateTime) values (4, N'20150514', N'20150514 23:59:59.997')
insert into @t (FInt, FDate, FDateTime) values (5, N'20150515', N'20150515 00:00:00.000')
insert into @t (FInt, FDate, FDateTime) values (6, N'20150515', N'20150515 23:59:59.997')
insert into @t (FInt, FDate, FDateTime) values (7, N'20150516', N'20150516 00:00:00.000')

declare
	@dateFrom datetime = N'20150514',
	@dateTill datetime = N'20150515'

select * from @t

select * from @t where FDate between @dateFrom and @dateTill
select * from @t where FDateTime between @dateFrom and @dateTill
select * from @t where FDateTime >= @dateFrom and FDateTime <= @dateTill

declare
	@dtIn datetime = getdate(),
	@dtOut datetime

print @dtIn
print cast(@dtIn as time)

set @dtOut = cast(N'19000101' as datetime)
set @dtOut = @dtOut + cast(@dtIn as time)

print @dtOut

declare
	@dt datetime = null,
	@d date

set @d = cast(@dt as date) + cast(getdate() as time) -- Operand data type date is invalid for add operator.

select @d

------------------------------------------------------------

declare
	@start time(7),
	@finish time(7),
	@diff int

set @start = getdate()
set @finish = dateadd(microsecond, 13, @start)
set @diff = datediff(microsecond, @start, @finish)
print @diff

------------------------------------------------------------

print eomonth(getdate(), -1)
print eomonth(getdate())
print eomonth(getdate(), 1)
