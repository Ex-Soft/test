create table TestDetail
(
   Id int identity constraint "pkTestDetail" primary key,
   IdMaster int constraint "TestDetailIdMasterNotNull" not null,
   Val varchar(255),
   constraint "fkTestMasterTestDetail" foreign key (IdMaster) references TestMaster(Id)
)
go
