select ttga.*, t.* from typhoon.tbl_goods_all ttga, TestTableForTestWhereJoin t where (t.id=ttga.g_id)

SELECT STATEMENT, GOAL = CHOOSE			22	408151	165301155
 NESTED LOOPS			22	408151	165301155
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	82	11726
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from typhoon.tbl_goods_all ttga, TestTableForTestWhereJoin t where (ttga.g_id=t.id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from TestTableForTestWhereJoin t, typhoon.tbl_goods_all ttga where (t.id=ttga.g_id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from TestTableForTestWhereJoin t, typhoon.tbl_goods_all ttga where (ttga.g_id=t.id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from typhoon.tbl_goods_all ttga join TestTableForTestWhereJoin t on (t.id=ttga.g_id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from typhoon.tbl_goods_all ttga join TestTableForTestWhereJoin t on (ttga.g_id=t.id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from TestTableForTestWhereJoin t join typhoon.tbl_goods_all ttga on (ttga.g_id=t.id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	

select ttga.*, t.* from TestTableForTestWhereJoin t join typhoon.tbl_goods_all ttga on (t.id=ttga.g_id)

SELECT STATEMENT, GOAL = CHOOSE			104	2035777	824489685
 NESTED LOOPS			104	2035777	824489685
  TABLE ACCESS FULL	ASPNETUSER	TESTTABLEFORTESTWHEREJOIN	1	409	58487
  TABLE ACCESS BY INDEX ROWID	TYPHOON	TBL_GOODS_ALL	1	4977	1303974
   INDEX UNIQUE SCAN	TYPHOON	TBL_GOODS_PK2986050385647	1	1	
