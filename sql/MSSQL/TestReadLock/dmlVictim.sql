declare
	@i int

select
	@i = s1.object_id
from
	sys.all_columns s1 --with (nolock)
	cross join sys.all_columns s2 --with (nolock)
	cross join sys.all_columns s3 --with (nolock)
