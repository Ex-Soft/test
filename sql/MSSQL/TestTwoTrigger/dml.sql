/* insert into TableWithTrigger1 (id, value1, value2, value3) values (1, N'1', N'1', N'1') */
/* update TableWithTrigger1 set value1=N'6', value2=N'6', value3=N'6' where id=6 */
/* insert into TableWithTrigger2 (id, value1, value2, value3) values (2, N'2', N'2', N'2') */
/* update TableWithTrigger2 set value1=N'9', value2=N'9', value3=N'9' where id=9 */

select * from TableWithTrigger1
select * from TableWithTrigger2

/*
insert into TableWithTrigger1 (id, value1, value2, value3) values (9, N'10', N'10', N'10')
insert into TableWithTrigger1 (id, value1, value2, value3) values (10, N'10', N'10', N'10')
*/
/*
insert into TableWithTrigger1 (id, value1, value2, value3)
select
	3 as id,
	N'3' as value1,
	N'3' as value2,
	N'3' as value3
union all
select
	4 as id,
	N'4' as value1,
	N'4' as value2,
	N'4' as value3
union all
select
	5 as id,
	N'5' as value1,
	N'5' as value2,
	N'5' as value3
*/

/*
insert into TableWithTrigger2 (id, value1, value2, value3)
select
	6 as id,
	N'6' as value1,
	N'6' as value2,
	N'6' as value3
union all
select
	7 as id,
	N'7' as value1,
	N'7' as value2,
	N'7' as value3
union all
select
	8 as id,
	N'8' as value1,
	N'8' as value2,
	N'8' as value3
*/


/* update TableWithTrigger1 set value1=value1+value1 */
/* update TableWithTrigger2 set value3=value3+value3 */