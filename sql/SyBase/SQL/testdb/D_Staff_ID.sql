use testdb
go

if exists (select 1
           from systypes
           where
             name='D_Staff_ID')
   execute sp_droptype D_Staff_ID
go

exec sp_addtype D_Staff_ID, "smallint", "null"
go
