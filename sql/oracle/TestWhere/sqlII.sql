------------------------------------------------------------
begin
  dbms_output.put_line(TestPackage.l_num);
end;

begin
  TestPackage.l_num := 0;
  dbms_output.put_line(TestPackage.l_num);
end;
------------------------------------------------------------

select
  'a'
from
  dual
where
  TestPackage.GetNum()>0 or TestPackage.GetNum()>0;

1
------------------------------------------------------------

select
  'a'
from
  dual
where
  TestPackage.GetNum()<0 or TestPackage.GetNum()>0;

2
------------------------------------------------------------

select
  case
    when TestPackage.GetNum()<>0
      then TestPackage.GetNum()
      else TestPackage.GetNum()
  end
from
  dual;

1
------------------------------------------------------------

select
  case
    when TestPackage.GetNum()<>0
      then TestPackage.GetNum()
      else TestPackage.GetNum()
  end,
  'a'
from
  dual
group by
  case
    when TestPackage.GetNum()<>0
      then TestPackage.GetNum()
      else TestPackage.GetNum()
  end;

1
------------------------------------------------------------