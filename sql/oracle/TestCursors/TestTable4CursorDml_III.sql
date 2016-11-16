declare
  cursor cur is select * from TestTable4Cursor;
begin
  delete from TestTable4Cursor;

  insert into TestTable4Cursor (Id, Val) values (1, 10);
  insert into TestTable4Cursor (Id, Val) values (2, 5);
  insert into TestTable4Cursor (Id, Val) values (3, 0);
  insert into TestTable4Cursor (Id, Val) values (4, -5);
  insert into TestTable4Cursor (Id, Val) values (5, -10);

  for rec in cur
    loop
      if rec.val<0 then
        exit;
      end if;

      dbms_output.put_line(to_char(rec.id)||' '||to_char(rec.val));
    end loop;
end;
