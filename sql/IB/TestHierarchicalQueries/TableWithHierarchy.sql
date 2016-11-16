create table TableWithHierarchy
(
   Id int not null constraint pk_TableWithHierarchy primary key,
   ParentId int constraint fk_TableWithHierarchy references TableWithHierarchy (Id),
   Val varchar(256) character set utf8,
   MaterializedPath varchar(256) character set utf8
);
