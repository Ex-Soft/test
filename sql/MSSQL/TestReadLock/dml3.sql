declare
	@db_name nvarchar(30) = N'testdb',
	@checkSessionId int = 55

select
	*
from
	sys.dm_tran_locks l -- http://technet.microsoft.com/en-us/library/ms190345%28v=sql.110%29.aspx
	join sys.dm_exec_requests r on r.session_id = l.request_session_id -- http://technet.microsoft.com/en-us/library/ms177648%28v=sql.110%29.aspx
	join sys.sysprocesses p on p.spid = r.blocking_session_id -- http://technet.microsoft.com/en-us/library/aa260456%28v=sql.80%29.aspx
	outer apply sys.dm_exec_sql_text(p.sql_handle) sqltext -- http://msdn.microsoft.com/en-us/library/ms181929.aspx
where
	l.request_status = N'WAIT'
	and l.resource_database_id = db_id(@db_name)
	and l.request_session_id = @checkSessionId

--exec sp_who2
--exec sp_lock

/*
select * from sys.dm_tran_locks
select * from sys.dm_exec_connections
select * from sys.dm_exec_sessions
select * from sys.dm_exec_requests where session_id in (52, 55)

SELECT * FROM sys.dm_exec_requests where DB_NAME(database_id)=N'testdb' and blocking_session_id <>0

SELECT * FROM sys.dm_exec_requests outer apply sys.dm_exec_sql_text(sql_handle) where session_id IN (SELECT blocking_session_id FROM sys.dm_exec_requests WHERE DB_NAME(database_id)=N'testdb' and blocking_session_id <>0)

SELECT scheduler_id, current_tasks_count, runnable_tasks_count, work_queue_count, pending_disk_io_count
FROM sys.dm_os_schedulers
WHERE scheduler_id < 255

SELECT SUBSTRING(qt.TEXT, (qs.statement_start_offset/2)+1,
((CASE qs.statement_end_offset
WHEN -1 THEN DATALENGTH(qt.TEXT)
ELSE qs.statement_end_offset
END - qs.statement_start_offset)/2)+1),
qs.execution_count,
qs.total_logical_reads, qs.last_logical_reads,
qs.total_logical_writes, qs.last_logical_writes,
qs.total_worker_time,
qs.last_worker_time,
qs.total_elapsed_time/1000000 total_elapsed_time_in_S,
qs.last_elapsed_time/1000000 last_elapsed_time_in_S,
qs.last_execution_time,
qp.query_plan
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) qt
CROSS APPLY sys.dm_exec_query_plan(qs.plan_handle) qp
ORDER BY qs.total_worker_time DESC
*/