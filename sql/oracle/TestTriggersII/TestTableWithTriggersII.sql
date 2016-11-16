create table TestTableWithTriggersII
(
   Id number not null constraint pk_TestTableWithTriggersII primary key,
   Val number
);

create or replace trigger tr_biur_TestTableWithTrII
before insert or update
on TestTableWithTriggersII
for each row
begin
  if :new.Val>10 then
    raise_application_error(-20000,to_char(:new.Val)||'>10');
  end if;
end;
