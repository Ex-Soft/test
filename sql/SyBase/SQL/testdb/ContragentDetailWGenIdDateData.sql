use testdb
go

set identity_insert ContragentDetailWGenIdDate on

insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (1,'����� �������� ����','20090320')
insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (2,'����� �������� �����','20090321')
insert into ContragentDetailWGenIdDate (GenId, Name, RecordModify) values (3,'������ ����� �������������','20090326')

set identity_insert ContragentDetailWGenIdDate off
go
