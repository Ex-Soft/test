insert into tablewithsequence (val) values (6161);
insert into tablewithsequence (id, val) values (61,6161);
insert into tablewithsequence (id, val) values (s_tablewithsequence.nextval, 1);

declare
  id_new number;
  val_new number;
begin
  id_new:=0;
  val_new:=13;
  insert into tablewithsequence (val) values (val_new) returning id into id_new;
  dbms_output.put_line('sqlerrm: '||sqlerrm);
  dbms_output.put_line('sqlcode: '||sqlcode);
  commit;
  if (id_new<>0) then
    dbms_output.put_line('New Id: '||to_char(id_new));
  end if;
end;
