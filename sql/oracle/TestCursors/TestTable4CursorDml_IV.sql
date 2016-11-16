begin
  update
    TestTable4Cursor
  set
    val=100
  where
    id=-1;

  if sql%found then
    dbms_output.put_line('sql%found');
  end if;

  if sql%notfound then
    dbms_output.put_line('sql%notfound');
  end if;
end;