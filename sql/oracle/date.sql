select trunc(sysdate) from dual;
select trim(sysdate) from dual;
select cast('29-02-2008' as date) from dual;
select to_date('29-02-2008 10:00:00','dd-mm-yyyy HH24:MI:SS') from dual;

select dbtimezone from dual;
select sessiontimezone from dual;