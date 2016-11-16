if object_id('Objects', 'U') is not null
  drop table Objects
go

if object_id('Types', 'U') is not null
  drop table Types
go

if object_id('Users', 'U') is not null
  drop table Users
go

if object_id('Office', 'U') is not null
  drop table Office
go

create table Office
(
  Id int not null /* identity */ constraint pk_Office primary key,
  OfcId int not null,
  constraint uk_Office unique (OfcId),
  OfcName nvarchar(256) not null
)
go

create table Users
(
  Id int not null /* identity */ constraint pk_Users primary key,
  UsrId int not null,
  UsrName nvarchar(256) not null,
  OfcId int not null,
  constraint uk_Users unique (OfcId, UsrId),
  constraint fk_Users_Office foreign key (OfcId) references Office on delete cascade
)
go

create table Types
(
  Id int not null /* identity */ constraint pk_Types primary key,
  TypId int not null,
  TypName nvarchar(256) not null,
  OfcId int not null,
  constraint uk_Types unique (OfcId, TypId),
  constraint fk_Types_Office foreign key (OfcId) references Office on delete cascade
)
go

create table Objects
(
  Id int not null /* identity */ constraint pk_Objects primary key,
  ObjId int not null,
  ObjName nvarchar(256) not null,
  OfcId int not null,
  UsrId int not null,
  TypId int not null,
  constraint fk_Objects_Office foreign key (OfcId) references Office on delete cascade,
  constraint fk_Objects_Users foreign key (UsrId) references Users on delete cascade,
  constraint fk_Objects_Types foreign key (TypId) references Types on delete cascade
)
go

insert into Office (Id, OfcName, OfcId) values (1, 'Office# 1', 1)
insert into Users (Id, UsrId, UsrName, OfcId) values (1, 1, 'User# 1', 1)
insert into Types (Id, TypId, TypName, OfcId) values (1, 1, 'Type# 1', 1)
insert into Objects (Id, ObjId, ObjName, OfcId, UsrId, TypId) values (1, 1, 'Object# 1', 1, 1, 1)
go

select
  ofc.OfcId,
  ofc.OfcName,
  usr.UsrId,
  usr.UsrName,
  typ.TypId,
  typ.TypName,
  obj.ObjId,
  obj.ObjName
from
  Objects obj
  join Office ofc on (ofc.Id=obj.OfcId)
  join Users usr on (usr.Id=obj.UsrId)
  join Types typ on (typ.Id=obj.TypId)
go

update Office set OfcId=99, OfcName='Office# 99' where Id=1
update Users set UsrId=99, UsrName='User# 99' where Id=1
update Types set TypId=99, TypName='Type# 99' where Id=1
go

select
  ofc.OfcId,
  ofc.OfcName,
  usr.UsrId,
  usr.UsrName,
  typ.TypId,
  typ.TypName,
  obj.ObjId,
  obj.ObjName
from
  Objects obj
  join Office ofc on (ofc.Id=obj.OfcId)
  join Users usr on (usr.Id=obj.UsrId)
  join Types typ on (typ.Id=obj.TypId)
go
