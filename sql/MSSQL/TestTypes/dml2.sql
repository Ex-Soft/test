select * from TestTable4Date;

if not exists (select 1 from TestTable4Date where Id = 1)
	insert into TestTable4Date (Id) values (1);

select Id, FDateTimeOffset, FDateTimeOffset7 from TestTable4Date where FDateTimeOffset = FDateTimeOffset7;