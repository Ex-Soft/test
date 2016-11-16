declare
  e tbl_app_clients.e_mail%type;
  
  cursor tbl_app_clients_cursor is
  select
    e_mail
  from
    tbl_app_clients;
begin
  open tbl_app_clients_cursor;
  
  if tbl_app_clients_cursor%isopen then
    loop
      fetch tbl_app_clients_cursor into e;
      exit when tbl_app_clients_cursor%notfound;
      dbms_output.put_line(e);
    end loop;
  end if;

  close tbl_app_clients_cursor;
end;