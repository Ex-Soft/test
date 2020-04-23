/* https://jaxenter.com/10-sql-tricks-that-you-didnt-think-were-possible-125934.html */

declare @t table (id int)

insert into @t
select id from
(
	values (1), (2), (3), (5), (6), (9)
) t(id)

select
	id,
	row_number() over (order by id) as rn
from
	@t

select
	id as id,
	id - row_number() over (order by id) as rn
from
	@t

;with groups (id, grp)
as
(
	select
		id as id,
		id - row_number() over (order by id) as grp
	from
		@t
)
select
	min(id) as [min],
	max(id) as [max],
	max(id) - min(id) + 1 as [length]
from
	groups
group by grp
order by [length] desc

declare @logins table (login_time datetime)
insert into @logins
select login_time from
(
	values ('20140318 05:37:13'), ('20140316 08:31:47'), ('20140316 06:11:17'), ('20140316 05:59:33'), (' 20140315 11:17:28'), ('20140315 10:00:11'), ('20140315 07:45:27'), ('20140315 07:42:19'), ('20140314 09:38:12')
) t(login_time)

select * from @logins
;with cte (login_date) as (select cast(login_time as date) from @logins) select max(login_date), min(login_date), max(cast(login_date as datetime)) - min(cast(login_date as datetime)) from cte

;with
  login_dates as (
    select distinct cast(login_time as date) login_date 
    from @logins
  ),
  login_date_groups as (
    select
      login_date,
      cast(login_date as datetime) - row_number() over (order by login_date) as grp
    from login_dates
  )
select
  min(login_date), max(login_date),
  max(cast(login_date as datetime)) - min(cast(login_date as datetime)) as length
from login_date_groups
group by grp
order by length desc
