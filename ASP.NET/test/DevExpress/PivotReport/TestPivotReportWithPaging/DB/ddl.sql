if db_id(N'TestDEPivotGrid') is not null
	drop database TestDEPivotGrid

if db_id(N'TestDEPivotGrid') is null
	create database TestDEPivotGrid on (name = N'TestDEPivotGrid', filename = N'd:\db\TestDEPivotGrid.mdf') log on (name = N'TestDEPivotGrid_log', filename = N'd:\db\TestDEPivotGrid_log.ldf')

use TestDEPivotGrid
go

if object_id(N'Data4TestDEPivotGrid', N'u') is not null
	drop table Data4TestDEPivotGrid

if object_id(N'Data4TestDEPivotGrid', N'u') is null
	create table Data4TestDEPivotGrid
	(
		id bigint constraint notnullData4TestDEPivotGrid not null identity constraint pkData4TestDEPivotGrid primary key,
		[year] smallint,
		[quarter] tinyint,
		[month] tinyint,
		[day] tinyint,
		name nvarchar(255),
		[value] money
	)
