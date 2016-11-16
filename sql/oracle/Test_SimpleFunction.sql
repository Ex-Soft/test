create or replace function Test_SimpleFunction (a number, b number, c out number)
return number
as
  result number := 0;
begin
  c:=a+b;
  result:=c;
  return (result);
end;
