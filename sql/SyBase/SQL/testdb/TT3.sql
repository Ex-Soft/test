use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TT3')
            and    type = 'U')
   drop table TT3
go

create table TT3
(
   TT2_Id int not null,
   FInt int null,
   FDate date null,
   FStr varchar(256) null,
   constraint fkTT3_TT2 foreign key (TT2_Id) references TT2(Id)
) lock datarows
go
