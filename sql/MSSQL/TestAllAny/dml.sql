select
	*
from
	TestAllAnyEmployee e
	left join TestAllAnyDepartment d on (d.id=e.department_id)
	left join TestAllAnyEmployee ec on (ec.id=e.chief_id)

------------------------------------------------------------
-- Вывести список сотрудников, получающих заработную плату большую чем у непосредственного руководителя
select
	*
from
	TestAllAnyEmployee e
where
	(e.salary>(select ec.salary from TestAllAnyEmployee ec where ec.id=e.chief_id))

select
	*
from
	TestAllAnyEmployee e
	join TestAllAnyEmployee ec on (ec.id=e.chief_id) and (ec.salary<e.salary)

------------------------------------------------------------
-- Вывести список сотрудников, получающих максимальную заработную плату в своем отделе
select
	*
from
	TestAllAnyEmployee e
where
	(e.salary>=all(select ee.salary from TestAllAnyEmployee ee where ee.department_id=e.department_id))

select
	*
from
	TestAllAnyEmployee e
where
	(e.salary=(select max(ee.salary) from TestAllAnyEmployee ee where ee.department_id=e.department_id))

------------------------------------------------------------
-- Вывести список ID отделов, количество сотрудников в которых не превышает 3 человек

select
	e.department_id
from
	TestAllAnyEmployee e
group by e.department_id
having count(e.id)<4

------------------------------------------------------------
-- Вывести список сотрудников, не имеющих назначенного руководителя, работающего в том-же отделе
select
	*
from
	TestAllAnyEmployee e
	join TestAllAnyEmployee ec on (ec.id=e.chief_id) and (ec.department_id!=e.department_id)
	
select
	*
from
	TestAllAnyEmployee e
	left join TestAllAnyEmployee ec on (ec.id=e.chief_id) and (ec.department_id=e.department_id)
where
	(e.chief_id is not null)
	and (ec.id is null)

------------------------------------------------------------
-- Найти список ID отделов с максимальной суммарной зарплатой сотрудников

select
	e.department_id,
	sum(e.salary)
from
	TestAllAnyEmployee e
group by e.department_id
having sum(e.salary) >= all	(select
								sum(ee.salary)
							from
								TestAllAnyEmployee ee
							group by ee.department_id
							)

;with CTE (department_id, sum_salary)
as
(
	select
		e.department_id as department_id,
		sum(e.salary) as sum_salary
	from
		TestAllAnyEmployee e
	group by e.department_id
)
select
	department_id,
	sum_salary
from
	CTE cte
where
	cte.sum_salary = (select max(sum_salary) from CTE)
------------------------------------------------------------
-- Вывести всех сотрудников, получающих зарплату, входящую в TOP3
select
	Name,
	Salary
from
	Staff s
where (select count(distinct Salary)
       from Staff
       where Salary > s.Salary
      ) < 3
order by Salary desc

select
	name,
	salary
from
	TestAllAnyEmployee e
where (select count(distinct Salary)
       from TestAllAnyEmployee
       where Salary > e.Salary
      ) < 3
order by Salary desc

select
	Salary
from
	TestAllAnyEmployee
order by Salary desc