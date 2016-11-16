use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TableDetail')
            and    type = 'U')
   drop table TableDetail
go

create table TableDetail
(
   Id int not null identity constraint pkTableDetail primary key,
   MasterId int not null,
   Val varchar(254) null,
   constraint fkMasterDetail foreign key (MasterId) references TableMaster(Id) on update cascade on delete cascade
)
go
