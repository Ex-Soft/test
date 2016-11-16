/*
Security Audit Report
1) List all access provisioned to a sql user or windows user/group directly 
2) List all access provisioned to a sql user or windows user/group through a database or application role
3) List all access provisioned to the public role

Columns Returned:
UserName        : SQL or Windows/Active Directory user cccount.  This could also be an Active Directory group.
UserType        : Value will be either 'SQL User' or 'Windows User'.  This reflects the type of user defined for the 
                  SQL Server user account.
DatabaseUserName: Name of the associated user as defined in the database user account.  The database user may not be the
                  same as the server user.
Role            : The role name.  This will be null if the associated permissions to the object are defined at directly
                  on the user account, otherwise this will be the name of the role that the user is a member of.
PermissionType  : Type of permissions the user/role has on an object. Examples could include CONNECT, EXECUTE, SELECT
                  DELETE, INSERT, ALTER, CONTROL, TAKE OWNERSHIP, VIEW DEFINITION, etc.
                  This value may not be populated for all roles.  Some built in roles have implicit permission
                  definitions.
PermissionState : Reflects the state of the permission type, examples could include GRANT, DENY, etc.
                  This value may not be populated for all roles.  Some built in roles have implicit permission
                  definitions.
ObjectType      : Type of object the user/role is assigned permissions on.  Examples could include USER_TABLE, 
                  SQL_SCALAR_FUNCTION, SQL_INLINE_TABLE_VALUED_FUNCTION, SQL_STORED_PROCEDURE, VIEW, etc.   
                  This value may not be populated for all roles.  Some built in roles have implicit permission
                  definitions.          
ObjectName      : Name of the object that the user/role is assigned permissions on.  
                  This value may not be populated for all roles.  Some built in roles have implicit permission
                  definitions.
ColumnName      : Name of the column of the object that the user/role is assigned permissions on. This value
                  is only populated if the object is a table, view or a table value function.                 
*/

--List all access provisioned to a sql user or windows user/group directly 
SELECT  
    [UserName] = CASE princ.[type] 
                    WHEN 'S' THEN princ.[name]
                    WHEN 'U' THEN ulogin.[name] COLLATE Latin1_General_CI_AI
                 END,
    [UserType] = CASE princ.[type]
                    WHEN 'S' THEN 'SQL User'
                    WHEN 'U' THEN 'Windows User'
                 END,  
    [DatabaseUserName] = princ.[name],       
    [Role] = null,      
    [PermissionType] = perm.[permission_name],       
    [PermissionState] = perm.[state_desc],       
    [ObjectType] = obj.type_desc,--perm.[class_desc],       
    [ObjectName] = OBJECT_NAME(perm.major_id),
    [ColumnName] = col.[name]
FROM    
    --database user
    sys.database_principals princ  
LEFT JOIN
    --Login accounts
    sys.login_token ulogin on princ.[sid] = ulogin.[sid]
LEFT JOIN        
    --Permissions
    sys.database_permissions perm ON perm.[grantee_principal_id] = princ.[principal_id]
LEFT JOIN
    --Table columns
    sys.columns col ON col.[object_id] = perm.major_id 
                    AND col.[column_id] = perm.[minor_id]
LEFT JOIN
    sys.objects obj ON perm.[major_id] = obj.[object_id]
WHERE 
    princ.[type] in ('S','U')
UNION
--List all access provisioned to a sql user or windows user/group through a database or application role
SELECT  
    [UserName] = CASE memberprinc.[type] 
                    WHEN 'S' THEN memberprinc.[name]
                    WHEN 'U' THEN ulogin.[name] COLLATE Latin1_General_CI_AI
                 END,
    [UserType] = CASE memberprinc.[type]
                    WHEN 'S' THEN 'SQL User'
                    WHEN 'U' THEN 'Windows User'
                 END, 
    [DatabaseUserName] = memberprinc.[name],   
    [Role] = roleprinc.[name],      
    [PermissionType] = perm.[permission_name],       
    [PermissionState] = perm.[state_desc],       
    [ObjectType] = obj.type_desc,--perm.[class_desc],   
    [ObjectName] = OBJECT_NAME(perm.major_id),
    [ColumnName] = col.[name]
