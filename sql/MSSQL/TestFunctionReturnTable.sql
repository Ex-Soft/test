/* http://stackoverflow.com/questions/586642/tsql-how-do-you-output-print-in-a-user-defined-function */
use pretensions
go

if object_id('TestFunctionReturnTable', 'TF') is not null
  drop function TestFunctionReturnTable
go

create function TestFunctionReturnTable()
returns @t table(dt datetime)
as
begin
  insert into @t values ('20101203')
  return
end
go

select * from TestFunctionReturnTable()
go