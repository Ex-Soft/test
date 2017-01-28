use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestNotExists')
            and    type = 'U')
   drop table TestNotExists
go

create table TestNotExists
(
   Id numeric(18,0) not null,
   Val varchar(256) not null   
) lock datarows
go 

select value
from table t1 
where not exists (select * 
                  from table t2 
                  where t1.value=t2.value and t2.number=1)

select distinct(value) 
from table1 
where value not in (select value from table1 where number=1)

select distinct
  Val
from
  TestNotExists T
where
  (select count(*) from TestNotExists where Id=1 and Val=T.Val)=0