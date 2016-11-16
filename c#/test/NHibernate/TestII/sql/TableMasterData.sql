use testdb
go

set identity_insert TableMaster on

insert into TableMaster (Id, Val) values (1, 'Master_1')
insert into TableMaster (Id, Val) values (2, 'Master_2')
insert into TableMaster (Id, Val) values (3, 'Master_3')
insert into TableMaster (Id, Val) values (4, 'Master_4')
insert into TableMaster (Id, Val) values (5, 'Master_5')

set identity_insert TableMaster off

go
