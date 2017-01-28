use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_MaxFromEmptyTable')
            and    type = 'P')
   drop procedure sp_MaxFromEmptyTable
go

create procedure sp_MaxFromEmptyTable
  @MaxId numeric(18,0) output
as 
begin
  select @MaxId=max(Id) from EmptyTable
end
go
