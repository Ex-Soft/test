select
	resource_type,
	resource_database_id,
	isnull(db_name(resource_database_id), N'resourcedb') as dbname,
	resource_associated_entity_id,
	object_name(resource_associated_entity_id, resource_database_id) as objname,
	request_mode,
	request_type,
	request_status,
	request_session_id
from
	sys.dm_tran_locks
where
	request_session_id = 54
