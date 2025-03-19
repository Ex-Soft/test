use testdb;
go

if object_id(N'TestTable4ApplyOrder', N'u') is not null
	drop table TestTable4ApplyOrder;
go

create table TestTable4ApplyOrder
(
	Id int not null identity constraint pkTestTable4ApplyOrder primary key,
	Total money null,
	CoopUsed money null,
	CreditCardUsed money null,
	CouponUsed money null,
	ClaimFee money null,
	ShippingFee money null,
	Discount money null
);
go
