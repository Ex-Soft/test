select
  t1.*,
  t2.*
from
  TestTableWithIndexesI t1
  join TestTableWithIndexesII t2 on (t2.Field1=t1.Field1)
where
  t1.Field2 in (2, 4)
go

select
  mig.*,
  statement as table_name,
  column_id,
  column_name,
  column_usage
from
  sys.dm_db_missing_index_details as mid
  cross apply sys.dm_db_missing_index_columns (mid.index_handle)
  join sys.dm_db_missing_index_groups as mig on mig.index_handle = mid.index_handle
order by mig.index_group_handle, mig.index_handle, column_id
go