/*
delete from TableWithTrigger1WD
delete from TableWithTrigger2WD
*/
select * from TableWithTrigger1WD
select * from TableWithTrigger2WD

/*
if object_id(N'trTableWithTrigger1WD', N'tr') is not null
	disable trigger trTableWithTrigger1WD on TableWithTrigger1WD

if object_id(N'trTableWithTrigger2WD', N'tr') is not null
	disable trigger trTableWithTrigger2WD on TableWithTrigger2WD

insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (1, N'1', N'1', N'1', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (2, N'2', N'2', N'2', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (3, N'2', N'2', N'2', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (4, N'3', N'3', N'3', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (6, N'5', N'5', N'5', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (7, N'6', N'6', N'6', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (8, N'6', N'6', N'6', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (9, N'7', N'7', N'7', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (101, N'101', N'101', N'101', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (103, N'103', N'103', N'103', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (104, N'104', N'104', N'104', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (105, N'104', N'104', N'104', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (202, N'202', N'202', N'202', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (203, N'203', N'203', N'203', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (204, N'204', N'204', N'204', 0)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (205, N'204', N'204', N'204', 1)
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (302, N'302', N'302', N'302', 1)

insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (101, N'101', N'101', N'101', 0)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (102, N'102', N'102', N'102', 0)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (103, N'103', N'103', N'103', 0)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (104, N'104', N'104', N'104', 0)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (201, N'201', N'201', N'201', 1)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (202, N'202', N'202', N'202', 1)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (203, N'203', N'203', N'203', 1)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (204, N'204', N'204', N'204', 1)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (301, N'301', N'301', N'301', 0)
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (302, N'302', N'302', N'302', 1)

if object_id(N'trTableWithTrigger2WD', N'tr') is not null
	enable trigger trTableWithTrigger2WD on TableWithTrigger2WD

if object_id(N'trTableWithTrigger1WD', N'tr') is not null
	enable trigger trTableWithTrigger1WD on TableWithTrigger1WD
*/

/*
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (1, N'1', N'1', N'1', 0) -- 20 && !21 ->skip
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (2, N'2', N'2', N'2', 0) -- 20 && 21 -> skip
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (3, N'3', N'3', N'3', 0) -- !20 && 21 -> upd
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (5, N'4', N'4', N'4', 0) -- !20 && !21 -> ins

insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (6, N'5', N'5', N'5', 1) -- 20 && !21 -> upd
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (8, N'6', N'6', N'6', 1) -- 20 && 21 -> upd
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (9, N'7', N'7', N'7', 1) -- !20 && 21 -> skip
insert into TableWithTrigger1WD (id, value1, value2, value3, deleted) values (10, N'8', N'8', N'8', 1) -- !20 && !21 -> ins

update TableWithTrigger1WD set deleted=1 where id=101 -- 20 && !21 -> upd
update TableWithTrigger1WD set deleted=1 where id=102 -- !20 && !21 -> ins
update TableWithTrigger1WD set deleted=1 where id=103 -- !20 && 21 -> skip
update TableWithTrigger1WD set deleted=1 where id=104 -- 20 && 21 -> upd

update TableWithTrigger1WD set deleted=0 where id=201 -- !20 && !21 -> ins
update TableWithTrigger1WD set deleted=0 where id=202 -- !20 && 21 -> upd
update TableWithTrigger1WD set deleted=0 where id=203 -- 20 && !21 -> skip
update TableWithTrigger1WD set deleted=0 where id=204 -- 20 && 21 -> skip

update TableWithTrigger1WD set value1=value1+value1 where id=301
update TableWithTrigger1WD set value1=value1+value1 where id=302
*/

/*
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (401, N'401', N'401', N'401', 0)
update TableWithTrigger1WD set deleted=1 where id=401
delete from TableWithTrigger2WD where id=401
insert into TableWithTrigger2WD (id, value1, value2, value3, deleted) values (402, N'401', N'401', N'401', 0)
*/
