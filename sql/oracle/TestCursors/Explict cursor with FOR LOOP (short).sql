begin
  for rec in (select * from tbl_app_clients)
    loop
      dbms_output.put_line(rec.e_mail);
    end loop;
end;