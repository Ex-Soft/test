insert into TestTableTypes (id, fnvarchar2) values (1, null);
update TestTableTypes set fnvarchar2=null where id=1;
commit;
select * from TestTableTypes where fnvarchar2 is null;
update TestTableTypes set fnvarchar2='' where id=1;
commit;

update TestTableTypes set FClob=null, FNClob=null where ID=1;
commit;
