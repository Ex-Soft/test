/*
BDE -

select
c.contragent_name,
(select count(cai.contragent_id) from "E:\Soft.src\CBuilder\Tests\DBF\details.db" cai where (cai.contragent_id=c.contragent_id)) as cnt
from "E:\Soft.src\CBuilder\Tests\DBF\master.db" c

*/

/*
BDE +
*/

select
c.contragent_name,
count(cai.contragent_id)
from "E:\Soft.src\CBuilder\Tests\DBF\master.db" c 
left outer join "E:\Soft.src\CBuilder\Tests\DBF\details.db" cai on (cai.contragent_id=c.contragent_id)
group by c.contragent_name
