create or replace function FunctionWOutputND (arg nvarchar2, par number)
return int
as
  r int := 0;
begin
  dbms_output.put_line(arg);
  select count(*) into r from test where columnid = par;
  return r;
end;
