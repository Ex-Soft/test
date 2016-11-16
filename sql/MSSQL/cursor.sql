declare @id int = 13
declare @t table (id int)

insert into @t (id) values (null)
insert into @t (id) values (1)
insert into @t (id) values (null)
insert into @t (id) values (2)
insert into @t (id) values (null)
insert into @t (id) values (3)
insert into @t (id) values (null)

declare cur cursor for
select id from @t for read only

open cur
fetch cur into @id
while @@fetch_status = 0
begin
	if @id is not null
		print @id
	else
		print N'NULL'

	fetch cur into @id
end
close cur
deallocate cur
