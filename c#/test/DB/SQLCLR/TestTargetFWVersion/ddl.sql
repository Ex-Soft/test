create database TestTargetFWVersion on (name = TestTargetFWVersion, filename = N'd:\db\TestTargetFWVersion.mdf') log on (name = TestTargetFWVersion_log, filename = 'd:\db\TestTargetFWVersion_log.ldf');
go

use TestTargetFWVersion
go

sp_configure 'clr enabled', 1
go

reconfigure with override  
go

alter database TestTargetFWVersion set trustworthy on
go