FROM    
    --Role/member associations
    sys.database_role_members members
JOIN
    --Roles
    sys.database_principals roleprinc ON roleprinc.[principal_id] = members.[role_principal_id]
JOIN
    --Role members (database users)
    sys.database_principals memberprinc ON memberprinc.[principal_id] = members.[member_principal_id]
LEFT JOIN
    --Login accounts
    sys.login_token ulogin on memberprinc.[sid] = ulogin.[sid]
LEFT JOIN        
    --Permissions
    sys.database_permissions perm ON perm.[grantee_principal_id] = roleprinc.[principal_id]
LEFT JOIN
    --Table columns
    sys.columns col on col.[object_id] = perm.major_id 
                    AND col.[column_id] = perm.[minor_id]
LEFT JOIN
    sys.objects obj ON perm.[major_id] = obj.[object_id]
UNION
--List all access provisioned to the public role, which everyone gets by default
SELECT  
    [UserName] = '{All Users}',
    [UserType] = '{All Users}', 
    [DatabaseUserName] = '{All Users}',       
    [Role] = roleprinc.[name],      
    [PermissionType] = perm.[permission_name],       
    [PermissionState] = perm.[state_desc],       
    [ObjectType] = obj.type_desc,--perm.[class_desc],  
    [ObjectName] = OBJECT_NAME(perm.major_id),
    [ColumnName] = col.[name]
FROM    
    --Roles
    sys.database_principals roleprinc
LEFT JOIN        
    --Role permissions
    sys.database_permissions perm ON perm.[grantee_principal_id] = roleprinc.[principal_id]
LEFT JOIN
    --Table columns
    sys.columns col on col.[object_id] = perm.major_id 
                    AND col.[column_id] = perm.[minor_id]                   
JOIN 
    --All objects   
    sys.objects obj ON obj.[object_id] = perm.[major_id]
WHERE
    --Only roles
    roleprinc.[type] = 'R' AND
    --Only public role
    roleprinc.[name] = 'public' AND
    --Only objects of ours, not the MS objects
    obj.is_ms_shipped = 0
ORDER BY
    princ.[Name],
    OBJECT_NAME(perm.major_id),
    col.[name],
    perm.[permission_name],
    perm.[state_desc],
    obj.type_desc--perm.[class_desc] 


--Server level Logins and roles
SELECT sp.name AS LoginName,sp.type_desc AS LoginType, sp.default_database_name AS DefaultDBName,slog.sysadmin AS SysAdmin,slog.securityadmin AS SecurityAdmin,slog.serveradmin AS ServerAdmin, slog.setupadmin AS SetupAdmin, slog.processadmin AS ProcessAdmin, slog.diskadmin AS DiskAdmin, slog.dbcreator AS DBCreator,slog.bulkadmin AS BulkAdmin
FROM sys.server_principals sp  JOIN master..syslogins slog
ON sp.sid=slog.sid 
WHERE sp.type  <> 'R' AND sp.name NOT LIKE '##%'

--Databases users and roles
DECLARE @SQLStatement VARCHAR(4000) 
DECLARE @T_DBuser TABLE (DBName SYSNAME, UserName SYSNAME, AssociatedDBRole NVARCHAR(256)) 
SET @SQLStatement='
SELECT ''?'' AS DBName,dp.name AS UserName,USER_NAME(drm.role_principal_id) AS AssociatedDBRole 
FROM ?.sys.database_principals dp
LEFT OUTER JOIN ?.sys.database_role_members drm
ON dp.principal_id=drm.member_principal_id 
WHERE dp.sid NOT IN (0x01) AND dp.sid IS NOT NULL AND dp.type NOT IN (''C'') AND dp.is_fixed_role <> 1 AND dp.name NOT LIKE ''##%'' AND ''?'' NOT IN (''master'',''msdb'',''model'',''tempdb'') ORDER BY DBName'
INSERT @T_DBuser
EXEC sp_MSforeachdb @SQLStatement
SELECT * FROM @T_DBuser ORDER BY DBName

