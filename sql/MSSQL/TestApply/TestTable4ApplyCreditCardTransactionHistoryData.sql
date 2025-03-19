use testdb;
go

delete from TestTable4ApplyCreditCardTransactionHistory;
go

insert into TestTable4ApplyCreditCardTransactionHistory (OrderId, TransactionAmount, ErrorOccured) values (1, 100, 0);
insert into TestTable4ApplyCreditCardTransactionHistory (OrderId, TransactionAmount, ErrorOccured) values (2, 50, 0);
insert into TestTable4ApplyCreditCardTransactionHistory (OrderId, TransactionAmount, ErrorOccured) values (2, 100, 0);
go
