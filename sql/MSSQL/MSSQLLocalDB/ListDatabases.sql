select
	[sysdatabases].name,
	[sysmaster_files].physical_name
from
	sys.databases [sysdatabases]
	left join sys.master_files [sysmaster_files] on [sysmaster_files].database_id = [sysdatabases].database_id
order by [sysdatabases].database_id, [sysmaster_files].physical_name
