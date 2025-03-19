use testdb;
go

if object_id(N'TestTable4ApplyCreditCardTransactionHistory', N'u') is not null
	drop table TestTable4ApplyCreditCardTransactionHistory;
go

create table TestTable4ApplyCreditCardTransactionHistory
(
	Id int not null identity constraint pkTestTable4ApplyCreditCardTransactionHistory primary key,
	OrderId int null constraint fk_Order_CreditCardTransactionHistory foreign key references TestTable4ApplyOrder(Id),
	TransactionAmount money not null default 0,
	ErrorOccured bit not null default 0
);
go
