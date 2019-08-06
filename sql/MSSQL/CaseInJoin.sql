declare @t1 table (id int, [type] int, f3 nvarchar(256))
declare @t2 table (id int, parentId int, f3 nvarchar(256))

insert into @t1 values (1, 1, N'1 1')
insert into @t1 values (2, 2, N'2 2')

insert into @t2 values (1, 1, N'1 1')
insert into @t2 values (2, 1, N'1 2')
insert into @t2 values (3, 1, N'1 3')
insert into @t2 values (4, 2, N'2 4')
insert into @t2 values (5, 2, N'2 5')
insert into @t2 values (6, 2, N'2 6')

select
	case t1.[type]
		when 1 then t21.f3
		when 2 then t22.f3
	end,
	*
from
	@t1 t1
	left join @t2 t21 on t21.parentId = t1.id and t1.[type] = 1
	left join @t2 t22 on t22.parentId = t1.id and t1.[type] = 2

select
	t2.f3,
	*
from
	@t1 t1
	join @t2 t2 on t2.parentId = t1.id and (t1.[type] = 1 or t1.[type] = 2)

declare @master table (id int, isDefault bit, Name nvarchar(50))
declare @detail table (id int, isDefault bit, Name nvarchar(50))

insert into @master (id, isDefault, Name) values (1, 1, N'Шаблон по умолчанию')
insert into @master (id, isDefault, Name) values (2, 0, N'Шаблон не по умолчанию #1')
insert into @master (id, isDefault, Name) values (3, 0, N'Шаблон не по умолчанию #2')
insert into @master (id, isDefault, Name) values (4, 0, N'Шаблон не по умолчанию #3')

insert into @detail (id, isDefault, Name) values (1, 1, N'Представление по умолчанию')
insert into @detail (id, isDefault, Name) values (2, 0, N'Шаблон не по умолчанию #1')
insert into @detail (id, isDefault, Name) values (3, 0, N'Шаблон не по умолчанию #2')

select
	*
from
	@master m
	left join @detail d on
		case m.isDefault
			when 1 then d.isDefault
			else case when m.Name = d.Name then 1 else 0 end
		end = 1
