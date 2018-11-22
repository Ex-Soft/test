use Movies;
go

if object_id(N'Movie', N'u') is not null
  drop table Movie;
go

create table Movie
(
   ID int not null identity constraint pkMovie primary key,
   Title nvarchar(256) null,
   ReleaseDate date null,
   Genre nvarchar(256) null,
   Price money null
)
go
