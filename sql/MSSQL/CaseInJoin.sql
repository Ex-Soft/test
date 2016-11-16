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