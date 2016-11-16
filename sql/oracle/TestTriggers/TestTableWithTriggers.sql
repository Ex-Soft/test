create table TestTableWithTriggers
(
   Id number not null constraint pk_TestTableWithTriggers primary key,
   Val number
);

create or replace trigger tr_biud_TestTableWithTriggers
before insert or update or delete
on TestTableWithTriggers
begin
  if inserting then
    dbms_output.put_line('tr_biud_TestTableWithTriggers: inserting');
  elsif updating then
    dbms_output.put_line('tr_biud_TestTableWithTriggers: updating');
  elsif deleting then
    dbms_output.put_line('tr_biud_TestTableWithTriggers: deleting');
  end if;
end;

create or replace trigger tr_biudr_TestTableWithTriggers
before insert or update or delete
on TestTableWithTriggers
for each row
begin
  if inserting then
    dbms_output.put_line('tr_biudr_TestTableWithTriggers: inserting');
  elsif updating then
    dbms_output.put_line('tr_biudr_TestTableWithTriggers: updating');
  elsif deleting then
    dbms_output.put_line('tr_biudr_TestTableWithTriggers: deleting');
  end if;

  if :old.Val is null then
    dbms_output.put_line(':old.Val is null');
  else
    dbms_output.put_line(':old.Val='||to_char(:old.Val));
  end if;

  if :new.Val is null then
    dbms_output.put_line(':new.Val is null');
  else
    dbms_output.put_line(':new.Val='||to_char(:new.Val));
  end if;
end;

create or replace trigger tr_aiudr_TestTableWithTriggers
after insert or update or delete
on TestTableWithTriggers
for each row
begin
  if inserting then
    dbms_output.put_line('tr_aiudr_TestTableWithTriggers: inserting');
  elsif updating then
    dbms_output.put_line('tr_aiudr_TestTableWithTriggers: updating');
  elsif deleting then
    dbms_output.put_line('tr_aiudr_TestTableWithTriggers: deleting');
  end if;

  if :old.Val is null then
    dbms_output.put_line(':old.Val is null');
  else
    dbms_output.put_line(':old.Val='||to_char(:old.Val));
  end if;

  if :new.Val is null then
    dbms_output.put_line(':new.Val is null');
  else
    dbms_output.put_line(':new.Val='||to_char(:new.Val));
  end if;
end;

create or replace trigger tr_aiud_TestTableWithTriggers
after insert or update or delete
on TestTableWithTriggers
begin
  if inserting then
    dbms_output.put_line('tr_aiud_TestTableWithTriggers: inserting');
  elsif updating then
    dbms_output.put_line('tr_aiud_TestTableWithTriggers: updating');
  elsif deleting then
    dbms_output.put_line('tr_aiud_TestTableWithTriggers: deleting');
  end if;
end;

