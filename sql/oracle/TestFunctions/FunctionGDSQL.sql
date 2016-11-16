create or replace function FunctionGDSQL
return varchar2
as
  sqltext varchar2(4000);
begin
  sqltext := 'select * from test';
  return sqltext;
end;
