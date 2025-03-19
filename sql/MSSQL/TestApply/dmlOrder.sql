use testdb;
go

select
	*
from
	dbo.TestTable4ApplyCreditCardTransactionHistory cc
	full join dbo.TestTable4ApplyACBTransactionHistory coop on cc.OrderId = coop.OrderId;

;with CcTotals
as
(
	select
		OrderId,
		coalesce(sum(TransactionAmount), 0) as ccAmount
	from
		dbo.TestTable4ApplyCreditCardTransactionHistory
	group by OrderId
),
CoopTotals
as
(
	select
		OrderId
	from
		dbo.TestTable4ApplyACBTransactionHistory
	group by OrderId
)
select * from CcTotals cc full join CoopTotals coop on cc.OrderId = coop.OrderId;