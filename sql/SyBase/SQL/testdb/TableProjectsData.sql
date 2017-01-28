use testdb
go

set identity_insert TableProjects on

insert into TableProjects (id, date_create, name_project, year_project) values (1, '20090215', 'project_1', 2009)
insert into TableProjects (id, date_create, name_project, year_project) values (2, '20090215', 'project_2', 2009)
insert into TableProjects (id, date_create, name_project, year_project) values (3, '20090216', 'project_1', 2009)
insert into TableProjects (id, date_create, name_project, year_project) values (4, '20090215', 'project_3', 2009)

set identity_insert TableProjects off
go

select
  T1.*
from
  TableProjects T1
where
  T1.date_create>=all(select date_create from TableProjects where (name_project=T1.name_project) and (year_project=T1.year_project))

select
  T1.*
from
  TableProjects T1
where
  T1.date_create=(select max(date_create) from TableProjects where (name_project=T1.name_project) and (year_project=T1.year_project))

