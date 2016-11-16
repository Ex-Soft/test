create or replace procedure testprocedureparameters (p_varchar2 varchar2, p_nvarchar2 nvarchar2)
as
begin
  if p_varchar2 is null then
    dbms_output.put_line('p_varchar2 is null');
  end if;

  if length(p_varchar2)=0 then
    dbms_output.put_line('length(p_varchar2)=0');
  end if;

  if p_nvarchar2 is null then
    dbms_output.put_line('p_nvarchar2 is null');
  end if;

  if length(p_nvarchar2)=0 then
    dbms_output.put_line('length(p_nvarchar2)=0');
  end if;
end;
