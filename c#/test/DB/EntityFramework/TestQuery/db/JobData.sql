use testdb
go

delete from [Job]
go

set identity_insert [Job] on
insert into [Job] (JobID, Name) values (1, N'Job# 1')
insert into [Job] (JobID, Name) values (2, N'Job# 2')
insert into [Job] (JobID, Name) values (3, N'Job# 3')
insert into [Job] (JobID, Name) values (4, N'Job# 4')
insert into [Job] (JobID, Name) values (5, N'Job# 5')
insert into [Job] (JobID, Name) values (6, N'Job# 6')
insert into [Job] (JobID, Name) values (7, N'Job# 7')
insert into [Job] (JobID, Name) values (8, N'Job# 8')
insert into [Job] (JobID, Name) values (9, N'Job# 9')
set identity_insert [Job] off
go
