declare
  e tbl_app_clients.e_mail%type;
begin
  select
    e_mail
  into
    e
  from
    tbl_app_clients
  where
    id=1;

  if sql%found then
    begin
      dbms_output.put_line('Exists!');
      dbms_output.put_line('e-Mail: '||e);
    end;
  end if;

  if sql%notfound then
    dbms_output.put_line('Doesn''t exist! (sql%notfound)');
  end if;

  exception
    when no_data_found then
      dbms_output.put_line('Doesn''t exist! (exception no_data_found)'); /* !!! */
    when too_many_rows then
      dbms_output.put_line('You tried to execute a SELECT INTO statement and more than one row was returned.! (exception too_many_rows)'); /* !!! */
    when others then
      dbms_output.put_line('others');
      dbms_output.put_line('sqlerrm: '||sqlerrm);
      dbms_output.put_line('sqlcode: '||sqlcode);
end;

------------------------------------------------------------

declare
  e tbl_app_clients.e_mail%type;
begin
  
  begin
    select
      e_mail
    into
      e
    from
      tbl_app_clients
    where
      id=-1;

    if sql%found then
      begin
        dbms_output.put_line('Exists!');
        dbms_output.put_line('e-Mail: '||e);
      end;
    end if;

    if sql%notfound then
      dbms_output.put_line('Doesn''t exist! (sql%notfound)');
    end if;

    exception
      when no_data_found then
        dbms_output.put_line('Doesn''t exist! (exception no_data_found)'); /* !!! */
      when too_many_rows then
        dbms_output.put_line('You tried to execute a SELECT INTO statement and more than one row was returned.! (exception too_many_rows)'); /* !!! */
      when others then
        dbms_output.put_line('others');
        dbms_output.put_line('sqlerrm: '||sqlerrm);
        dbms_output.put_line('sqlcode: '||sqlcode);
  end;
  
  select
    e_mail
  into
    e
  from
    tbl_app_clients
  where
    id=1;

  if sql%found then
    begin
      dbms_output.put_line('Exists!');
      dbms_output.put_line('e-Mail: '||e);
    end;
  end if;

  if sql%notfound then
    dbms_output.put_line('Doesn''t exist! (sql%notfound)');
  end if;

  exception
    when no_data_found then
      dbms_output.put_line('Doesn''t exist! (exception no_data_found)'); /* !!! */
    when too_many_rows then
      dbms_output.put_line('You tried to execute a SELECT INTO statement and more than one row was returned.! (exception too_many_rows)'); /* !!! */
    when others then
      dbms_output.put_line('others');
      dbms_output.put_line('sqlerrm: '||sqlerrm);
      dbms_output.put_line('sqlcode: '||sqlcode);
end;