if object_id(N'SaveToTestTable4Date', N'p') is not null
	drop procedure SaveToTestTable4Date
go

--create or alter procedure SaveToTestTable4Date
create procedure SaveToTestTable4Date
	@Id int,
	@FDate date,
	@FDateTime datetime,
	@FDateTime2 datetime2,
	@FSmallDateTime smalldatetime,
	@FTime time,
	@FTime0 time(0),
	@FTime1 time(1),
	@FTime2 time(2),
	@FTime3 time(3),
	@FTime4 time(4),
	@FTime5 time(5),
	@FTime6 time(6),
	@FTime7 time(7),
	@FDateTimeOffset datetimeoffset,
	@FDateTimeOffset0 datetimeoffset(0),
	@FDateTimeOffset1 datetimeoffset(1),
	@FDateTimeOffset2 datetimeoffset(2),
	@FDateTimeOffset3 datetimeoffset(3),
	@FDateTimeOffset4 datetimeoffset(4),
	@FDateTimeOffset5 datetimeoffset(5),
	@FDateTimeOffset6 datetimeoffset(6),
	@FDateTimeOffset7 datetimeoffset(7)
as
begin
	set nocount on;

	insert into TestTable4Date
	(Id, FDate, FDateTime, FDateTime2, FSmallDateTime, FTime, FTime0, FTime1, FTime2, FTime3, FTime4, FTime5, FTime6, FTime7, FDateTimeOffset, FDateTimeOffset0, FDateTimeOffset1, FDateTimeOffset2, FDateTimeOffset3, FDateTimeOffset4, FDateTimeOffset5, FDateTimeOffset6, FDateTimeOffset7)
	values
	(@Id, @FDate, @FDateTime, @FDateTime2, @FSmallDateTime, @FTime, @FTime0, @FTime1, @FTime2, @FTime3, @FTime4, @FTime5, @FTime6, @FTime7, @FDateTimeOffset, @FDateTimeOffset0, @FDateTimeOffset1, @FDateTimeOffset2, @FDateTimeOffset3, @FDateTimeOffset4, @FDateTimeOffset5, @FDateTimeOffset6, @FDateTimeOffset7);
end
go
