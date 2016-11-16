alter index IX_refOutercodes_idItem_idDistr on dbo.refOutercodes rebuild;
alter index IX_refOutercodes_hash on dbo.refOutercodes rebuild;
alter index ix_refOutercodes_cover on dbo.refOutercodes rebuild;
alter index IX_refOutercodes_outercode_distr on dbo.refOutercodes rebuild;
alter index PK_refOutercodes on dbo.refOutercodes rebuild;

select
	a.index_id,
	name,
	avg_fragmentation_in_percent
from
	sys.dm_db_index_physical_stats (db_id(N'ch'), object_id(N'dbo.refOutercodes'), null, null, null) as a
    join sys.indexes as b on a.object_id = b.object_id and a.index_id = b.index_id; 