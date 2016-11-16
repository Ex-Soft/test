--select * from sys.databases
--select * from sys.database_files
--select * from sys.master_files
--select * from sys.master_files where database_id = db_id(N'TestPlanogram') order by name

select
	*
from
	sys.databases [sysdatabases]
	left join sys.master_files [sysmaster_files] on [sysmaster_files].database_id = [sysdatabases].database_id
order by [sysdatabases].database_id, [sysmaster_files].physical_name