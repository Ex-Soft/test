create table TestTableTypes
(
   Id number not null constraint pk_TestTableTypes primary key,
   FVarchar2 varchar2(256),
   FNVarchar2 nvarchar2(256),
   FClob clob,
   FNClob nclob,
   FNumber number,
   FNumber_Asterisk_0 number(*,0),
   FNumber_18_0 number(18,0),
   FSmallint smallint,
   FInt int
);
