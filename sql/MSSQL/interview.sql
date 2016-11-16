declare @t table (id int, [date] date, present bit)

insert into @t (id, [date], present) values (1, N'20160101', 0)
insert into @t (id, [date], present) values (1, N'20160102', 0)
insert into @t (id, [date], present) values (1, N'20160103', 0)
insert into @t (id, [date], present) values (1, N'20160104', 0)
insert into @t (id, [date], present) values (2, N'20160101', 0)
insert into @t (id, [date], present) values (2, N'20160102', 0)
insert into @t (id, [date], present) values (2, N'20160103', 0)
insert into @t (id, [date], present) values (3, N'20160101', 0)
insert into @t (id, [date], present) values (3, N'20160102', 0)

select
	distinct tOuter.id
from
	@t tOuter
where
	(select count(id) from @t tInner where tInner.id = tOuter.id and tInner.present = 0)  >= 3

;with cte (id, cnt)
as
(
	select
		id,
		count(id)
	from
		@t
	where
		present = 0
	group by id
	having count(id) >= 3
)
select
	*
from
	@t t
	join cte cte on cte.id = t.id
