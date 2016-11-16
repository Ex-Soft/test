create table AnyTest
(
   Id int not null constraint pk_AnyTest primary key,
   Length_Of_File int,
   File_Name varchar(255),
   MD5 varchar(255)
);
