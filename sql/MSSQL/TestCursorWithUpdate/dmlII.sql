declare c cursor for
select
	id,
	f1
from
	@t

declare
	@id int,
	@f1 int

open c
fetch from c into @id, @f1
while @@fetch_status=0
	begin
		update
			@t
		set
			f2=@f1*2
		where current of c

		fetch from c into @id, @f1
	end

select * from @t