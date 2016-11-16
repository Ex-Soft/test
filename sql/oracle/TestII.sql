/*
drop table TestII;
*/
/*
create table TestII
(Id number(*,0) not null constraint pkTestII primary key,
 Val varchar(255)
);
*/
/*
create sequence SequenceTestII
start with 1
increment by 1;
*/
/*
create or replace trigger TriggerTestII
before insert
on TestII
referencing new as new
for each row
  begin
    select SequenceTestII.Nextval into :new.Id from dual;
  end;
*/

insert into TestII (Val) values ('Val 3');

select
  *
from
  TestII;
