use testdb
go

if object_id(N'TestFunction4Apply', N'tf') is not null
  drop function TestFunction4Apply
go

create function TestFunction4Apply(@val int)
returns @t table
(
   Id int not null primary key,
   Field1 int null,
   Field2 int null
)
as
begin
  insert into @t
  (
    Id,
    Field1,
    Field2
  )
  select
    Id,
    Field1,
    Field2
  from
    TestTable4ApplyII
  where
    Field1=@val

  return
end
go
