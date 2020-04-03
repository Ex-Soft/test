declare @t table
(
	[Key] varchar(100),
	Switch varchar(100),
	[Value] varchar(100)
)

insert into @t
values
	('key1', 'switch1', 'key1 _switch1'),
	('key1', 'switch2', 'key1 _switch2'),
	('key1', 'switch3', 'key1 _switch3'),
	('key2', 'switch1', 'key2 _switch1'),
	('key2', 'switch2', 'key2 _switch2'),
	('key3', 'switch1', 'key3 _switch1')

select * from @t

select
	[to].[Key],
	ti1.[Value] as 'switch1',
	ti2.[Value] as 'switch2',
	ti3.[Value] as 'switch3'
from
	@t [to]
	left join @t ti1 on ti1.[Key] = [to].[Key] and ti1.Switch = 'switch1'
	left join @t ti2 on ti2.[Key] = [to].[Key] and ti2.Switch = 'switch2'
	left join @t ti3 on ti3.[Key] = [to].[Key] and ti3.Switch = 'switch3'

select
	[to].[Key],
	t.switch1,
	t.switch2,
	t.switch3
from
	@t [to]
	cross apply
	(
		select
			(select [Value] from @t where [Key] = [to].[Key] and Switch = 'switch1') as 'switch1',
			(select [Value] from @t where [Key] = [to].[Key] and Switch = 'switch2') as 'switch2',
			(select [Value] from @t where [Key] = [to].[Key] and Switch = 'switch3') as 'switch3'
	) t

;with cte ([Key]) as
(
	select distinct [Key] from @t
)
select
	cte.[Key],
	t.switch1,
	t.switch2,
	t.switch3
from
	cte cte
	cross apply
	(
		select
			(select [Value] from @t where [Key] = cte.[Key] and Switch = 'switch1') as 'switch1',
			(select [Value] from @t where [Key] = cte.[Key] and Switch = 'switch2') as 'switch2',
			(select [Value] from @t where [Key] = cte.[Key] and Switch = 'switch3') as 'switch3'
	) t;
