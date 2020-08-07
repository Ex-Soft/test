
create function TestFunctionReturnTable()
returns @t table(dt datetime)
as
begin
  insert into @t values ('20101203')
  return
end
