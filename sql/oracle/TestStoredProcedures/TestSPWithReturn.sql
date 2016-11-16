create or replace procedure TestSPWithReturn (a number)
is
begin
  if a is null then
    return;
  end if;

  dbms_output.put_line(to_char(a));
end;
