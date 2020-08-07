
create procedure TestProcedureWithTypeTableStaff
  @Staff TypeTableStaff readonly
as
begin

  set nocount on

  select
    s.*
  from
    Staff s
    join @Staff ps on (ps.id=s.id) 
end
