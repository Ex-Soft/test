create or replace procedure tablevictimisave (a tablevictimi.id%TYPE, b tablevictimi.val%TYPE, c tablevictimi.cmt%TYPE, d out tablevictimi.id%TYPE)
as
begin
  d:=a+b;
  insert into tablevictimi
  (id, val, cmt)
  values
  (a, b, c);
end;
