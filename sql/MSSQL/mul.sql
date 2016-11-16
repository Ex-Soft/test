use testdb
go

if object_id(N'mul', N'fn') is not null
  drop function mul
go

create function mul (@a int, @b int)
returns int
as
begin
  declare
    @result int

  set @result=@a*@b

  return @result
end
go