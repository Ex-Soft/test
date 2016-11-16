create or replace package TestPackage
as
	l_num number := 0;
	function GetNum return number;
end;

create or replace package body TestPackage
as
	function GetNum
	return number
	as
	begin
		l_num := l_num + 1;
		return dbms_random.value();
	end;
end;

exec TestPackage.l_num := 0;

select
  TestPackage.GetNum(),
  count(*)
from
  dual
connect by
  level <= 10
group by TestPackage.GetNum();

//exec dbms_output.Enable(100);
//set serveroutput on;

exec dbms_output.put_line(TestPackage.l_num);

