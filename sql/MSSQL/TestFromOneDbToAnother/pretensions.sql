sp_adduser @loginame='TestIgor', @name_in_db='TestIgor'
go

grant insert, update, delete, select on TestMaster to TestIgor
go

sp_dropuser @name_in_db='TestIgor'
go
