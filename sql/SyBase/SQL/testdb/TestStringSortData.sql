delete from TestStringSort
go

insert into TestStringSort (Val) values ('1')
insert into TestStringSort (Val) values ('2')
insert into TestStringSort (Val) values ('3')
insert into TestStringSort (Val) values ('1.1')
insert into TestStringSort (Val) values ('1.2')
insert into TestStringSort (Val) values ('1.3')
insert into TestStringSort (Val) values ('2.1')
insert into TestStringSort (Val) values ('2.2')
insert into TestStringSort (Val) values ('2.3')
insert into TestStringSort (Val) values ('3.1')
insert into TestStringSort (Val) values ('1.1.1')
insert into TestStringSort (Val) values ('1.2.1')
insert into TestStringSort (Val) values ('1.3.1')
insert into TestStringSort (Val) values ('2.1.1')
insert into TestStringSort (Val) values ('2.2.1')
insert into TestStringSort (Val) values ('2.3.1')
insert into TestStringSort (Val) values ('1.1.1.1')
go

select
  *
from
  TestStringSort
order by Val