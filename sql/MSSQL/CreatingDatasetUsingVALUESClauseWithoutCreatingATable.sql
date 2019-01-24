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