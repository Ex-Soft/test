use testdb;
go

delete from TestTable4ApplyACBTransactionHistory;
go

insert into TestTable4ApplyACBTransactionHistory (OrderId, ACBTransactionType, ErrorOccured) values (3, N'Commitment', 0);
go
