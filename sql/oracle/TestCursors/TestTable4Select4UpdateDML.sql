declare
  cursor cur is select
                  *
                from
                  TestTable4Select4Update
                where
                  (SmthId=1)
                for update;
begin
  delete from TestTable4Select4Update;

  insert into TestTable4Select4Update (Id, SmthId, Val) values (1, 1, 1);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (2, 1, 2);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (3, 1, 3);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (4, 1, 4);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (5, 1, 5);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (6, 2, 1);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (7, 2, 2);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (8, 2, 3);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (9, 2, 4);
  insert into TestTable4Select4Update (Id, SmthId, Val) values (10, 2, 5);
  commit;

  for rec in cur
    loop
      dbms_output.put_line(to_char(rec.id)||' '||to_char(rec.smthid)||' '||to_char(rec.val));
      update TestTable4Select4Update set val=val-5 where current of cur;
      dbms_output.put_line(to_char(rec.id)||' '||to_char(rec.smthid)||' '||to_char(rec.val));
    end loop;
end;

update TestTable4Select4Update set val=1000 where (id=2) and (smthid=1);
commit;