use testdb
go

if exists (select 1
           from systypes
           where
             name='D_Staff_Name')
   execute sp_droptype D_Staff_Name
go

exec sp_addtype D_Staff_Name, "varchar(50)", "null"
go
