create or replace procedure Test_SimpleProcedure (a number, b number, c out number)
as
begin
  c:=a+b;
end;
