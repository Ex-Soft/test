select
  'a'
from
  dual
where
  FunctionWOutput('1st')=1 or FunctionWOutput('2nd')=1;

Output: 1st
------------------------------------------------------------

select
  'a'
from
  dual
where
  FunctionWOutput('1st')=0 or FunctionWOutput('2nd')=1;

Output: 1st 2nd
------------------------------------------------------------

select
  'a'
from
  dual
where
  FunctionWOutput('1st')=1 or (1 in (select 1 from dual where FunctionWOutput('2nd')=1));

Output: 1st
------------------------------------------------------------

select
  'a'
from
  dual
where
  FunctionWOutput('1st')=0 or (1 in (select 1 from dual where FunctionWOutput('2nd')=1));

Output: 1st 2nd
------------------------------------------------------------

select
  t.*
from
  test t
where
  FunctionWOutput('1st')=t.columnid or (t.columnid in (select 1 from dual where FunctionWOutput('2nd')=1));
1st
2nd
1st
1st
2nd
1st
2nd
------------------------------------------------------------

select
  FunctionWOutput('select')
from
  test
where
  FunctionWOutput('where')=1;

where
select
select
select
select
------------------------------------------------------------

select
  case
    when FunctionWOutput('when# 1')=1 then FunctionWOutput('then# 1')
    when FunctionWOutput('when# 2')=2 then FunctionWOutput('then# 2')
  end
from
  test;

when# 1
then# 1
when# 1
then# 1
when# 1
then# 1
when# 1
then# 1
------------------------------------------------------------

select
  case
    when FunctionWOutputND ('when# 1', columnid)<>0
      then FunctionWOutputND ('then# 1', columnid)
      else FunctionWOutputND ('else# 1', columnid)
  end as res,
  case
    when FunctionWOutputND ('when# 2', columnid)<>0
      then FunctionWOutputND ('then# 2', columnid)
      else FunctionWOutputND ('else# 2', columnid)
  end * columnid as resres
from
  test;

when# 1
then# 1
when# 2
then# 2
when# 1
then# 1
when# 2
then# 2
when# 1
then# 1
when# 2
then# 2
when# 1
then# 1
when# 2
then# 2
------------------------------------------------------------

select
  coalesce(nullif(FunctionWOutputND('coalesce# 1.1', columnid),0), FunctionWOutputND('coalesce# 1.2', columnid)) as res,
  coalesce(nullif(FunctionWOutputND('coalesce# 2.1', columnid),0), FunctionWOutputND('coalesce# 2.2', columnid)) * columnid as resres
from
  test;

coalesce# 1.1
coalesce# 1.1
coalesce# 2.1
coalesce# 2.1
coalesce# 1.1
coalesce# 1.1
coalesce# 2.1
coalesce# 2.1
coalesce# 1.1
coalesce# 1.1
coalesce# 2.1
coalesce# 2.1
coalesce# 1.1
coalesce# 1.1
coalesce# 2.1
coalesce# 2.1
------------------------------------------------------------

select
  coalesce(nullif(FunctionWOutputND('coalesce(nullif(FunctionWOutputND))',0),0), FunctionWOutputND('FunctionWOutputND# 2',0))
from
  dual;

coalesce(nullif(FunctionWOutputND))
coalesce(nullif(FunctionWOutputND))
------------------------------------------------------------

select
  coalesce(nullif(FunctionWOutputND('coalesce(nullif(FunctionWOutputND))',-1),0), FunctionWOutputND('FunctionWOutputND# 2',0))
from
  dual;

coalesce(nullif(FunctionWOutputND))
FunctionWOutputND# 2
------------------------------------------------------------