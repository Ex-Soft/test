declare
  e tbl_app_clients.e_mail%type;
  
  cursor tbl_app_clients_cursor is
  select
    e_mail
  from
    tbl_app_clients;
begin
  if tbl_app_clients_cursor%isopen then
    dbms_output.put_line('cursor%isopen');
  else
    dbms_output.put_line('!cursor%isopen');
  end if;
  open tbl_app_clients_cursor;
  if tbl_app_clients_cursor%isopen then
    dbms_output.put_line('cursor%isopen');
  else
    dbms_output.put_line('!cursor%isopen');
  end if;
  
  fetch tbl_app_clients_cursor into e;
  dbms_output.put_line(e);

  fetch tbl_app_clients_cursor into e;
  dbms_output.put_line(e);

  fetch tbl_app_clients_cursor into e;
  dbms_output.put_line(e);

  if tbl_app_clients_cursor%isopen then
    dbms_output.put_line('cursor%isopen');
  else
    dbms_output.put_line('!cursor%isopen');
  end if;
  close tbl_app_clients_cursor;
    if tbl_app_clients_cursor%isopen then
    dbms_output.put_line('cursor%isopen');
  else
    dbms_output.put_line('!cursor%isopen');
  end if;
end;