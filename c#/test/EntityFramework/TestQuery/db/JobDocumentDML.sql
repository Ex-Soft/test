select
	*
from
	[Job] [job]
	join Document document on document.JobId = [job].JobID
where
	document.DocumentTypeId in (32, 63)
	and 2 = any(select document.DocumentStatus from Document document where document.JobId = [job].JobID and document.DocumentTypeId in (32, 63))
	and (select count(document.DocumentId) from Document document where document.JobId = [job].JobID and document.DocumentTypeId in (32, 63) and document.DocumentStatus in (1,2)) = 2

------------------------------------------------------------

declare @Job table (JobID int)
declare @Document table (DocumentId int, JobId int, DocumentTypeId int, DocumentStatus int)

insert into @Job (JobID) values (1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (1, 1, 32, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (2, 1, 63, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (3, 1, 13, 1)

insert into @Job (JobID) values (2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (4, 2, 32, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (5, 2, 63, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (6, 2, 13, 1)

insert into @Job (JobID) values (3)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (7, 3, 32, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (8, 3, 63, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (9, 3, 13, 1)

insert into @Job (JobID) values (4)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (10, 4, 32, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (11, 4, 63, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (12, 4, 13, 1)

insert into @Job (JobID) values (5)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (13, 5, 32, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (14, 5, 63, 1)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (15, 5, 13, 2)

insert into @Job (JobID) values (6)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (16, 6, 32, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (17, 6, 63, 3)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (18, 6, 13, 2)

insert into @Job (JobID) values (7)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (19, 7, 32, 2)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (20, 7, 63, 3)
insert into @Document (DocumentId, JobId, DocumentTypeId, DocumentStatus) values (21, 7, 13, 2)

select
	*
from
	@Job [job]
	join @Document document on document.JobId = [job].JobID
where
	document.DocumentTypeId in (32, 63)
	and 2 = any(select document.DocumentStatus from @Document document where document.JobId = [job].JobID and document.DocumentTypeId in (32, 63))
	and (select count(document.DocumentId) from @Document document where document.JobId = [job].JobID and document.DocumentTypeId in (32, 63) and document.DocumentStatus in (1,2)) = 2
