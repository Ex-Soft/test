select
	id,
	val,
	array(select row(id, val)::testdb.detail_item from testdb.detail detail where detail.id_master = master.id),
	array_agg(array(select row(id, val)::testdb.detail_item from testdb.detail detail where detail.id_master = master.id))
from
	testdb.master master
where
	cardinality(array(select row(id, val)::testdb.detail_item from testdb.detail detail where detail.id_master = master.id)) <> 0
group by master.id, master.val

/* array vs array_agg */
"{""(1,\""Val# 1.1\"")"",""(2,\""Val# 1.2\"")"",""(3,\""Val# 1.3\"")"",""(4,\""Val# 1.4\"")"",""(5,\""Val# 1.5\"")""}"
{{""(6,\""Val# 2.1\"")"",""(7,\""Val# 2.2\"")"",""(8,\""Val# 2.3\"")"",""(9,\""Val# 2.4\"")"",""(10,\""Val# 2.5\"")""}}

select
	*
from
	testdb.master master
	/* cross apply */
	cross join lateral
	(
		select
			sum(detail.f_int)
		from
			testdb.detail detail
		where
			detail.id_master = master.id
	) t;

select
	*
from
	testdb.master master
	/* outer apply */
	left join lateral
	(
		select
			sum(detail.f_int)
		from
			testdb.detail detail
		where
			detail.id_master = master.id
	) t on true;
