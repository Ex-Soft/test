/*
Alias: WORK
LiveAnswer: FALSE

*/

select
  M.Id,
  M."Value",
  sum(D.FNumeric) as SumNumeric
from
  'E:\Soft.src\CBuilder\Tests\Paradox\Test.#1\db\master.db' as M
  join 'E:\Soft.src\CBuilder\Tests\Paradox\Test.#1\db\details.db' as D on (D.MasterId=M.Id)
group by
  M.Id,
  M."Value"
order by
  M.Id
