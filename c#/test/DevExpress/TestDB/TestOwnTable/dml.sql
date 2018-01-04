select * from XPObjectType where AssemblyName = N'TestDB'

--delete from Person

select
	*
from
	Person person

select
	*
from
	Person person
	join Employee employee on employee.Id = person.Id

select
	*
from
	Person person
	join Employee employee on employee.Id = person.Id
	join Executive executive on executive.Id = person.Id

select
	*
from
	Person person
	join Customer customer on customer.Id = person.Id

select
	*
from
	Person person
	left join XPObjectType xpObjectType on xpObjectType.OID = person.ObjectType
	left join Employee employee on employee.Id = person.Id
	left join Executive executive on executive.Id = person.Id
	left join Customer customer on customer.Id = person.Id