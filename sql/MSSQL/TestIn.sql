declare @t table (id int, idMain int)

insert into @t (id, idMain) values (1, 1)
insert into @t (id, idMain) values (2, 1)
insert into @t (id, idMain) values (3, 3)

select * from @t where 1 in (id, idMain)

declare @src table (id int)
declare @dest table (id int)

insert into @src
	(id)
values
	(1),(3),(5)

insert into @dest
	(id)
values
	(1),(2),(3),(4),(5)

select
	*
from
	@dest
where
	id in (select id from @src)

select
	*
from
	@dest dest
	join @src src on src.id = dest.id
