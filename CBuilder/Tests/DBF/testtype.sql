/*
Alias: WORK
LiveAnswer: FALSE

*/

select 
substring("141516" from 1 to 2)
from "D:\My_Doc\CBuilder\Tests\DBF\testtype.db"
/*
insert into "testtype.db"
(F_TIME)
values
(
cast(
	  (substring("141516" from 1 to 2)
	  || ':'
	  || substring("141516" from 3 to 2)
	  || ':'
	  || substring("141516" from 5 to 2)
	  )
	  as TIME
	 )
)
*/
/*insert into "D:\My_Doc\CBuilder\Tests\DBF\testtype.db" (F_DATE, F_TIME) values ('15.10.2004', cast("13:14:15" as TIME))*/
/*select cast(F_DATE as CHAR(10)) from "D:\My_Doc\CBuilder\Tests\DBF\testtype.db"*/
