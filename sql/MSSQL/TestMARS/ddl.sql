if object_id(N'TestMARSForRead', N'u') is not null
	drop table TestMARSForRead
go

create table TestMARSForRead
(
   id bigint not null identity constraint pkTestMARSForRead primary key,
   val int null
)
go

insert into TestMARSForRead (val) values (1)
insert into TestMARSForRead (val) values (2)
insert into TestMARSForRead (val) values (3)

if object_id(N'TestMARSForWrite', N'u') is not null
	drop table TestMARSForWrite
go

create table TestMARSForWrite
(
   id bigint not null identity constraint pkTestMARSForWrite primary key,
   val int null
)
go
