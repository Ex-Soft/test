set names WIN1251;

connect "E:\Soft.src\CBuilder\Tests\IB\TestIB.#1\TEST.GDB" user "sysdba" password "masterkey";

set term ^;

create procedure "sp_Staff_Dep"
(
   Depart int
)
returns
(
   ID smallint,
   Name varchar(256),
   Salary numeric(18,0),
   Dep int
)
as
begin
  for
    select
      "ID",
      "Name",
      "Salary",
      "Dep"
    from
      "Staff"
    where
      "Dep"=:Depart
    order by "Salary" desc
    into
      :ID,
      :Name,
      :Salary,
      :Dep
  do
  begin
    suspend;
  end
end
^

set term ;^