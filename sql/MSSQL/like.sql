SELECT SERVERPROPERTY ('Collation')
--select * from m3m_command where code like '%OU%'
--select * from m3m_command where code like '%OU%' collate Ukrainian_CS_AS

declare @t table ([Value] nvarchar(max))

insert into @t
values
	(N'blah-blah-blah'),
	(N'[text](url)'),
	(N'[text](url attribute)'),
	(N'blah-blah-blah [text](url attribute) blah-blah-blah'),
	(N'[text](url) [text](url)'),
	(N'[text](url attribute) [text](url attribute)'),
	(N'blah-blah-blah [text](url attribute) blah-blah-blah [text](url attribute) blah-blah-blah')

select
	*
from
	@t
where
	[Value] like N'%](% %)%'