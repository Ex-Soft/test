create or replace procedure tablewithsequencesave (id_cur tablewithsequence.id%TYPE, val_new tablewithsequence.val%TYPE, id_new out tablewithsequence.id%TYPE)
as
begin
  update
    tablewithsequence
  set
    val=val_new
  where
    (id=id_cur);

  if (sql%notfound) then
    begin
      insert into tablewithsequence (val) values (val_new) returning id into id_new;
      dbms_output.put_line('insert (new Id: '||to_char(id_new)||')');
    end;
  else
    begin
      id_new:=id_cur;
      dbms_output.put_line('update (Id: '||to_char(id_cur)||')');
    end;
  end if;
end;

create or replace procedure tablewithsequencesave (id_cur tablewithsequence.id%TYPE, val_new tablewithsequence.val%TYPE, id_new out tablewithsequence.id%TYPE)
as
begin
  insert into tablewithsequence (id, val) values (id_cur, val_new) returning id into id_new;
  dbms_output.put_line('insert (new Id: '||to_char(id_new)||')');

  exception
    when dup_val_on_index then
      dbms_output.put_line('dup_val_on_index exception -> update (Id: '||to_char(id_cur)||')');
      update
        tablewithsequence
      set
        val=val_new
      where
        (id=id_cur);
      id_new:=id_cur;
    when others then
      dbms_output.put_line('others');
      dbms_output.put_line('sqlerrm: '||sqlerrm);
      dbms_output.put_line('sqlcode: '||sqlcode);
end;

create or replace procedure tablewithsequencesave (id_cur tablewithsequence.id%TYPE, val_new tablewithsequence.val%TYPE, id_new out tablewithsequence.id%TYPE)
as
begin
  merge into tablewithsequence t
  using dual on (t.id=id_cur)
  when matched then
    update set t.val=val_new
  when not matched then
    insert (val) values (val_new);
end;

create or replace procedure tablewithsequencesave (id_cur tablewithsequence.id%TYPE, val_new tablewithsequence.val%TYPE, id_new out tablewithsequence.id%TYPE)
as
begin
  insert into tablewithsequence (val) values (val_new) returning id into id_new;
end;

create or replace procedure tablewithsequencesave (id_cur number, val_new number, id_new out number)
as
begin
  insert into tablewithsequence (val) values (val_new) returning id into id_new;
end;

create or replace procedure tablewithsequencesave (id_cur number, val_new number, id_new out number)
as
begin
  insert into tablewithsequence (val) values (val_new);
end;

create or replace procedure tablewithsequencesave (id_cur number, val_new number, id_new out number)
as
begin
  id_new:=id_cur+val_new;
end;
