-- http://rusanu.com/2009/06/11/exception-handling-and-nested-transactions/

use testdb
go

if object_id(N'TestProcedureWTransaction', N'p') is not null
	drop procedure TestProcedureWTransaction
go

create procedure TestProcedureWTransaction
	@id int = null,
	@value nvarchar(255) = null,
	@beginTransaction bit = 0,
	@rollbackTransaction bit = 0,
	@raiserrorBefore bit = 0,
	@raiserrorAfter bit = 0,
	@spid smallint output,
	@trancount int output
as
begin
	set nocount on

	set @spid = @@spid
	
	if @beginTransaction = 1
		begin transaction

	set @trancount = @@trancount

	if @id is null
		insert into Table4TestTransaction (value) values (@value)
	else
		update Table4TestTransaction set value = @value where id = @id

	if @raiserrorBefore = 1
		raiserror (N'raiserrorBefore', 17, 1)

	if @beginTransaction = 1
		begin
			if @rollbackTransaction = 1
				rollback transaction
			else
				commit transaction
		end

	if @raiserrorAfter = 1
		raiserror (N'raiserrorAfter', 17, 1)
end
go