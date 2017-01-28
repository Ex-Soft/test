use testdb
go

if exists (select 1
           from systypes
           where
             name='D_NUMERIC18_0')
   execute sp_droptype D_NUMERIC18_0
go

execute sp_addtype D_NUMERIC18_0, "numeric(18,0)", "null"
go
