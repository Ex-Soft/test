--select * from sys.traces

select
	*
from
	::fn_trace_gettable('C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Log\log_37.trc', default) [trace]
	join sys.trace_events [systraceevents] on [systraceevents].trace_event_id = [trace].EventClass
	join sys.trace_subclass_values [systracesubclassvalues] on [systracesubclassvalues].trace_event_id = [systraceevents].trace_event_id and [systracesubclassvalues].subclass_value = [trace].EventSubClass
where
	cast(StartTime as date) = N'20151203'
--StartTime between N'20151127 00:00:00' and N'20151127 23:59:59'
--and ApplicationName = N'ST - Чикаго'
--and DatabaseName = N'chicago_kraft'
order by StartTime