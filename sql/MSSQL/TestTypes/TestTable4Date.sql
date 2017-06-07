if object_id(N'TestTable4Date', N'u') is not null
	drop table TestTable4Date
go

create table TestTable4Date
(
	Id int not null constraint pkTestTable4Date primary key,
	FDate date null,
	FDateTime datetime null,
	FDateTime2 datetime2 null,
	FSmallDateTime smalldatetime null,
	FTime time null,
	FTime0 time(0) null,
	FTime1 time(1) null,
	FTime2 time(2) null,
	FTime3 time(3) null,
	FTime4 time(4) null,
	FTime5 time(5) null,
	FTime6 time(6) null,
	FTime7 time(7) null,
	FDateTimeOffset datetimeoffset null,
	FDateTimeOffset0 datetimeoffset(0) null,
	FDateTimeOffset1 datetimeoffset(1) null,
	FDateTimeOffset2 datetimeoffset(2) null,
	FDateTimeOffset3 datetimeoffset(3) null,
	FDateTimeOffset4 datetimeoffset(4) null,
	FDateTimeOffset5 datetimeoffset(5) null,
	FDateTimeOffset6 datetimeoffset(6) null,
	FDateTimeOffset7 datetimeoffset(7) null
)
go
