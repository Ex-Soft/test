use testdb;
go

if object_id(N'TableWExtendedProperties', N'u') is not null
  drop table TableWExtendedProperties;
go

create table TableWExtendedProperties
(
   Id int not null identity constraint pkTableWExtendedProperties primary key,
   FNVarChar nvarchar(256) null,
   FMoney money null,
   FInt int null,
   FDate date null,
   FNumeric_18_0 numeric(18,0) null
);
go
