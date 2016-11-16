create or replace procedure TestProcedureWithException
as
  tmpVarchar2 varchar2(1) := '';
begin
  begin
    dbms_output.put_line('#1');

    select dummy into tmpVarchar2 from dual where 1=2;

    if sql%found then
      dbms_output.put_line('sql%found');
    end if;

    if sql%notfound then
      dbms_output.put_line('sql%notfound');
    end if;

    exception
      when no_data_found then
        dbms_output.put_line('no_data_found');
      when others then
        dbms_output.put_line('others');
        dbms_output.put_line('sqlerrm: '||sqlerrm);
        dbms_output.put_line('sqlcode: '||sqlcode); 
  end;

  begin
    dbms_output.put_line('#2');

    select dummy into tmpVarchar2 from dual where 1=2;

    if sql%found then
      dbms_output.put_line('sql%found');
    end if;

    if sql%notfound then
      dbms_output.put_line('sql%notfound');
    end if;

    exception
      when no_data_found then
        dbms_output.put_line('no_data_found');
      when others then
        dbms_output.put_line('others');
        dbms_output.put_line('sqlerrm: '||sqlerrm);
        dbms_output.put_line('sqlcode: '||sqlcode); 
  end;
end;

