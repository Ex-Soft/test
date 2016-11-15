use testdb
go

delete from Document
go

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (1, 32, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (1, 63, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (1, 13, 1)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (2, 32, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (2, 63, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (2, 13, 1)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (3, 32, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (3, 63, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (3, 13, 1)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (4, 32, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (4, 63, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (4, 13, 1)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (5, 32, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (5, 63, 1)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (5, 13, 2)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (6, 32, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (6, 63, 3)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (6, 13, 2)

insert into Document (JobId, DocumentTypeId, DocumentStatus) values (7, 32, 2)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (7, 63, 3)
insert into Document (JobId, DocumentTypeId, DocumentStatus) values (7, 13, 2)
go
