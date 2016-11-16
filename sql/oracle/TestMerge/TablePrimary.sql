create table TablePrimary
(
   Id number(*,0) constraint NotNullTablePrimaryId not null constraint pkTablePrimary primary key,
   Val varchar(255)
);

insert into TablePrimary (Id, Val) values (1, 'p1');
insert into TablePrimary (Id, Val) values (2, 'p2');
insert into TablePrimary (Id, Val) values (3, 'p3');
insert into TablePrimary (Id, Val) values (4, 'p4');
insert into TablePrimary (Id, Val) values (5, 'p5');

select
  *
from
  TablePrimary;