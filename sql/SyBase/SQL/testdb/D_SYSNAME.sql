use testdb
go

if exists (select 1
           from systypes
           where
             name='D_SYSNAME')
   execute sp_droptype D_SYSNAME
go

exec sp_addtype D_SYSNAME, "varchar(30)", "not null"
go
