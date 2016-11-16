create table TestMaster
(
   Id int identity constraint "pkTestMaster" primary key,
   Val varchar(255)
)
go

create trigger trTestMaster
on TestMaster
for insert
as
begin
  insert into TestDetail
  (
    IdMaster,
    Val
  )
  select
    Id,
    'from trigger'
  from
    inserted
end
go
