set transaction isolation level read committed
begin tran

select
	*
from
	TestTable4ReadLock
where
	ID = 100

select
	*
from
	TestTable4ReadLock
where
	Value = 100

-- rollback
