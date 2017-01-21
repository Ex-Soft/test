set names WIN1251;

connect "E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\TEST.GDB" user "sysdba" password "masterkey";

set term ^;

create procedure "Stub"
as
  declare variable x int;
begin
  x=1;
end
^

set term ;^