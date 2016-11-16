create table TableSecondary
(
   Id number(*,0) constraint NotNullTableSecondaryId not null constraint pkTableSecondary primary key,
   Val varchar(255)
);

create or replace trigger tr_AU_TableSecondary
after update
on TableSecondary
referencing new as new
for each row
  begin
    dbms_output.put_line('tr_AU_TableSecondary');
  end;

insert into TableSecondary (Id, Val) values (1,'s1');
insert into TableSecondary (Id, Val) values (3,'s3');
insert into TableSecondary (Id, Val) values (5,'s5');
commit;

select
  *
from
  TableSecondary;
