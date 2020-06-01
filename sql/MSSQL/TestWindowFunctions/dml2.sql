declare @orders table (id int, summa numeric(18,2), customerId int)
declare @payments table (customerId int, payment numeric(18,2))

insert @orders (id, summa, customerId)
values 
	(1, 10, 1), 
	(2, 15, 1), 
	(3, 20, 1), 
	(4, 25, 1), 
	(5, 12, 2), 
	(6, 14, 2), 
	(7, 200, 2), 
	(8, 100, 3), 
	(9, 200, 3)

insert @payments (customerId, payment)
values 
	(1, 30), 
	(2, 500), 
	(3, 100), 
	(4, 20)

select
	payments.customerId,
	summa,
	sum(summa) over(partition by orders.customerId) as summa_total,
	payments.payment
from
	@orders orders
	join @payments payments on payments.customerId = orders.customerId

select
	payments.customerId,
	summa,
	sum(summa) over(partition by orders.customerId order by orders.id rows between unbounded preceding and current row) as summa_cumulative,
	payments.payment
from
	@orders orders
	join @payments payments on payments.customerId = orders.customerId

;with summaOrders (id, customerId, summa, summa_cumulative)
as
(
	select
		id,
		customerId,
		summa,
		sum(summa) over(partition by customerId order by id rows between unbounded preceding and current row) as summa_cumulative
	from
		@orders
),
summaPayments (customerId, payment_cummulative)
as
(
	select
		customerId,
		sum(payment) as payment_cummulative
	from
		@payments
	group by customerId
)
select
	*
from
	summaOrders summaOrders
	join summaPayments summaPayments on summaPayments.customerId = summaOrders.customerId
where
	summaOrders.summa_cumulative <= summaPayments.payment_cummulative;
