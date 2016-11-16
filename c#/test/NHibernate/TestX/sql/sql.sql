use master
go

create database testdb
go

use testdb
go

create table Staff
(
   ID numeric(18) identity,
   Name varchar(254) null,
   BirthDate datetime
)
go
