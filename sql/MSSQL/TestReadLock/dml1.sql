/* http://aboutsqlserver.com/2011/05/12/locking-in-microsoft-sql-server-part-3-blocking-in-the-system/ */
/* http://www.sqlteam.com/article/introduction-to-locking-in-sql-server */
/* http://www.oszone.net/14860/SQL-Server-2008-R2 */
/* http://www.sql.ru/articles/mssql/2004/04110303advancedlocking.shtml */
/* http://www.sql.ru/articles/mssql/03013101indexes.shtml */
set transaction isolation level read committed
begin tran

update
	TestTable4ReadLock
set
	Value = 0
where
	ID = 40000

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

select * from sys.dm_os_waiting_tasks where session_id = 53

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

	SELECT
		getdate() as Info_DateTime,
		DB_NAME(b.dbid) as DatabaseName,
		b.spid as Waiting_SPID,
		s.spid as Locking_SPID, 
		s.blocked as Locking_BlockSPID, 
		b.waittime / 1000 as Waiting_Time,
		datediff(ss, s.last_batch, getdate()) as Locking_Time, 
		b.lastwaittype as Waiting_LastWaitType,
		OBJECT_NAME(l.rsc_objid, l.rsc_dbid) as Waiting_ForObject,
		CAST(slock.text AS VARCHAR(MAX)) as Locking_Statement,
		CAST(block.text AS VARCHAR(MAX)) as Waiting_Statement,
		case req_mode 
			when 0 then ''
			when 1 then 'Sch-S'
			when 2 then 'Sch-M'
			when 3 then 'S'
			when 4 then 'U'
			when 5 then 'X'
			when 6 then 'IS'
			when 7 then 'IU'
			when 8 then 'IX'
			when 9 then 'SIU'
			when 10 then 'SIX'
			when 11 then 'UIX'
			when 12 then 'BU'
			when 13 then 'RangeS_S'
			when 14 then 'RangeS_U'
			when 15 then 'RangeI_N'
			when 16 then 'RangeI_S'
			when 17 then 'RangeI_U'
			when 18 then 'RangeI_X'
			when 19 then 'RangeX_S'
			when 20 then 'RangeX_U'
			when 21 then 'RangeX_X'
		end as Waiting_WaitType,
		req_transactionid as Waiting_TransactionID,
		b.program_name as Waiting_ProgramName, 
		b.loginame as Waiting_LoginName,
		s.program_name as Locking_ProgramName, 
		s.loginame as Locking_LoginName
		,SUBSTRING (block.text, (cn_b.statement_start_offset/2) + 1
		 , ((CASE WHEN cn_b.statement_end_offset = -1 
			 THEN LEN(CONVERT(NVARCHAR(MAX), slock.text)) * 2 
			   ELSE cn_b.statement_end_offset
			 END - cn_b.statement_start_offset)/2) + 1) AS [Waiting Query]
		,SUBSTRING (slock.text, (cn_s.statement_start_offset/2) + 1
		 , ((CASE WHEN cn_s.statement_end_offset = -1 
			 THEN LEN(CONVERT(NVARCHAR(MAX), slock.text)) * 2 
			   ELSE cn_s.statement_end_offset
			 END - cn_s.statement_start_offset)/2) + 1) AS [Locking Query]
	--	, cn_b_pl.query_plan as query_plan_Waiting
	--	, cn_s_pl.query_plan as query_plan_Blocking
	FROM sys.sysprocesses as b
	inner join sys.sysprocesses s on b.blocked = s.spid
	left join sys.dm_exec_requests as cn_b on cn_b.session_id = b.spid
	left join sys.dm_exec_requests as cn_s on cn_s.session_id = s.spid
	outer APPLY sys.dm_exec_sql_text (s.sql_handle) as slock
	outer apply sys.dm_exec_sql_text (b.sql_handle) as block
--	outer apply sys.dm_exec_query_plan(cn_b.plan_handle) as cn_b_pl
	--outer apply sys.dm_exec_query_plan(cn_s.plan_handle) as cn_s_pl
	inner join sys.syslockinfo as l on b.spid = l.req_spid
	WHERE b.spid >= 50 and b.blocked > 0 and b.waittime > 30000
		and l.req_status = 3

