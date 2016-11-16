declare
  cursor cur is select * from TestTable4Cursor for update;
  ToDo int;
begin
  delete from TestTable4Cursor;

  insert into TestTable4Cursor (Id, Val) values (1, 10);
  insert into TestTable4Cursor (Id, Val) values (2, 5);
  insert into TestTable4Cursor (Id, Val) values (3, 0);

  for rec in cur
    loop
      dbms_output.put_line(to_char(rec.id)||' '||to_char(rec.val));
      update TestTable4Cursor set val=val-5 where current of cur;
    end loop;

  delete from
    TestTable4Cursor
  where
    (val<=0);

  select
    count(*)
  into
    ToDo
  from
    TestTable4Cursor;

  dbms_output.put_line('Count: '||to_char(ToDo));

  for rec in cur
    loop
      dbms_output.put_line(to_char(rec.id)||' '||to_char(rec.val));
    end loop;
end;
