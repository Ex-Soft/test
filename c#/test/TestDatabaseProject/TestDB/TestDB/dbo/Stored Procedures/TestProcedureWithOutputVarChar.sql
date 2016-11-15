
create procedure TestProcedureWithOutputVarChar
	@Id bigint,
	@FVarCharOut varchar(256) output /* without length return first char */
as
begin

	set nocount on

	select
		@FVarCharOut = FVarChar
	from
		TestTable4Types
	where
	Id = @Id

end
