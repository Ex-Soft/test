create or replace function FunctionWOutput (arg nvarchar2)
return int
as
begin
  dbms_output.put_line(arg);
  return 1;
end;
