use testdb
go

set identity_insert TableDetail on

insert into TableDetail (Id, MasterId, Val) values (1, 1, 'Detail_1_1')
insert into TableDetail (Id, MasterId, Val) values (2, 1, 'Detail_1_2')
insert into TableDetail (Id, MasterId, Val) values (3, 1, 'Detail_1_3')
insert into TableDetail (Id, MasterId, Val) values (4, 2, 'Detail_2_1')
insert into TableDetail (Id, MasterId, Val) values (5, 2, 'Detail_2_2')
insert into TableDetail (Id, MasterId, Val) values (6, 2, 'Detail_2_3')
insert into TableDetail (Id, MasterId, Val) values (7, 2, 'Detail_2_4')

set identity_insert TableDetail off

go