SELECT
		getdate() as Info_DateTime,
		DB_NAME(b.dbid) as DatabaseName,
		b.spid as Waiting_SPID,
		s.spid as Locking_SPID, 
		s.blocked as Locking_BlockSPID, 
		b.waittime / 1000 as Waiting_Time,
		datediff(ss, s.last_batch, getdate()) as Locking_Time, 
		b.lastwaittype as Waiting_LastWaitType,
		CAST(slock.text AS VARCHAR(MAX)) as Locking_Statement,
		CAST(block.text AS VARCHAR(MAX)) as Waiting_Statement,
		OBJECT_NAME(l.rsc_objid, l.rsc_dbid) as Waiting_ForObject,
		case l.req_mode 
			when 0 then ''
			when 1 then 'Sch-S'
			when 2 then 'Sch-M'
			when 3 then 'S'
			when 4 then 'U'
			when 5 then 'X'
			when 6 then 'IS'
			when 7 then 'IU'
			when 8 then 'IX'
			when 9 then 'SIU'
			when 10 then 'SIX'
			when 11 then 'UIX'
			when 12 then 'BU'
			when 13 then 'RangeS_S'
			when 14 then 'RangeS_U'
			when 15 then 'RangeI_N'
			when 16 then 'RangeI_S'
			when 17 then 'RangeI_U'
			when 18 then 'RangeI_X'
			when 19 then 'RangeX_S'
			when 20 then 'RangeX_U'
			when 21 then 'RangeX_X'
		end as Waiting_WaitType,
		case l_lock.rsc_type 
			when 1 then ''
			when 2 then 'Database'
			when 3 then 'File'
			when 4 then 'Index'
			when 5 then 'Table'
			when 6 then 'Page'
			when 7 then 'Key'
			when 8 then 'Extent'
			when 9 then 'Row ID'
			when 10 then 'Application'
		end as Waiting_ResType,
		OBJECT_NAME(l_lock.rsc_objid, l_lock.rsc_dbid) as Locking_HaveObject,
		case l_lock.req_mode 
			when 0 then ''
			when 1 then 'Sch-S'
			when 2 then 'Sch-M'
			when 3 then 'S'
			when 4 then 'U'
			when 5 then 'X'
			when 6 then 'IS'
			when 7 then 'IU'
			when 8 then 'IX'
			when 9 then 'SIU'
			when 10 then 'SIX'
			when 11 then 'UIX'
			when 12 then 'BU'
			when 13 then 'RangeS_S'
			when 14 then 'RangeS_U'
			when 15 then 'RangeI_N'
			when 16 then 'RangeI_S'
			when 17 then 'RangeI_U'
			when 18 then 'RangeI_X'
			when 19 then 'RangeX_S'
			when 20 then 'RangeX_U'
			when 21 then 'RangeX_X'
		end as Locking_LockType,
		case l_lock.rsc_type 
			when 1 then ''
			when 2 then 'Database'
			when 3 then 'File'
			when 4 then 'Index'
			when 5 then 'Table'
			when 6 then 'Page'
			when 7 then 'Key'
			when 8 then 'Extent'
			when 9 then 'Row ID'
			when 10 then 'Application'
		end as Lock_ResType,

		l.req_transactionid as Waiting_TransactionID,
		b.program_name as Waiting_ProgramName, 
		b.loginame as Waiting_LoginName,
		s.program_name as Locking_ProgramName, 
		s.loginame as Locking_LoginName
	FROM sys.sysprocesses as b
	inner join sys.sysprocesses s on b.blocked = s.spid
	CROSS APPLY sys.dm_exec_sql_text (s.sql_handle) as slock
	cross apply sys.dm_exec_sql_text (b.sql_handle) as block
	inner join sys.syslockinfo as l on b.spid = l.req_spid
	inner join sys.syslockinfo as l_lock on s.spid = l_lock.req_spid and l.rsc_objid = l_lock.rsc_objid
	WHERE b.spid >= 50 and b.blocked > 0 and b.waittime > 5000
		and l.req_status = 3

-- rollback