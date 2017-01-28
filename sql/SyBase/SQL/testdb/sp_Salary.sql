use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_Staff')
            and    type = 'P')
   drop procedure sp_Staff
go

create procedure sp_Staff
as 
begin
  select * from Staff order by ID
end
go
