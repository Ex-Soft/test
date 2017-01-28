use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TT2')
            and    type = 'U')
   drop table TT2
go

create table TT2
(
   Id int not null constraint pkTT2 primary key,
   TT1_Id int not null,
   FInt int null,
   FDate date null,
   FStr varchar(256) null,
   constraint fkTT1_TT2 foreign key (TT1_Id) references TT1(Id)
) lock datarows
go
