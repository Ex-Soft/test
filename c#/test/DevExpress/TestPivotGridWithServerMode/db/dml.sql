select * from SalesPeople
select * from Customers
select * from Categories
select * from Products p left join Categories c on c.OID = p.Category

select count(*) from Orders

select top 100
	*
from
	Orders o
	left join Customers c on c.OID = o.Customer
	left join SalesPeople sp on sp.OID = o.SalesPerson
	left join Sales s on s.[Order] = o.OID
	left join Products p on p.OID = s.Product
	left join Categories cat on cat.OID = p.Category
order by o.OID, o.Customer, o.SalesPerson, s.Product, p.Category
	
select top 100
	*
from
	Sales s
	left join Products p on p.OID = s.Product
	left join Categories cat on cat.OID = p.Category
	left join Orders o on o.OID = s.[Order]
	left join SalesPeople sp on sp.OID = o.SalesPerson
	left join Customers c on c.OID = o.Customer
where
	s.[Order] = 58
order by s.[Order], s.Product, p.Category, o.Customer, o.SalesPerson
