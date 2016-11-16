declare
	@t table
	(
		id bigint not null identity(1,1) primary key,
		f1 int null,
		f2 int null,
		processed bit not null default 0
	)

insert into @t (f1, f2) values (1, 1)
insert into @t (f1, f2) values (2, 1)
insert into @t (f1, f2) values (3, 1)
insert into @t (f1, f2) values (1, 2)
insert into @t (f1, f2) values (2, 2)
insert into @t (f1, f2) values (3, 2)
insert into @t (f1, f2) values (1, 3)
insert into @t (f1, f2) values (2, 3)
insert into @t (f1, f2) values (3, 3)

select * from @t

declare
	@id bigint,
	@f1 int,
	@f2 int,
	@processed bit,
	@tmpStr nvarchar(max)

declare cur cursor for
select
	id,
	f1,
	f2,
	processed
from
	@t
where
	(processed=0)
for read only

open cur
fetch cur into @id, @f1, @f2, @processed
while @@fetch_status=0
begin
	set @tmpStr=N'id='+convert(nvarchar(max), @id)+N', f1='+convert(nvarchar(max), @f1)+N', f2='+convert(nvarchar(max), @f2)+N', processed='+convert(nvarchar(max), @processed)
	print @tmpStr

	if @processed=0
		update @t set processed=1 where f1=@f1

	fetch cur into @id, @f1, @f2, @processed
end
close cur
deallocate cur

select * from @t