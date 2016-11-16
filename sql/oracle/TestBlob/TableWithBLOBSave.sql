create or replace procedure tablewithblobsave (id_in tablewithblob.id%TYPE, fblob_in tablewithblob.fblob%TYPE)
as
begin
  update
    tablewithblob
  set
    fblob=fblob_in
  where
    (id=id_in);

  if (sql%notfound) then
    insert into tablewithblob (id, fblob) values (id_in, fblob_in);
  end if;
end;
