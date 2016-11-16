create table TableWithHierarchy
(
   Id number not null constraint pk_TableWithHierarchy primary key,
   ParentId number,
   Val varchar(255),
   constraint fk_TableWithHierarchy foreign key (ParentId) references TableWithHierarchy (Id)
);