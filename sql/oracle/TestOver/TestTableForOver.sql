create sequence s_TestTableForOver
start with 1
increment by 1;

create table TestTableForOver
(
   id number not null constraint pk_TestTableForOver primary key,
   depno number,
   job nvarchar2(255),
   sal number(18,4)
);
