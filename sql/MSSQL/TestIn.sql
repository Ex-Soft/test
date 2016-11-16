declare @t table (id int, idMain int)

insert into @t (id, idMain) values (1, 1)
insert into @t (id, idMain) values (2, 1)
insert into @t (id, idMain) values (3, 3)

select * from @t where 1 in (id, idMain)