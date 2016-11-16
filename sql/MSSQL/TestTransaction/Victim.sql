use testdb
go

if object_id(N'Victim', N'u') is not null
	drop table Victim
go

create table Victim
(
	id bigint not null identity constraint pkVictim primary key,
	f_int int null
)
go
