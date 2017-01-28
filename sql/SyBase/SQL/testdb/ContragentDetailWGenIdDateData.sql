use testdb
go

set identity_insert ContragentDetailWGenIdDate on

insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (1,'Ленин Владимир Илич','20090320')
insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (2,'Ленин Владимир Ильич','20090321')
insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (3,'Сталин Иосиф Виссарионович','20090326')

set identity_insert ContragentDetailWGenIdDate off
go
