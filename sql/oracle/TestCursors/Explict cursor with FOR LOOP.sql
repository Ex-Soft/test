declare
  cursor tbl_app_clients_cursor is
  select
    e_mail
  from
    tbl_app_clients;
begin
  for rec in tbl_app_clients_cursor
    loop
      dbms_output.put_line(rec.e_mail);
    end loop;
end;