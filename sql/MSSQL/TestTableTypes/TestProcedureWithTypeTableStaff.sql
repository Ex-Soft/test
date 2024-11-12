if object_id('dbo.TestProcedureWithTypeTableStaff', 'p') is not null
  drop procedure dbo.TestProcedureWithTypeTableStaff;
go

create procedure dbo.TestProcedureWithTypeTableStaff
  @Staff dbo.TypeTableStaff readonly
as
begin

  set nocount on;

  select
    s.*
  from
    dbo.Staff s
    join @Staff ps on (ps.id = s.id);
end;
go

declare @t dbo.TypeTableStaff;
insert into @t
	(ID, [NAME])
select
	ID, [NAME]
from
(
	values
		(1, null),
		(3, null)
) t(ID, [NAME]);
select * from @t;

declare @return_value int;
exec @return_value = dbo.TestProcedureWithTypeTableStaff @Staff = @t;
