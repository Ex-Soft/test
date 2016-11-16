use testdb
go

if object_id(N'TestTableWithIndexesII', N'u') is not null
  drop table TestTableWithIndexesII
go

create table TestTableWithIndexesII
(
   Id int not null identity constraint pkTestTableWithIndexesII primary key,
   Field1 int null,
   Field2 int null
)
go

/*
if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id('Staff')
                 and name='Dep')
  alter table Staff add Dep int null
else
  print 'Staff.Dep already exists!!!'
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id('Staff')
                 and name='BirthDate')
  alter table Staff add BirthDate datetime null
else
  print 'Staff.BirthDate already exists!!!'
go

if not exists (select 1
               from
                 syscolumns
               where
                 id = object_id('Staff')
                 and name='NullField')
  alter table Staff add NullField numeric(18,0) null
else
  print 'Staff.BirthDate already exists!!!'
go
*/