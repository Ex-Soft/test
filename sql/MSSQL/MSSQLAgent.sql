DECLARE @agent NVARCHAR(512);

SELECT @agent = COALESCE(N'SQLAgent$' + CONVERT(SYSNAME, SERVERPROPERTY('InstanceName')), N'SQLServerAgent');

EXEC master.dbo.xp_servicecontrol 'QueryState', @agent;

IF EXISTS (  SELECT 1 
             FROM MASTER.dbo.sysprocesses 
             WHERE program_name = N'SQLAgent - Generic Refresher')
BEGIN
    SELECT @@SERVERNAME AS 'InstanceName', 1 AS 'SQLServerAgentRunning'
END
ELSE 
BEGIN
    SELECT @@SERVERNAME AS 'InstanceName', 0 AS 'SQLServerAgentRunning'
END

IF EXISTS (SELECT 1 FROM sysprocesses WHERE LEFT(program_name, 8) = 'SQLAgent')
  PRINT 'Agent is running!'
ELSE
  PRINT 'Agent is not connected!';
 
  select s.name,l.name
 from  msdb..sysjobs s 
 left join master.sys.syslogins l on s.owner_sid = l.sid
 
 select s.name,l.name 
from msdb..sysssispackages s 
 left join master.sys.syslogins l on s.ownersid = l.sid
 
 EXEC dbo.sp_help_job
 
 
 SELECT job.job_id,notify_level_email
       ,name,enabled,description
       ,step_name,command,server,database_name

   FROM msdb.dbo.sysjobs job JOIN 
     msdb.dbo.sysjobsteps steps        
        ON job.job_id = steps.job_id
 

SELECT  sysjobs.name 'Job Name',
        syscategories.name 'Category',
        CASE [description]
          WHEN 'No Description available.' THEN ''
          ELSE [description]
        END AS 'Description'
FROM    msdb.dbo.sysjobs
        INNER JOIN msdb.dbo.syscategories ON msdb.dbo.sysjobs.category_id = msdb.dbo.syscategories.category_id
WHERE   syscategories.name <> 'Report Server'
ORDER BY sysjobs.name 


USE YOURDATABASEHERE
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:             Your User Name
-- Create date:     Date today
-- Description:     This STP will return all the jobs on the SQL server
-- that are set to run on a scheduled basis.  The query returns all the
-- jobs you have and you can alter it to exclude non scheduled jobs or
-- schedules/jobs you do not want to see.
-- =============================================

CREATE PROCEDURE [dbo].[ustp_SQLServerJobs] as
SET NOCOUNT ON

SELECT DISTINCT substring(a.name,1,100) AS [Job Name], 
	'Enabled'=case 
	WHEN a.enabled = 0 THEN 'No'
	WHEN a.enabled = 1 THEN 'Yes'
	end, 
    	substring(b.name,1,30) AS [Name of the schedule],
	'Frequency of the schedule execution'=case
	WHEN b.freq_type = 1 THEN 'Once'
	WHEN b.freq_type = 4 THEN 'Daily'
	WHEN b.freq_type = 8 THEN 'Weekly'
	WHEN b.freq_type = 16 THEN 'Monthly'
	WHEN b.freq_type = 32 THEN 'Monthly relative'	
	WHEN b.freq_type = 32 THEN 'Execute when SQL Server Agent starts'
	END,	
	'Units for the freq_subday_interval'=case
	WHEN b.freq_subday_type = 1 THEN 'At the specified time' 
	WHEN b.freq_subday_type = 2 THEN 'Seconds' 
	WHEN b.freq_subday_type = 4 THEN 'Minutes' 
	WHEN b.freq_subday_type = 8 THEN 'Hours' 
	END,	
	cast(cast(b.active_start_date as varchar(15)) as datetime) as active_start_date,	
	cast(cast(b.active_end_date as varchar(15)) as datetime) as active_end_date,	
	Stuff(Stuff(right('000000'+Cast(c.next_run_time as Varchar),6),3,0,':'),6,0,':') as Run_Time,	
	convert(varchar(24),b.date_created) as Created_Date
	
FROM  msdb.dbo.sysjobs a 
INNER JOIN msdb.dbo.sysJobschedules c ON a.job_id = c.job_id 
INNER JOIN msdb.dbo.SysSchedules b on b.Schedule_id=c.Schedule_id
GO

select
	*
from
	msdb.dbo.sysjobhistory h
	left join msdb.dbo.sysjobs j on j.job_id = h.job_id