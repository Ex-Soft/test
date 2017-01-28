use testdb
go

if exists (select 1
           from systypes
           where
             name='D_NUMERIC10_0')
   execute sp_droptype D_NUMERIC10_0
go

execute sp_addtype D_NUMERIC10_0, "numeric(10,0)", "null"
go
