/* http://www.mssqltips.com/sqlservertip/1958/sql-server-cross-apply-and-outer-apply/ */
/* https://explainextended.com/2009/07/16/inner-join-vs-cross-apply/ */

select
  *
from
  TestTable4ApplyI t
  cross apply TestFunction4Apply(t.Field1)

1	1	5	1	1	11
1	1	5	2	1	12
1	1	5	3	1	13
1	1	5	4	1	14
1	1	5	5	1	15
3	3	3	6	3	31
3	3	3	7	3	32
3	3	3	8	3	33

select
  *
from
  TestTable4ApplyI t
  outer apply TestFunction4Apply(t.Field1)

1	1	5	1	1	11
1	1	5	2	1	12
1	1	5	3	1	13
1	1	5	4	1	14
1	1	5	5	1	15
2	2	4	NULL	NULL	NULL
3	3	3	6	3	31
3	3	3	7	3	32
3	3	3	8	3	33
4	4	2	NULL	NULL	NULL
5	5	1	NULL	NULL	NULL

------------------------------------------------------------

select
  *
from
  TestTable4ApplyI t1
  join TestTable4ApplyII t2 on (t2.Field1=t1.Field1)

select
  *
from
  TestTable4ApplyI t1
cross apply
(
  select
    *
  from
    TestTable4ApplyII t2
  where
    (t2.Field1=t1.Field1)
) t

------------------------------------------------------------

select
  *
from
  TestTable4ApplyI t1
  left join TestTable4ApplyII t2 on (t2.Field1=t1.Field1)

select
  *
from
  TestTable4ApplyI t1
outer apply
(
  select
    *
  from
    TestTable4ApplyII t2
  where
    (t2.Field1=t1.Field1)
) t

------------------------------------------------------------

select
  *
from
  TestTable4ApplyI t1
outer apply
(
  select
    *
  from
    TestTable4ApplyII oa1t2
  where
    (oa1t2.Field1=t1.Field1)
) oa1
outer apply
(
  select
    *
  from
    TestTable4ApplyII oa2t2
  where
    (oa2t2.Field2=t1.Field2)
) oa2

------------------------------------------------------------

declare @t table (id bigint, Name nvarchar(255))

;with cte(id)
as
(
	select 1
	union all
	select id + 1
	from cte
	where id < 5
)
insert into @t (id)
select id
from cte
option (maxrecursion 0)

update
	t
set
	Name = s.Name
from
	@t t
	outer apply
	(
		select
			Name
		from
			dbo.Staff staff
		where
			staff.id = t.id
	) s

select
	*
from
	@t

------------------------------------------------------------
/* https://explainextended.com/2009/07/16/inner-join-vs-cross-apply/ */

select * from TestTable4Apply1

select
	*
from
	TestTable4Apply1 t1
	join (
		select  t2o.*,
		(
			select count(*)
			from TestTable4Apply2 t2i
			where t2i.id <= t2o.id
		) as rn
		from TestTable4Apply2 t2o
	) t2
	on t2.rn <= t1.row_count
order by t1.id, t2.id

select
	*
from
	TestTable4Apply1 t1
	join (
		select t2o.*, row_number() over (order by id) as rn
		from TestTable4Apply2 t2o
	) t2
	on t2.rn <= t1.row_count
order by t1.id, t2.id

select
	*
from
	TestTable4Apply1 t1
	cross apply
	(
		select top (t1.row_count) *
		from TestTable4Apply2
		order by id
	) t2
order by t1.id, t2.id