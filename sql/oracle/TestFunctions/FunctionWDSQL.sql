create or replace function FunctionWDSQL
return sys_refcursor
as
  p_cursor sys_refcursor;
begin
  execute immediate 'alter session set cursor_sharing=force';
  open p_cursor for FunctionGDSQL();
  execute immediate 'alter session set cursor_sharing=exact';
  return p_cursor;
end;
