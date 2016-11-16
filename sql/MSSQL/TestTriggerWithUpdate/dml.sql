--insert into TableWithTriggerU (value1, value2, value3) values (1, 1, 1)
--insert into TableWithTriggerU (value1, value2, value3) values (2, 2, 2)

--update TableWithTriggerU set value1 = 11
--update TableWithTriggerU set value2 = 22
--update TableWithTriggerU set value3 = 33

--update TableWithTriggerU set value1 = 111, value2 = 222
--update TableWithTriggerU set value1 = 1111, value2 = 2222 where id = 1

select * from TableWithTriggerU
