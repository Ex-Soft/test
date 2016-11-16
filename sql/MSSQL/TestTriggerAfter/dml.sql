insert into TableWithTriggerAfter (id, value) values (1, N'1')
insert into TableWithTriggerAfter (id, value) values (2, N'2')
insert into TableWithTriggerAfter (id, value) values (3, N'3')
insert into TableWithTriggerAfter (id, value) values (4, N'4')
insert into TableWithTriggerAfter (id, value) values (5, N'5')
insert into TableWithTriggerAfter (id, value) values (6, N'6')
update TableWithTriggerAfter set value=value+value where id=6