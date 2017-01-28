use testdb
go

if exists (select
             1
           from
             sysobjects
           where
             id=object_id('FunctionSalary')
             and type = 'SF')
  drop function FunctionSalary
go

create function FunctionSalary(@ID smallint)
returns money
as
begin
  declare
    @Salary money

  select
    @Salary=Salary
  from
    Staff
  where
    ID=@ID

  return(@Salary)
end
go
