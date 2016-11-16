declare
  e tbl_app_clients.e_mail%type;
  
  cursor tbl_app_clients_cursor is
  select
    e_mail
  from
    tbl_app_clients;
begin
  open tbl_app_clients_cursor;
  
  fetch tbl_app_clients_cursor into e;
  while tbl_app_clients_cursor%found
    loop
      dbms_output.put_line(e);      
      fetch tbl_app_clients_cursor into e;
    end loop;

  close tbl_app_clients_cursor;
end;
