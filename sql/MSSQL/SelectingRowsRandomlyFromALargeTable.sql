/* https://msdn.microsoft.com/en-us/library/cc441928.aspx */

select top 10 id from dbo.DocJournal order by newid()
select top 10 id from dbo.DocJournal where (abs (cast((binary_checksum(*) * rand()) as int)) % 100) < 10

select
	object_id,
	binary_checksum(*) as [binary_checksum(*)],
	binary_checksum(object_id) as [binary_checksum(object_id)],
	binary_checksum(object_id, newid()) as [binary_checksum(object_id, newid())],
	cast((binary_checksum(*) * rand()) as int) as [cast((binary_checksum(*) * rand()) as int)],
	cast(binary_checksum(object_id, newid()) as int) as [cast(binary_checksum(object_id, newid()) as int)],
	cast((binary_checksum(object_id, newid()) * rand()) as int) as [cast((binary_checksum(object_id, newid()) * rand()) as int)],
	abs(cast((binary_checksum(*) * rand()) as int)) % 100 as [abs(cast((binary_checksum(*) * rand()) as int)) % 100],
	abs(cast(binary_checksum(object_id, newid()) as int)) % 100 as [abs(cast(binary_checksum(object_id, newid()) as int)) % 100],
	abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100 as [abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100]
from
	sys.objects

;with cte (object_id, [binary_checksum(*)], [binary_checksum(object_id)], [binary_checksum(object_id, newid())], [cast((binary_checksum(*) * rand()) as int)], [cast((binary_checksum(object_id, newid()) * rand()) as int)], [abs(cast((binary_checksum(*) * rand()) as int)) % 100], [abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100])
as
(
	select
		object_id,
		binary_checksum(*) as [binary_checksum(*)],
		binary_checksum(object_id) as [binary_checksum(object_id)],
		binary_checksum(object_id, newid()) as [binary_checksum(object_id, newid())],
		cast((binary_checksum(*) * rand()) as int) as [cast((binary_checksum(*) * rand()) as int)],
		cast((binary_checksum(object_id, newid()) * rand()) as int) as [cast((binary_checksum(object_id, newid()) * rand()) as int)],
		abs(cast((binary_checksum(*) * rand()) as int)) % 100 as [abs(cast((binary_checksum(*) * rand()) as int)) % 100],
		abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100 as [abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100]
	from
		sys.objects
)
select
	*
from
	sys.objects [sysobjects]
	left join cte cte on cte.object_id = [sysobjects].object_id and (cte.[abs(cast((binary_checksum(*) * rand()) as int)) % 100] < 10 or cte.[abs(cast((binary_checksum(object_id, newid()) * rand()) as int)) % 100] < 10)
