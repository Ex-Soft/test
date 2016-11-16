create sequence s_tablewithsequence
start with 1
increment by 1;

drop trigger tr_bi_tablewithsequence;
drop table tablewithsequence;

create table tablewithsequence
(
	id number not null constraint pk_tablewithsequence primary key,
	val number
);

create or replace trigger tr_bi_tablewithsequence
before insert
on tablewithsequence
for each row
  begin
    if ((:new.id is null) or (:new.id=0)) then
      select s_tablewithsequence.nextval into :new.id from dual;
    end if;
  end;
