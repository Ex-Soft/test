delete from TestTable4TestPIVOTCustomers;
commit;

insert into TestTable4TestPIVOTCustomers (cust_id, cust_name, state_code, times_purchased) values (1, null, 'CT', 1);
insert into TestTable4TestPIVOTCustomers (cust_id, cust_name, state_code, times_purchased) values (2, null, 'NY', 10);
insert into TestTable4TestPIVOTCustomers (cust_id, cust_name, state_code, times_purchased) values (3, null, 'NJ', 2);
insert into TestTable4TestPIVOTCustomers (cust_id, cust_name, state_code, times_purchased) values (4, null, 'NY', 4);
insert into TestTable4TestPIVOTCustomers (cust_id, cust_name, state_code, times_purchased) values (5, null, 'CT', 1);
commit;
