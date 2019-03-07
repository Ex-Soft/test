/* https://blog.sqlauthority.com/2015/07/06/sql-server-creating-dataset-using-values-clause-without-creating-a-table/ */

select
	tmpTbl.Id,
	tmpTbl.Value
from
(
	values
		(1, N'1'),
		(2, N'2'),
		(3, N'3')
) tmpTbl(Id, Value)

declare @t table (id int, f1 int, f2 int)

insert into @t
	(id, f1, f2)
select
	id,
	f1,
	f2
from
(
	values
		(1, 0, 0),
		(2, 0, 1),
		(3, 1, 0),
		(4, 1, 1)
) tmpTbl(id, f1, f2)

select * from @t