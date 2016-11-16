/*
-- prepare

sp_configure 'show advanced options', 1;
go
reconfigure
go

sp_configure 'Ole Automation Procedures', 1;
go
reconfigure
go

*/

/*
-- check

exec sp_configure 'Ole Automation Procedures';
go

*/

declare
	@content varbinary(max),
	@ObjectToken int

select
	@content = asm_files.content
from
	sys.assemblies asm
	join sys.assembly_files asm_files on asm_files.assembly_id = asm.assembly_id
where
	asm.name = N'System.Drawing'

exec sp_OACreate 'ADODB.Stream', @ObjectToken output
exec sp_OASetProperty @ObjectToken, 'Type', 1
exec sp_OAMethod @ObjectToken, 'Open'
exec sp_OAMethod @ObjectToken, 'Write', NULL, @content
exec sp_OAMethod @ObjectToken, 'SaveToFile', NULL, 'd:\System.Drawing.dll', 2
exec sp_OAMethod @ObjectToken, 'Close'
exec sp_OADestroy @ObjectToken
