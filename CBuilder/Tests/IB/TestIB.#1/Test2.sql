set names WIN1251;

connect "E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\TEST.GDB" user "sysdba" password "masterkey";

set term ^;

create procedure "sp_Staff"
returns (ID smallint, Name varchar(256))
as
begin
  for
    select
      "ID",
      "Name"
    from "Staff"
    into
      :ID,
      :Name
  do
  begin
    suspend;
  end
end
^

set term ;^