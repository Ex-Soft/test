use testdb;
go

if object_id(N'TestTable4ApplyACBTransactionHistory', N'u') is not null
	drop table TestTable4ApplyACBTransactionHistory;
go

create table TestTable4ApplyACBTransactionHistory
(
	Id int not null identity constraint pkTestTable4ApplyACBTransactionHistory primary key,
	OrderId int null constraint fk_Order_ACBTransactionHistory foreign key references TestTable4ApplyOrder(Id),
	ACBTransactionType nvarchar(50) not null,
	ErrorOccured bit not null default 0
);
go
