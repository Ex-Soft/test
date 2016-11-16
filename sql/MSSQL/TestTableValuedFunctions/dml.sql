select
  *
from
  TestTable4TableValuedFunction
where
  Id in (select * from TestTableValuedFunctionI(1))
------------------------------------------------------------
select
  *
from
  TestTable4TableValuedFunction
where
  Id in (select * from TestTableValuedFunctionII(1))
------------------------------------------------------------
declare
  @t table (FInt int)

insert into @t select FInt from TestTableValuedFunctionI(1)

select
  t.*
from
  TestTable4TableValuedFunction t
  join @t tt on (tt.FInt=t.Id)
------------------------------------------------------------
declare
  @t table (FInt int)

insert into @t select FInt from TestTableValuedFunctionII(1)

select
  t.*
from
  TestTable4TableValuedFunction t
  join @t tt on (tt.FInt=t.Id)
------------------------------------------------------------
declare
  @t table (FInt int primary key)

insert into @t select FInt from TestTableValuedFunctionI(1)

select
  t.*
from
  TestTable4TableValuedFunction t
  join @t tt on (tt.FInt=t.Id)
------------------------------------------------------------
declare
  @t table (FInt int primary key)

insert into @t select FInt from TestTableValuedFunctionII(1)

select
  t.*
from
  TestTable4TableValuedFunction t
  join @t tt on (tt.FInt=t.Id)
------------------------------------------------------------
