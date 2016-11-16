use master
go

if db_id('SportsStore') is not null
  drop database SportsStore
go

create database SportsStore
go

use SportsStore
go