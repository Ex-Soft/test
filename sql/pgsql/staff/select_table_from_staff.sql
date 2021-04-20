create or replace function testdb.select_table_from_staff(depatment testdb.staff.dep%TYPE)
returns
	table (
		id testdb.staff.id%TYPE,
		name testdb.staff.name%TYPE,
		salary testdb.staff.salary%TYPE,
		dep testdb.staff.dep%TYPE,
		birth_date testdb.staff.birth_date%TYPE,
		null_field testdb.staff.null_field%TYPE
	)
language sql
as $$
    select id, name, salary, dep, birth_date, null_field
    from testdb.staff staff
    where staff.dep = depatment;
$$;
