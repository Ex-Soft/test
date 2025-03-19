use testdb;
go

delete from TestTable4Apply1;
go

delete from TestTable4Apply2;
go

declare
	@cnt int = 1;

while @cnt <= 100000
	begin
		insert into TestTable4Apply2 (id, value) values (@cnt, N'Value ' + CAST(@cnt as nvarchar));
		set @cnt += 1;
	end;

insert into TestTable4Apply1 (id, row_count)
select top 5
	id, id % 2 + 1
from
	TestTable4Apply2
order by id;
