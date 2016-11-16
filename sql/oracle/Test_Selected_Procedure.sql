create or replace procedure Test_Selected_Procedure (arg number, cur out sys_refcursor)
as
begin
  open cur for
    select
      *
    from
      test
    where
      columnid<arg;
end;
