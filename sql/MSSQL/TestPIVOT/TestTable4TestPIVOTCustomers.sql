if object_id('TestTable4TestPIVOTCustomers',N'u') is not null
  drop table TestTable4TestPIVOTCustomers
go

create table TestTable4TestPIVOTCustomers
(
   cust_id numeric(10),
   cust_name nvarchar(256),
   state_code nvarchar(2),
   times_purchased numeric(3)
)
go
