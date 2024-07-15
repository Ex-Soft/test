declare @groups table (id int, [name] nvarchar(10));
insert into @groups (id, [name]) values (1, N'#1');
insert into @groups (id, [name]) values (2, N'#2');
insert into @groups (id, [name]) values (3, N'#3');

declare @students table (id int, [name] nvarchar(10));
insert into @students (id, [name]) values (1, N'Ihor');
insert into @students (id, [name]) values (2, N'Ihor');
insert into @students (id, [name]) values (3, N'Yaroslav');
insert into @students (id, [name]) values (4, N'Yaroslav');

declare @rel table (groupId int, studentId int);
insert into @rel (groupId, studentId) values (1, 1);
insert into @rel (groupId, studentId) values (1, 2);
insert into @rel (groupId, studentId) values (2, 1);
insert into @rel (groupId, studentId) values (2, 3);
insert into @rel (groupId, studentId) values (3, 3);
insert into @rel (groupId, studentId) values (3, 4);

select
	*
from
	@groups groups
where
	groups.id = (
		select
			rel.groupId
		from
			@rel rel
			join @students students on students.id = rel.studentId
		where
			rel.groupId = groups.id
		group by rel.groupId
		having count(distinct students.[name]) = 1
	);

select
	*
from
	@groups groups
where
	not exists (
		select
			1
		from
			@rel rel
			join @students students on students.id = rel.studentId
		where
			rel.groupId = groups.id
			and students.[name] != N'Ihor'
	);
