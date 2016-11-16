select
  depno,
  job,
  sum(sal) as sum_sal
from
  TestTableForOver
group by depno, job;

select
  depno,
  job,
  SUM(sal) OVER (PARTITION BY depno order by job) sum_sal   
from
  TestTableForOver;