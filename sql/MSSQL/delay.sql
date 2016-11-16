declare
	@sleep char(8) = '00:00:02',
	@start time,
	@stop time

set @start = getdate()
waitfor delay @sleep
set @stop = getdate()

print @start
print @stop
