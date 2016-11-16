if object_id(N'TestSetNoexecOnOff', N'p') is not null
	set noexec on;
go

create procedure TestSetNoexecOnOff
as
	set nocount on;
go

set noexec off;
go

alter procedure TestSetNoexecOnOff
as
begin
	set nocount on

	print N'TestSetNoexecOnOff'
end
go