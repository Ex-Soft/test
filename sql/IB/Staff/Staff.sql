create table Staff
(
   Id int not null constraint pk_Staff primary key,
   Name varchar(255),
   Salary decimal(18, 4),
   Dep int,
   BirthDate date,
   NullField decimal(18, 0)
);
