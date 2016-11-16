/*
https://msdn.microsoft.com/en-us/library/cc293616.aspx -- Troubleshooting and Analysis with Traces
http://blogs.msdn.com/b/pamitt/archive/2010/11/07/attention-events-causing-open-transaction-and-blocking.aspx -- Attention events can cause open transactions and blocking in SQL Server

https://msdn.microsoft.com/en-us/library/ms181509.aspx -- sys.dm_exec_connections
https://msdn.microsoft.com/en-us/library/ms176013.aspx -- sys.dm_exec_sessions
https://msdn.microsoft.com/en-us/library/ms177648.aspx -- sys.dm_exec_requests
https://msdn.microsoft.com/en-us/library/ms179881.aspx -- sys.sysprocesses
https://msdn.microsoft.com/en-us/library/ms190345.aspx -- sys.dm_tran_locks

http://www.sqlserver-dba.com/sql-server-profiler/
September 03, 2014
Error 3621 - The statement has been terminated
Question: A client is sending a query to a SQL Server . After 30 seconds a message appears on the SQL Server trace:
User error message : The statement has been terminated

*/

select
	*
from
	sys.dm_exec_connections [sysdm_exec_connections]
	left join sys.dm_exec_sessions [sysdm_exec_sessions] on [sysdm_exec_sessions].session_id = [sysdm_exec_connections].session_id
	left join sys.dm_exec_requests [sysdm_exec_requests] on [sysdm_exec_requests].connection_id = [sysdm_exec_connections].connection_id
	left join sys.sysprocesses [syssysprocesses] on [syssysprocesses].spid = [sysdm_exec_sessions].session_id

select
	[sysdmtranlocks].resource_type,
	[sysdmtranlocks].request_mode,
	[sysdmtranlocks].request_type,
	[sysdmtranlocks].resource_associated_entity_id,
	[sysdmtranlocks].request_status,
	[sysdmtranlocks].request_session_id,
	[sysobjects].name as ObjectName,
	[syspartitions].*,
	[sysindexes].*
from
	sys.dm_tran_locks [sysdmtranlocks]
	left join sys.objects [sysobjects] on [sysobjects].object_id = [sysdmtranlocks].resource_associated_entity_id
	left join sys.partitions [syspartitions] on [syspartitions].hobt_id = [sysdmtranlocks].resource_associated_entity_id
	left join sys.indexes [sysindexes] on [sysindexes].object_id = [syspartitions].object_id and [sysindexes].index_id = [syspartitions].index_id

select
	*
from
	sys.sysprocesses [syssysprocesses]
	cross apply sys.dm_exec_sql_text([syssysprocesses].sql_handle)
where
	--[syssysprocesses].status = N'running'
	[syssysprocesses].program_name like N'%Чикаго%'
	--and [syssysprocesses].blocked != 0

SELECT
		DB_NAME(b.dbid) as DatabaseName,
		OBJECT_NAME(slock.objectid,s.dbid) as ObjectName, 
		s.spid as Locking_SPID, 
		s.blocked as Locking_BlockSPID, 
		s.program_name as Locking_ProgramName, 
		s.loginame as Locking_LoginName, 
		CAST(slock.text AS VARCHAR(MAX)) as Locking_Statement,
		datediff(ss, s.last_batch, getdate()) as Locking_Time, 
		b.spid as Waiting_SPID,
		b.waittime / 1000 as Waiting_Time,
		CAST(block.text AS VARCHAR(MAX)) as Waiting_Statement,
		getdate() as Info_DateTime,
		b.program_name as Waiting_ProgramName, 
		b.loginame as Waiting_LoginName
		
	FROM sys.sysprocesses as b
	inner join sys.sysprocesses s on b.blocked = s.spid
	CROSS APPLY sys.dm_exec_sql_text (s.sql_handle) as slock
	cross apply sys.dm_exec_sql_text (b.sql_handle) as block
	WHERE b.spid >= 50 and b.blocked > 0 and b.waittime > 5000

select
	*
	--[sysdm_exec_connections].*
	--[sysdm_exec_sessions].*
from
	sys.dm_exec_connections [sysdm_exec_connections]
	left join sys.dm_exec_sessions [sysdm_exec_sessions] on [sysdm_exec_sessions].session_id = [sysdm_exec_connections].session_id
	left join sys.dm_exec_requests [sysdm_exec_requests] on [sysdm_exec_requests].connection_id = [sysdm_exec_connections].connection_id
	left join sys.sysprocesses [syssysprocesses] on [syssysprocesses].spid = [sysdm_exec_sessions].session_id
	cross apply sys.dm_exec_sql_text ([syssysprocesses].sql_handle)
order by [sysdm_exec_connections].connection_id
