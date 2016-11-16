set transaction isolation level read uncommitted

select * from victim

/*
begin transaction
insert into victim (f_int) values (2)
commit transaction
*/