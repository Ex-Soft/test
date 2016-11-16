use testdb
go

if object_id(N'Staff', N'u') is not null
  drop table Staff
go

create table Staff
(
   ID bigint not null identity constraint pkStaff primary key,
   Name nvarchar(255) null,
   Salary money null,
   Dep int null,
   BirthDate date null,
   NullField numeric(18,0) null
)
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'Staff')
                 and name=N'Dep')
  alter table Staff add Dep int null
else
  print N'Staff.Dep already exists!!!'
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'Staff')
                 and name=N'BirthDate')
  alter table Staff add BirthDate datetime null
else
  print N'Staff.BirthDate already exists!!!'
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id(N'Staff')
                 and name=N'NullField')
  alter table Staff add NullField numeric(18,0) null
else
  print N'Staff.NullField already exists!!!'
go

if not exists (select 1
               from
                 sys.columns
               where
                 object_id = object_id(N'Staff')
                 and name=N'NullField')
  alter table Staff add NullField numeric(18,0) null
else
  print N'Staff.NullField already exists!!!'
go
