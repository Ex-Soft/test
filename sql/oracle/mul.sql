create or replace function mul (a number, b number)
return number
as
  result number := 0;
begin
  result:=a*b;
  return (result);
end;
