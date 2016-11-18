if object_id(N'TableWithHugeData', N'u') is not null
	drop table TableWithHugeData
go

create table TableWithHugeData
(
	Id bigint not null identity constraint pkTableWithHugeData primary key,
	FString nvarchar(254) null
)
go
