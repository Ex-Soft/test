--insert into Table4TestTransaction (value) values (N'insert')
--update Table4TestTransaction set value = N'update' where id = 4
--delete from Table4TestTransaction where id > 2
--delete from Table4TestTransactionLog

declare
	@id int,
	@value nvarchar(255),
	@beginTransaction bit,
	@rollbackTransaction bit,
	@raiserrorBefore bit,
	@raiserrorAfter bit,
	@spid smallint,
	@trancount int,
	@retval int,
	@tmpDatetime datetime

begin transaction

set @tmpDatetime = getdate()
set @id = 2
set @value = N'update ' + cast(datepart(hh, @tmpDatetime) as nvarchar(2)) + N':' + cast(datepart(mi, @tmpDatetime) as nvarchar(2)) + N':' + cast(datepart(ss, @tmpDatetime) as nvarchar(2)) + N'.' + cast(datepart(ms, @tmpDatetime) as nvarchar(3))
print @value
set @beginTransaction = 1
set @rollbackTransaction = 1
set @raiserrorBefore = 0
set @raiserrorAfter = 1
exec @retval = TestProcedureWTransaction @id = @id, @value = @value, @beginTransaction = @beginTransaction,	@rollbackTransaction = @rollbackTransaction, @raiserrorBefore = @raiserrorBefore, @raiserrorAfter = @raiserrorAfter, @spid = @spid out, @trancount = @trancount out

--rollback transaction
commit transaction

select @spid as [@@spid], @trancount as [@@trancount]

select * from Table4TestTransaction
select * from Table4TestTransactionLog
