if object_id('TestProcedureWithXmlTypeParameter', 'p') is not null
  drop procedure TestProcedureWithXmlTypeParameter
go

create procedure TestProcedureWithXmlTypeParameter
  @StaffIds xml
as
begin

  set nocount on

  select
    s.*
  from
    Staff s
    join @StaffIds.nodes('root/*') as n(v) on (v.value('.','int')=s.ID)
end
go