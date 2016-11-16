create procedure Test_Procedure (cur out sys_refcursor, arg number)
as
begin
  insert into Victim
  (Id, Val)
  values
  (arg, arg);
  
  open cur for
    select * from dual;
end;

select * from victim;

declare
  cc sys_refcursor;

begin Test_Procedure(cc,33); close cc; end;

select * from victim;