--Get objects permission of specified user database 
USE <Database Name>
GO
DECLARE @Obj VARCHAR(4000)
DECLARE @T_Obj TABLE (UserName SYSNAME, ObjectName SYSNAME, Permission NVARCHAR(128))
SET @Obj='
SELECT Us.name AS username, Obj.name AS object,  dp.permission_name AS permission 
FROM sys.database_permissions dp
JOIN sys.sysusers Us 
ON dp.grantee_principal_id = Us.uid 
JOIN sys.sysobjects Obj
ON dp.major_id = Obj.id '
INSERT @T_Obj 
EXEC sp_MSforeachdb @Obj
SELECT * FROM @T_Obj 

declare @dsql nvarchar(max)
select @dsql = stuff((select N' union select * from [' + name + N'].sys.assemblies' from master.sys.databases where collation_name = N'Cyrillic_General_CI_AS' for xml path('')), 1, 7, '')
exec sp_executesql @dsql

select
	*
from
	sys.assemblies asm
	join sys.assembly_files asm_files on asm_files.assembly_id = asm.assembly_id

select top 1
  m.*
from
  sysmembers m

select top 1
  u.*
from
  sysusers u
  
select
  u.uid,
  u.name as username,
  r.name as rolename,
  u.*,
  m.*,
  r.*
from
  sysusers u
  join sysmembers m on (m.memberuid=u.uid)
  join sysusers r ON (r.uid=m.groupuid)
where
  (u.name='shurik')

select top 1
  1
from
  master..sysdatabases
where
  exists (select
            u.uid
          from
            sysusers u
            join sysmembers m on m.memberuid=u.uid
            join sysusers r on r.uid=m.groupuid
          where
            (u.name = @MSSQLUser)
            and (r.name = @MSSQLRole))

select
  u.*,
  m.*,
  r.*
from
  sysusers u
  join sysmembers m on m.memberuid=u.uid
  join sysusers r on r.uid=m.groupuid
where
  r.name='PRETENSION_DELIVERY'

select
  serverproperty('Edition')
from
  master..sysdatabases

exec sp_addrolemember N'PRETENSION_SUST', N'chinin_v'
go

select * from information_schema.routines where routine_definition like '%Sending%'
select * from sys.sql_modules

/* "orphaned users." (пользователи БД без login'ов) */
/* http://www.akadia.com/services/sqlsrv_logins_and_users.html */
select
  su.*,
  sl.*
from
  sysusers su
  left join master..syslogins sl on (sl.sid=su.sid)
where
  (su.issqlrole=0)
  and (sl.sid is null)

use db001
go

select sid from master..syslogins where name=N'chicago_reports'
select sid from db001..sysusers where name=N'chicago_reports'


/* sp_change_users_login 'update_one', 'chicago_reports', 'chicago_reports' */

select * from sys.database_principals

select * from sys.server_principals
select * from sys.syslogins

select * from sys.server_principals where name=N'test_login'
select * from master..syslogins where name=N'test_login'
select * from testdb..sysusers where name=N'test_user'

select
	*
from
	master..syslogins l
	left join testdb..sysusers u on u.sid=l.sid
where
	l.name=N'test_login'

select
	*
from
	sys.server_principals l
	left join testdb..sysusers u on u.sid=l.sid
where
	l.name=N'test_login'

sp_change_users_login @Action='Report'

select suser_sname()
select suser_name()
select suser_sname(0x0773E3F7204C594C9646EA94C296A98E)

select system_user

select suser_sid()
select suser_sid('test_login')

select user
select user_id()
select user_name()
select current_user


/* compatibility level of the database */
exec sp_dbcmptlevel N'pretensions'

select
	*
from
	sys.sysprocesses p
where
	(p.dbid=db_id(N'chicago_2_10_2'))
	and (p.spid!=@@spid)

select
	*
from
	master.dbo.sysprocesses p
where
	(p.dbid=db_id(N'chicago_2_10_2'))
	and (p.spid!=@@spid)

/* http://blog.sqlauthority.com/2011/02/08/sql-server-sos_scheduler_yield-wait-type-day-8-of-28/ */

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

select @@servername as ServerName, @@version as Version, db_name() as DBName, system_user as SystemUser