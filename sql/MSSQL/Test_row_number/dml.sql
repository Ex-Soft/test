declare
	@t table(f1 int, f2 int, f3 int, f4 int)

insert into @t (f1, f2, f3, f4) values (1, 11, 111, 1111)
insert into @t (f1, f2, f3, f4) values (1, 11, 111, 1112)
insert into @t (f1, f2, f3, f4) values (1, 11, 111, 1113)
insert into @t (f1, f2, f3, f4) values (1, 11, 112, 1121)
insert into @t (f1, f2, f3, f4) values (1, 11, 112, 1122)
insert into @t (f1, f2, f3, f4) values (1, 11, 112, 1123)
insert into @t (f1, f2, f3, f4) values (1, 11, 113, 1131)
insert into @t (f1, f2, f3, f4) values (1, 12, 121, 1211)
insert into @t (f1, f2, f3, f4) values (1, 12, 122, 1221)
insert into @t (f1, f2, f3, f4) values (1, 13, 131, 1311)

select
	f1,
	f2,
	row_number() over (partition by f1 order by f1) as no
from
	@t

select
	f1,
	f2,
	f3,
	row_number() over (partition by f1, f2 order by f1) as no
from
	@t

select
	f1,
	f2,
	f3,
	f4,
	row_number() over (partition by f1, f2, f3 order by f4) as no
from
	@t

select
	f1,
	f2,
	f3,
	f4,
	row_number() over (partition by f1, f2, f3 order by f4 desc) as no
from
	@t