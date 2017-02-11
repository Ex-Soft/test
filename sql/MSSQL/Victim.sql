use testdb
go

if object_id(N'Victim', N'u') is not null
	drop table Victim
go

create table Victim
(
   id bigint not null identity constraint pkVictim primary key,
   f_int int null,
   f_bit bit null
)
go

if not exists (select 1 from syscolumns where id = object_id(N'Victim') and name = N'f_bit')
	alter table Victim add f_bit bit null
else
	print N'Victim.f_bit already exists!!!'
go
