declare
	@t1 table (mainId int, subId int, val nvarchar(2))

declare
	@t2 table (mainId int, subId int, val nvarchar(2))

insert into @t1 (mainId, subId, val) values (1, 11, N'AB')
insert into @t1 (mainId, subId, val) values (1, 12, N'CD')
insert into @t1 (mainId, subId, val) values (2, 22, N'EF')
insert into @t2 (mainId, subId, val) values (1, 21, N'X')
insert into @t2 (mainId, subId, val) values (3, 31, N'Y')

select * from
(select mainId, subId, val, row_number() over (partition by mainId order by subId) as rn from @t1) as t1
full join
(select mainId, subId, val, row_number() over (partition by mainId order by subId) as rn from @t2) as t2
on (t1.mainId=t2.mainId) and (t1.rn=t2.rn)

select * from @t1 t1 full join @t2 t2 on (t1.mainId=t2.mainId)
