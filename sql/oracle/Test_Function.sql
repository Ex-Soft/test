create function Test_Function (arg number)
return sys_refcursor
as
  cur sys_refcursor;
begin
  insert into Victim
  (Id, Val)
  values
  (arg, arg);
  
  open cur for
    select * from dual;
end;

declare
  cc sys_refcursor;

exec cc:=Test_Function(55); close cc;
http://www.oracle-base.com/forums/viewtopic.php?f=2&t=4782