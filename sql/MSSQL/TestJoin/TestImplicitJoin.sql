declare @t1 table (id int, value nvarchar(254))
declare @t2 table (id int, value nvarchar(254))
declare @t3 table (id int, value nvarchar(254))
declare @t4 table (id int, value nvarchar(254))
declare @t table (id int, idT1 int, idT2 int, idT3 int, idT4 int)

insert into @t1 (id, value) values (1, N'T11')
insert into @t1 (id, value) values (2, N'T12')
insert into @t1 (id, value) values (3, N'T13')

insert into @t2 (id, value) values (1, N'T21')
insert into @t2 (id, value) values (2, N'T22')
insert into @t2 (id, value) values (3, N'T23')

insert into @t3 (id, value) values (1, N'T31')
insert into @t3 (id, value) values (2, N'T32')
insert into @t3 (id, value) values (3, N'T33')

insert into @t4 (id, value) values (1, N'T41')
insert into @t4 (id, value) values (2, N'T42')
insert into @t4 (id, value) values (3, N'T43')

insert into @t (id, idT1, idT2, idT3, idT4) values (1, 1, 1, 1, 1)
insert into @t (id, idT1, idT2, idT3, idT4) values (2, 1, 1, 1, 2)
insert into @t (id, idT1, idT2, idT3, idT4) values (3, 1, 1, 1, 3)
insert into @t (id, idT1, idT2, idT3, idT4) values (4, 1, 1, 2, 1)
insert into @t (id, idT1, idT2, idT3, idT4) values (5, 1, 1, 2, 2)
insert into @t (id, idT1, idT2, idT3, idT4) values (6, 1, 1, 2, 3)

select
	*
from
	@t t, @t1 t1, @t2 t2, @t3 t3, @t4 t4
where
	t.idT1 = t1.id
	and t.idT2 = t2.id
	and t.idT3 = t3.id
	and t.idT4 = t4.id
	
select
	t.id,
	(select t1.value from @t1 t1 where t1.id = t.idT1),
	(select t2.value from @t2 t2 where t2.id = t.idT2),
	(select t3.value from @t3 t3 where t3.id = t.idT3),
	(select t4.value from @t4 t4 where t4.id = t.idT4)
from
	@t t
