declare
  a nvarchar2(1024) := '';
  l smallint;
begin
  select length(a) into l from dual;
  dbms_output.put_line('length(a)='||to_char(l));
  
  if a is null then
    dbms_output.put_line('a is null');
  end if;
  
  if a='' then
    dbms_output.put_line('a=''''');
  end if;

  if a<>'' then
    dbms_output.put_line('a<>''''');
  end if;

  a := 'blah-blah-blah';
  select length(a) into l from dual;
  dbms_output.put_line('length(a)='||to_char(l));
  
  if a is null then
    dbms_output.put_line('a is null');
  end if;
  
  if a='' then
    dbms_output.put_line('a=''''');
  end if;

  if a<>'' then
    dbms_output.put_line('a<>''''');
  end if;
  
  if a<>' ' then
    dbms_output.put_line('a<>'' ''');
  end if;

  if a is not null then
    dbms_output.put_line('a is not null');
  end if;
end;
