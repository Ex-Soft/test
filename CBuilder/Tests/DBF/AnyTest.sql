/*
Alias: WORK
LiveAnswer: FALSE

*/

select
extract(month from FDate),
count(FChar)
from
"E:\Soft.src\CBuilder\Tests\DBF\AnyTest.db"
group by extract(month from FDate)
