if object_id('TestTableValuedFunctionI', N'TF') is not null
  drop function TestTableValuedFunctionI
go

create function TestTableValuedFunctionI(@a bit)
returns @t table(FInt int)
as
begin
  if @a=1
    begin
      insert into @t values (1)
      insert into @t values (3)
      insert into @t values (5)
    end
  else
    begin
      insert into @t values (2)
      insert into @t values (4)
    end

  return
end
go
