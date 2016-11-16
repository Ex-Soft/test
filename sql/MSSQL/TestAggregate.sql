declare @t table (val1 int, val2 int)

insert into @t (val1, val2) values (1, 1)
insert into @t (val1, val2) values (1, 2)
insert into @t (val1, val2) values (1, 3)
insert into @t (val1, val2) values (2, 1)
insert into @t (val1, val2) values (2, 2)

select
	val1,
	max(val2) as MaxVal2,
	count(val1) as Cnt
from
	@t
group by val1

select
	val1,
	max(val2) as MaxVal2,
	count(val1) as Cnt
from
	@t
group by val1
having count(val1) = 2

select
	val1,
	max(val2) as MaxVal2
from
	@t
group by val1
having count(val1) = 2

select
	val1,
	max(val2) as MaxVal2
from
	@t
where
	val1 != val2
group by val1
having count(val1) = 1

delete from @t

insert into @t (val1, val2) values (1, 1)
insert into @t (val1, val2) values (2, 2)
insert into @t (val1, val2) values (3, 3)
insert into @t (val1, val2) values (null, 4)
insert into @t (val1, val2) values (null, 5)

/*
	if table empty - NULL
	else max
*/
select max(val1) from @t

/*
	if table empty - NULL
	else min
*/
select min(val1) from @t

/*
	if table empty - NULL
	else sum of recorords where value is not null
*/
select sum(val1) as ["sum(val1)"], sum(val1+val2) as ["sum(val1+val2)"], sum(val1)-sum(val2) as ["sum(val1)-sum(val2)"] from @t

/*
	if table empty - 0
	else count of recorords where val1 is not null
*/
select count(val1) from @t

/*
	if table empty - 0
	else count of all records
*/
select count(*) from @t
