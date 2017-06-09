select
	*
from
	sys.default_constraints [default_constraints]
	join sys.columns c on c.object_id = [default_constraints].parent_object_id and c.column_id = [default_constraints].parent_column_id
where
	[default_constraints].parent_object_id = object_id(N'TestTableWDefault')
	and [default_constraints].name = N'dfDtTm'

select
	*
from
	sys.columns [columns]
	join sys.default_constraints [default_constraints] on [default_constraints].object_id = [columns].default_object_id and [default_constraints].parent_column_id = [columns].column_id
where
	[columns].object_id = object_id(N'TestTableWDefault')
	and [columns].name = N'DtTm'
	and [default_constraints].name = N'dfDtTm'

select
	*
from
	sys.objects [objects]
where
	[objects].object_id = 1874105717